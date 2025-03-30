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
   public class trn_organisationconversion : GXProcedure
   {
      public trn_organisationconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_organisationconversion( IGxContext context )
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
         /* Using cursor TRN_ORGANI2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = TRN_ORGANI2_A11OrganisationId[0];
            n11OrganisationId = TRN_ORGANI2_n11OrganisationId[0];
            A405Trn_ThemeFontSize = TRN_ORGANI2_A405Trn_ThemeFontSize[0];
            A281Trn_ThemeFontFamily = TRN_ORGANI2_A281Trn_ThemeFontFamily[0];
            A274Trn_ThemeName = TRN_ORGANI2_A274Trn_ThemeName[0];
            A273Trn_ThemeId = TRN_ORGANI2_A273Trn_ThemeId[0];
            /*
               INSERT RECORD ON TABLE GXA0003

            */
            AV2Trn_ThemeId = A273Trn_ThemeId;
            AV3Trn_ThemeName = A274Trn_ThemeName;
            AV4Trn_ThemeFontFamily = A281Trn_ThemeFontFamily;
            AV5Trn_ThemeFontSize = A405Trn_ThemeFontSize;
            if ( TRN_ORGANI2_n11OrganisationId[0] )
            {
               AV6OrganisationId = Guid.Empty;
            }
            else
            {
               AV6OrganisationId = A11OrganisationId;
            }
            /* Using cursor TRN_ORGANI3 */
            pr_default.execute(1, new Object[] {AV2Trn_ThemeId, AV3Trn_ThemeName, AV4Trn_ThemeFontFamily, AV5Trn_ThemeFontSize, AV6OrganisationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0003");
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
         TRN_ORGANI2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_ORGANI2_n11OrganisationId = new bool[] {false} ;
         TRN_ORGANI2_A405Trn_ThemeFontSize = new short[1] ;
         TRN_ORGANI2_A281Trn_ThemeFontFamily = new string[] {""} ;
         TRN_ORGANI2_A274Trn_ThemeName = new string[] {""} ;
         TRN_ORGANI2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A281Trn_ThemeFontFamily = "";
         A274Trn_ThemeName = "";
         A273Trn_ThemeId = Guid.Empty;
         AV2Trn_ThemeId = Guid.Empty;
         AV3Trn_ThemeName = "";
         AV4Trn_ThemeFontFamily = "";
         AV6OrganisationId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_ORGANI2_A11OrganisationId, TRN_ORGANI2_n11OrganisationId, TRN_ORGANI2_A405Trn_ThemeFontSize, TRN_ORGANI2_A281Trn_ThemeFontFamily, TRN_ORGANI2_A274Trn_ThemeName, TRN_ORGANI2_A273Trn_ThemeId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A405Trn_ThemeFontSize ;
      private short AV5Trn_ThemeFontSize ;
      private int GIGXA0003 ;
      private string Gx_emsg ;
      private bool n11OrganisationId ;
      private string A281Trn_ThemeFontFamily ;
      private string A274Trn_ThemeName ;
      private string AV3Trn_ThemeName ;
      private string AV4Trn_ThemeFontFamily ;
      private Guid A11OrganisationId ;
      private Guid A273Trn_ThemeId ;
      private Guid AV2Trn_ThemeId ;
      private Guid AV6OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_ORGANI2_A11OrganisationId ;
      private bool[] TRN_ORGANI2_n11OrganisationId ;
      private short[] TRN_ORGANI2_A405Trn_ThemeFontSize ;
      private string[] TRN_ORGANI2_A281Trn_ThemeFontFamily ;
      private string[] TRN_ORGANI2_A274Trn_ThemeName ;
      private Guid[] TRN_ORGANI2_A273Trn_ThemeId ;
   }

   public class trn_organisationconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTRN_ORGANI2;
          prmTRN_ORGANI2 = new Object[] {
          };
          Object[] prmTRN_ORGANI3;
          prmTRN_ORGANI3 = new Object[] {
          new ParDef("AV2Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3Trn_ThemeName",GXType.VarChar,100,0) ,
          new ParDef("AV4Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
          new ParDef("AV5Trn_ThemeFontSize",GXType.Int16,4,0) ,
          new ParDef("AV6OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TRN_ORGANI2", "SELECT OrganisationId, Trn_ThemeFontSize, Trn_ThemeFontFamily, Trn_ThemeName, Trn_ThemeId FROM Trn_Theme ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_ORGANI2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_ORGANI3", "INSERT INTO GXA0003(Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, OrganisationId) VALUES(:AV2Trn_ThemeId, :AV3Trn_ThemeName, :AV4Trn_ThemeFontFamily, :AV5Trn_ThemeFontSize, :AV6OrganisationId)", GxErrorMask.GX_NOMASK,prmTRN_ORGANI3)
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
