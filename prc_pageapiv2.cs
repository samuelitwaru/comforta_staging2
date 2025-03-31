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
   public class prc_pageapiv2 : GXProcedure
   {
      public prc_pageapiv2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_pageapiv2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId ,
                           string aP3_UserId ,
                           out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV12PageId = aP0_PageId;
         this.AV10LocationId = aP1_LocationId;
         this.AV8OrganisationId = aP2_OrganisationId;
         this.AV13UserId = aP3_UserId;
         this.AV14SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         initialize();
         ExecuteImpl();
         aP4_SDT_MobilePage=this.AV14SDT_MobilePage;
      }

      public SdtSDT_MobilePage executeUdp( Guid aP0_PageId ,
                                           Guid aP1_LocationId ,
                                           Guid aP2_OrganisationId ,
                                           string aP3_UserId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, aP3_UserId, out aP4_SDT_MobilePage);
         return AV14SDT_MobilePage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 string aP3_UserId ,
                                 out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV12PageId = aP0_PageId;
         this.AV10LocationId = aP1_LocationId;
         this.AV8OrganisationId = aP2_OrganisationId;
         this.AV13UserId = aP3_UserId;
         this.AV14SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         SubmitImpl();
         aP4_SDT_MobilePage=this.AV14SDT_MobilePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DI2 */
         pr_default.execute(0, new Object[] {AV10LocationId, AV8OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00DI2_A523AppVersionId[0];
            A11OrganisationId = P00DI2_A11OrganisationId[0];
            n11OrganisationId = P00DI2_n11OrganisationId[0];
            A29LocationId = P00DI2_A29LocationId[0];
            n29LocationId = P00DI2_n29LocationId[0];
            A535IsActive = P00DI2_A535IsActive[0];
            /* Using cursor P00DI3 */
            pr_default.execute(1, new Object[] {A523AppVersionId, AV12PageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A516PageId = P00DI3_A516PageId[0];
               A536PagePublishedStructure = P00DI3_A536PagePublishedStructure[0];
               AV11SDT_MenuPage = new SdtSDT_MenuPage(context);
               AV11SDT_MenuPage.FromJSonString(A536PagePublishedStructure, null);
               new prc_convertnewtooldmenustructure(context ).execute(  AV11SDT_MenuPage, out  AV14SDT_MobilePage) ;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV14SDT_MobilePage = new SdtSDT_MobilePage(context);
         P00DI2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DI2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DI2_n11OrganisationId = new bool[] {false} ;
         P00DI2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DI2_n29LocationId = new bool[] {false} ;
         P00DI2_A535IsActive = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         P00DI3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DI3_A516PageId = new Guid[] {Guid.Empty} ;
         P00DI3_A536PagePublishedStructure = new string[] {""} ;
         A516PageId = Guid.Empty;
         A536PagePublishedStructure = "";
         AV11SDT_MenuPage = new SdtSDT_MenuPage(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_pageapiv2__default(),
            new Object[][] {
                new Object[] {
               P00DI2_A523AppVersionId, P00DI2_A11OrganisationId, P00DI2_n11OrganisationId, P00DI2_A29LocationId, P00DI2_n29LocationId, P00DI2_A535IsActive
               }
               , new Object[] {
               P00DI3_A523AppVersionId, P00DI3_A516PageId, P00DI3_A536PagePublishedStructure
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private bool A535IsActive ;
      private string A536PagePublishedStructure ;
      private string AV13UserId ;
      private Guid AV12PageId ;
      private Guid AV10LocationId ;
      private Guid AV8OrganisationId ;
      private Guid A523AppVersionId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_MobilePage AV14SDT_MobilePage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DI2_A523AppVersionId ;
      private Guid[] P00DI2_A11OrganisationId ;
      private bool[] P00DI2_n11OrganisationId ;
      private Guid[] P00DI2_A29LocationId ;
      private bool[] P00DI2_n29LocationId ;
      private bool[] P00DI2_A535IsActive ;
      private Guid[] P00DI3_A523AppVersionId ;
      private Guid[] P00DI3_A516PageId ;
      private string[] P00DI3_A536PagePublishedStructure ;
      private SdtSDT_MenuPage AV11SDT_MenuPage ;
      private SdtSDT_MobilePage aP4_SDT_MobilePage ;
   }

   public class prc_pageapiv2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DI2;
          prmP00DI2 = new Object[] {
          new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DI3;
          prmP00DI3 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DI2", "SELECT AppVersionId, OrganisationId, LocationId, IsActive FROM Trn_AppVersion WHERE (LocationId = :AV10LocationId and OrganisationId = :AV8OrganisationId) AND (IsActive = TRUE) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DI2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DI3", "SELECT AppVersionId, PageId, PagePublishedStructure FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :AV12PageId ORDER BY AppVersionId, PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DI3,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                return;
       }
    }

 }

}
