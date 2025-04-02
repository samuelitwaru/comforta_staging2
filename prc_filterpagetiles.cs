using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_filterpagetiles : GXProcedure
   {
      public prc_filterpagetiles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_filterpagetiles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSDT_MobilePage aP0_SDT_MobilePage ,
                           string aP1_UserId ,
                           out SdtSDT_MobilePage aP2_Filtered_SDT_MobilePage )
      {
         this.AV9SDT_MobilePage = aP0_SDT_MobilePage;
         this.AV8UserId = aP1_UserId;
         this.AV11Filtered_SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         initialize();
         ExecuteImpl();
         aP2_Filtered_SDT_MobilePage=this.AV11Filtered_SDT_MobilePage;
      }

      public SdtSDT_MobilePage executeUdp( SdtSDT_MobilePage aP0_SDT_MobilePage ,
                                           string aP1_UserId )
      {
         execute(aP0_SDT_MobilePage, aP1_UserId, out aP2_Filtered_SDT_MobilePage);
         return AV11Filtered_SDT_MobilePage ;
      }

      public void executeSubmit( SdtSDT_MobilePage aP0_SDT_MobilePage ,
                                 string aP1_UserId ,
                                 out SdtSDT_MobilePage aP2_Filtered_SDT_MobilePage )
      {
         this.AV9SDT_MobilePage = aP0_SDT_MobilePage;
         this.AV8UserId = aP1_UserId;
         this.AV11Filtered_SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         SubmitImpl();
         aP2_Filtered_SDT_MobilePage=this.AV11Filtered_SDT_MobilePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Filtered_SDT_MobilePage.FromJSonString(AV9SDT_MobilePage.ToJSonString(false, true), null);
         AV10ModuleCollection.FromJSonString(context.GetMessage( "[\"my care\",\"my living\",\"my services\"]", ""), null);
         new prc_logtoserver(context ).execute(  context.GetMessage( "User: ", "")+AV8UserId) ;
         new prc_logtoserver(context ).execute(  context.GetMessage( "User >>: ", "")+AV8UserId) ;
         /* Using cursor P00C52 */
         pr_default.execute(0, new Object[] {AV8UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A527ResidentPackageId = P00C52_A527ResidentPackageId[0];
            n527ResidentPackageId = P00C52_n527ResidentPackageId[0];
            A532ResidentPackageModules = P00C52_A532ResidentPackageModules[0];
            A71ResidentGUID = P00C52_A71ResidentGUID[0];
            A62ResidentId = P00C52_A62ResidentId[0];
            A29LocationId = P00C52_A29LocationId[0];
            A11OrganisationId = P00C52_A11OrganisationId[0];
            A532ResidentPackageModules = P00C52_A532ResidentPackageModules[0];
            /* Using cursor P00C53 */
            pr_default.execute(1, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               AV15UserModuleCollection.FromJSonString(StringUtil.Lower( A532ResidentPackageModules), null);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new prc_logtoserver(context ).execute(  context.GetMessage( "User Modules: ", "")+AV15UserModuleCollection.ToJSonString(false)) ;
         AV11Filtered_SDT_MobilePage.gxTpr_Row.Clear();
         AV21GXV1 = 1;
         while ( AV21GXV1 <= AV9SDT_MobilePage.gxTpr_Row.Count )
         {
            AV12RowItem = ((SdtSDT_Row)AV9SDT_MobilePage.gxTpr_Row.Item(AV21GXV1));
            AV17Index = 1;
            AV18FilteredRow = new SdtSDT_Row(context);
            if ( AV12RowItem.gxTpr_Col.Count > 0 )
            {
               AV22GXV2 = 1;
               while ( AV22GXV2 <= AV12RowItem.gxTpr_Col.Count )
               {
                  AV13ColItem = ((SdtSDT_Col)AV12RowItem.gxTpr_Col.Item(AV22GXV2));
                  AV16TileName = StringUtil.Lower( AV13ColItem.gxTpr_Tile.gxTpr_Tilename);
                  if ( (AV10ModuleCollection.IndexOf(StringUtil.RTrim( AV16TileName))>0) )
                  {
                     if ( (AV15UserModuleCollection.IndexOf(StringUtil.RTrim( AV16TileName))>0) )
                     {
                        AV18FilteredRow.gxTpr_Col.Add(AV13ColItem, 0);
                     }
                  }
                  else
                  {
                     AV18FilteredRow.gxTpr_Col.Add(AV13ColItem, 0);
                  }
                  AV17Index = (short)(AV17Index+1);
                  AV22GXV2 = (int)(AV22GXV2+1);
               }
            }
            AV11Filtered_SDT_MobilePage.gxTpr_Row.Add(AV18FilteredRow, 0);
            AV21GXV1 = (int)(AV21GXV1+1);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Filtered_SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV10ModuleCollection = new GxSimpleCollection<string>();
         P00C52_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00C52_n527ResidentPackageId = new bool[] {false} ;
         P00C52_A532ResidentPackageModules = new string[] {""} ;
         P00C52_A71ResidentGUID = new string[] {""} ;
         P00C52_A62ResidentId = new Guid[] {Guid.Empty} ;
         P00C52_A29LocationId = new Guid[] {Guid.Empty} ;
         P00C52_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A527ResidentPackageId = Guid.Empty;
         A532ResidentPackageModules = "";
         A71ResidentGUID = "";
         A62ResidentId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         P00C53_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         P00C53_n527ResidentPackageId = new bool[] {false} ;
         AV15UserModuleCollection = new GxSimpleCollection<string>();
         AV12RowItem = new SdtSDT_Row(context);
         AV18FilteredRow = new SdtSDT_Row(context);
         AV13ColItem = new SdtSDT_Col(context);
         AV16TileName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_filterpagetiles__default(),
            new Object[][] {
                new Object[] {
               P00C52_A527ResidentPackageId, P00C52_n527ResidentPackageId, P00C52_A532ResidentPackageModules, P00C52_A71ResidentGUID, P00C52_A62ResidentId, P00C52_A29LocationId, P00C52_A11OrganisationId
               }
               , new Object[] {
               P00C53_A527ResidentPackageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17Index ;
      private int AV21GXV1 ;
      private int AV22GXV2 ;
      private bool n527ResidentPackageId ;
      private string A532ResidentPackageModules ;
      private string AV8UserId ;
      private string A71ResidentGUID ;
      private string AV16TileName ;
      private Guid A527ResidentPackageId ;
      private Guid A62ResidentId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_MobilePage AV9SDT_MobilePage ;
      private SdtSDT_MobilePage AV11Filtered_SDT_MobilePage ;
      private GxSimpleCollection<string> AV10ModuleCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00C52_A527ResidentPackageId ;
      private bool[] P00C52_n527ResidentPackageId ;
      private string[] P00C52_A532ResidentPackageModules ;
      private string[] P00C52_A71ResidentGUID ;
      private Guid[] P00C52_A62ResidentId ;
      private Guid[] P00C52_A29LocationId ;
      private Guid[] P00C52_A11OrganisationId ;
      private Guid[] P00C53_A527ResidentPackageId ;
      private bool[] P00C53_n527ResidentPackageId ;
      private GxSimpleCollection<string> AV15UserModuleCollection ;
      private SdtSDT_Row AV12RowItem ;
      private SdtSDT_Row AV18FilteredRow ;
      private SdtSDT_Col AV13ColItem ;
      private SdtSDT_MobilePage aP2_Filtered_SDT_MobilePage ;
   }

   public class prc_filterpagetiles__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C52;
          prmP00C52 = new Object[] {
          new ParDef("AV8UserId",GXType.VarChar,4,0)
          };
          Object[] prmP00C53;
          prmP00C53 = new Object[] {
          new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00C52", "SELECT T1.ResidentPackageId, T2.ResidentPackageModules, T1.ResidentGUID, T1.ResidentId, T1.LocationId, T1.OrganisationId FROM (Trn_Resident T1 LEFT JOIN Trn_ResidentPackage T2 ON T2.ResidentPackageId = T1.ResidentPackageId) WHERE T1.ResidentGUID = ( :AV8UserId) ORDER BY T1.ResidentId, T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C52,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C53", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ORDER BY ResidentPackageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C53,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                ((Guid[]) buf[6])[0] = rslt.getGuid(6);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
