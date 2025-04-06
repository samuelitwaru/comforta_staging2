using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class trn_locationconversion : GXProcedure
   {
      public trn_locationconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_locationconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor TRN_LOCATI2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = TRN_LOCATI2_A11OrganisationId[0];
            n11OrganisationId = TRN_LOCATI2_n11OrganisationId[0];
            A29LocationId = TRN_LOCATI2_A29LocationId[0];
            n29LocationId = TRN_LOCATI2_n29LocationId[0];
            A535IsActive = TRN_LOCATI2_A535IsActive[0];
            A524AppVersionName = TRN_LOCATI2_A524AppVersionName[0];
            A523AppVersionId = TRN_LOCATI2_A523AppVersionId[0];
            /*
               INSERT RECORD ON TABLE GXA0006

            */
            AV2AppVersionId = A523AppVersionId;
            AV3AppVersionName = A524AppVersionName;
            AV4IsActive = A535IsActive;
            if ( TRN_LOCATI2_n29LocationId[0] )
            {
               AV5LocationId = Guid.Empty;
            }
            else
            {
               AV5LocationId = A29LocationId;
            }
            if ( TRN_LOCATI2_n11OrganisationId[0] )
            {
               AV6OrganisationId = Guid.Empty;
            }
            else
            {
               AV6OrganisationId = A11OrganisationId;
            }
            /* Using cursor TRN_LOCATI3 */
            pr_default.execute(1, new Object[] {AV2AppVersionId, AV3AppVersionName, AV4IsActive, AV5LocationId, AV6OrganisationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0006");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         TRN_LOCATI2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_n11OrganisationId = new bool[] {false} ;
         TRN_LOCATI2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_n29LocationId = new bool[] {false} ;
         TRN_LOCATI2_A535IsActive = new bool[] {false} ;
         TRN_LOCATI2_A524AppVersionName = new string[] {""} ;
         TRN_LOCATI2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A524AppVersionName = "";
         A523AppVersionId = Guid.Empty;
         AV2AppVersionId = Guid.Empty;
         AV3AppVersionName = "";
         AV5LocationId = Guid.Empty;
         AV6OrganisationId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_LOCATI2_A11OrganisationId, TRN_LOCATI2_n11OrganisationId, TRN_LOCATI2_A29LocationId, TRN_LOCATI2_n29LocationId, TRN_LOCATI2_A535IsActive, TRN_LOCATI2_A524AppVersionName, TRN_LOCATI2_A523AppVersionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0006 ;
      private string Gx_emsg ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private bool A535IsActive ;
      private bool AV4IsActive ;
      private string A524AppVersionName ;
      private string AV3AppVersionName ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A523AppVersionId ;
      private Guid AV2AppVersionId ;
      private Guid AV5LocationId ;
      private Guid AV6OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_LOCATI2_A11OrganisationId ;
      private bool[] TRN_LOCATI2_n11OrganisationId ;
      private Guid[] TRN_LOCATI2_A29LocationId ;
      private bool[] TRN_LOCATI2_n29LocationId ;
      private bool[] TRN_LOCATI2_A535IsActive ;
      private string[] TRN_LOCATI2_A524AppVersionName ;
      private Guid[] TRN_LOCATI2_A523AppVersionId ;
   }

   public class trn_locationconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTRN_LOCATI2;
          prmTRN_LOCATI2 = new Object[] {
          };
          Object[] prmTRN_LOCATI3;
          prmTRN_LOCATI3 = new Object[] {
          new ParDef("AV2AppVersionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3AppVersionName",GXType.VarChar,100,0) ,
          new ParDef("AV4IsActive",GXType.Boolean,4,0) ,
          new ParDef("AV5LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV6OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_LOCATI2", "SELECT OrganisationId, LocationId, IsActive, AppVersionName, AppVersionId FROM Trn_AppVersion ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_LOCATI2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_LOCATI3", "INSERT INTO GXA0006(AppVersionId, AppVersionName, IsActive, LocationId, OrganisationId) VALUES(:AV2AppVersionId, :AV3AppVersionName, :AV4IsActive, :AV5LocationId, :AV6OrganisationId)", GxErrorMask.GX_NOMASK,prmTRN_LOCATI3)
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[6])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
