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
   public class trn_appversionupdatereferentialintegrity : GXProcedure
   {
      public trn_appversionupdatereferentialintegrity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_appversionupdatereferentialintegrity( IGxContext context )
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
         /* Using cursor TRN_APPVER2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = TRN_APPVER2_A11OrganisationId[0];
            n11OrganisationId = TRN_APPVER2_n11OrganisationId[0];
            A29LocationId = TRN_APPVER2_A29LocationId[0];
            n29LocationId = TRN_APPVER2_n29LocationId[0];
            A535IsActive = TRN_APPVER2_A535IsActive[0];
            A524AppVersionName = TRN_APPVER2_A524AppVersionName[0];
            A523AppVersionId = TRN_APPVER2_A523AppVersionId[0];
            A584ActiveAppVersionId = TRN_APPVER2_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = TRN_APPVER2_n584ActiveAppVersionId[0];
            A584ActiveAppVersionId = TRN_APPVER2_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = TRN_APPVER2_n584ActiveAppVersionId[0];
            /*
               INSERT RECORD ON TABLE Trn_AppVersion

            */
            W523AppVersionId = A523AppVersionId;
            W524AppVersionName = A524AppVersionName;
            W535IsActive = A535IsActive;
            W29LocationId = A29LocationId;
            n29LocationId = false;
            W29LocationId = A29LocationId;
            n29LocationId = false;
            W11OrganisationId = A11OrganisationId;
            n11OrganisationId = false;
            W11OrganisationId = A11OrganisationId;
            n11OrganisationId = false;
            if ( TRN_APPVER2_n29LocationId[0] )
            {
               A29LocationId = Guid.Empty;
               n29LocationId = false;
               n29LocationId = true;
            }
            else
            {
               n29LocationId = false;
            }
            if ( TRN_APPVER2_n11OrganisationId[0] )
            {
               A11OrganisationId = Guid.Empty;
               n11OrganisationId = false;
               n11OrganisationId = true;
            }
            else
            {
               n11OrganisationId = false;
            }
            /* Using cursor TRN_APPVER3 */
            pr_default.execute(1, new Object[] {A523AppVersionId});
            if ( (pr_default.getStatus(1) != 101) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
               /* Using cursor TRN_APPVER4 */
               pr_default.execute(2, new Object[] {A523AppVersionId, A524AppVersionName, A535IsActive, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
            }
            A523AppVersionId = W523AppVersionId;
            A524AppVersionName = W524AppVersionName;
            A535IsActive = W535IsActive;
            A29LocationId = W29LocationId;
            n29LocationId = false;
            A29LocationId = W29LocationId;
            n29LocationId = false;
            A11OrganisationId = W11OrganisationId;
            n11OrganisationId = false;
            A11OrganisationId = W11OrganisationId;
            n11OrganisationId = false;
            /* End Insert */
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
         TRN_APPVER2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_APPVER2_n11OrganisationId = new bool[] {false} ;
         TRN_APPVER2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_APPVER2_n29LocationId = new bool[] {false} ;
         TRN_APPVER2_A535IsActive = new bool[] {false} ;
         TRN_APPVER2_A524AppVersionName = new string[] {""} ;
         TRN_APPVER2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         TRN_APPVER2_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         TRN_APPVER2_n584ActiveAppVersionId = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A524AppVersionName = "";
         A523AppVersionId = Guid.Empty;
         A584ActiveAppVersionId = Guid.Empty;
         W523AppVersionId = Guid.Empty;
         W524AppVersionName = "";
         W29LocationId = Guid.Empty;
         W11OrganisationId = Guid.Empty;
         TRN_APPVER3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appversionupdatereferentialintegrity__default(),
            new Object[][] {
                new Object[] {
               TRN_APPVER2_A11OrganisationId, TRN_APPVER2_n11OrganisationId, TRN_APPVER2_A29LocationId, TRN_APPVER2_n29LocationId, TRN_APPVER2_A535IsActive, TRN_APPVER2_A524AppVersionName, TRN_APPVER2_A523AppVersionId, TRN_APPVER2_A584ActiveAppVersionId, TRN_APPVER2_n584ActiveAppVersionId
               }
               , new Object[] {
               TRN_APPVER3_A523AppVersionId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS6 ;
      private string Gx_emsg ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private bool A535IsActive ;
      private bool n584ActiveAppVersionId ;
      private bool W535IsActive ;
      private string A524AppVersionName ;
      private string W524AppVersionName ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A523AppVersionId ;
      private Guid A584ActiveAppVersionId ;
      private Guid W523AppVersionId ;
      private Guid W29LocationId ;
      private Guid W11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_APPVER2_A11OrganisationId ;
      private bool[] TRN_APPVER2_n11OrganisationId ;
      private Guid[] TRN_APPVER2_A29LocationId ;
      private bool[] TRN_APPVER2_n29LocationId ;
      private bool[] TRN_APPVER2_A535IsActive ;
      private string[] TRN_APPVER2_A524AppVersionName ;
      private Guid[] TRN_APPVER2_A523AppVersionId ;
      private Guid[] TRN_APPVER2_A584ActiveAppVersionId ;
      private bool[] TRN_APPVER2_n584ActiveAppVersionId ;
      private Guid[] TRN_APPVER3_A523AppVersionId ;
   }

   public class trn_appversionupdatereferentialintegrity__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTRN_APPVER2;
          prmTRN_APPVER2 = new Object[] {
          };
          Object[] prmTRN_APPVER3;
          prmTRN_APPVER3 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTRN_APPVER4;
          prmTRN_APPVER4 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AppVersionName",GXType.VarChar,100,0) ,
          new ParDef("IsActive",GXType.Boolean,4,0) ,
          new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TRN_APPVER2", "SELECT T1.OrganisationId, T1.LocationId, T1.IsActive, T1.AppVersionName, T1.AppVersionId, T2.ActiveAppVersionId FROM (Trn_AppVersion T1 LEFT JOIN Trn_Location T2 ON T2.LocationId = T1.LocationId AND T2.OrganisationId = T1.OrganisationId) ORDER BY T1.AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_APPVER2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_APPVER3", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_APPVER3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_APPVER4", "INSERT INTO Trn_AppVersion(AppVersionId, AppVersionName, IsActive, LocationId, OrganisationId) VALUES(:AppVersionId, :AppVersionName, :IsActive, :LocationId, :OrganisationId)", GxErrorMask.GX_NOMASK,prmTRN_APPVER4)
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
                ((Guid[]) buf[7])[0] = rslt.getGuid(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
