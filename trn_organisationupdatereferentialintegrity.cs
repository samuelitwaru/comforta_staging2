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
   public class trn_organisationupdatereferentialintegrity : GXProcedure
   {
      public trn_organisationupdatereferentialintegrity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public trn_organisationupdatereferentialintegrity( IGxContext context )
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
            A40011OrganisationLogo_GXI = TRN_ORGANI2_A40011OrganisationLogo_GXI[0];
            A273Trn_ThemeId = TRN_ORGANI2_A273Trn_ThemeId[0];
            A506OrganisationLogo = TRN_ORGANI2_A506OrganisationLogo[0];
            A40011OrganisationLogo_GXI = TRN_ORGANI2_A40011OrganisationLogo_GXI[0];
            A506OrganisationLogo = TRN_ORGANI2_A506OrganisationLogo[0];
            /*
               INSERT RECORD ON TABLE Trn_Organisation

            */
            W11OrganisationId = A11OrganisationId;
            n11OrganisationId = false;
            W11OrganisationId = A11OrganisationId;
            n11OrganisationId = false;
            W12OrganisationKvkNumber = A12OrganisationKvkNumber;
            W12OrganisationKvkNumber = A12OrganisationKvkNumber;
            W13OrganisationName = A13OrganisationName;
            W13OrganisationName = A13OrganisationName;
            W16OrganisationEmail = A16OrganisationEmail;
            W16OrganisationEmail = A16OrganisationEmail;
            W17OrganisationPhone = A17OrganisationPhone;
            W17OrganisationPhone = A17OrganisationPhone;
            W18OrganisationVATNumber = A18OrganisationVATNumber;
            W18OrganisationVATNumber = A18OrganisationVATNumber;
            W19OrganisationTypeId = A19OrganisationTypeId;
            W19OrganisationTypeId = A19OrganisationTypeId;
            W251OrganisationAddressZipCode = A251OrganisationAddressZipCode;
            W251OrganisationAddressZipCode = A251OrganisationAddressZipCode;
            W252OrganisationAddressCity = A252OrganisationAddressCity;
            W252OrganisationAddressCity = A252OrganisationAddressCity;
            W303OrganisationAddressCountry = A303OrganisationAddressCountry;
            W303OrganisationAddressCountry = A303OrganisationAddressCountry;
            W304OrganisationAddressLine1 = A304OrganisationAddressLine1;
            W304OrganisationAddressLine1 = A304OrganisationAddressLine1;
            W305OrganisationAddressLine2 = A305OrganisationAddressLine2;
            W305OrganisationAddressLine2 = A305OrganisationAddressLine2;
            W361OrganisationPhoneCode = A361OrganisationPhoneCode;
            W361OrganisationPhoneCode = A361OrganisationPhoneCode;
            W362OrganisationPhoneNumber = A362OrganisationPhoneNumber;
            W362OrganisationPhoneNumber = A362OrganisationPhoneNumber;
            W506OrganisationLogo = A506OrganisationLogo;
            W506OrganisationLogo = A506OrganisationLogo;
            W40011OrganisationLogo_GXI = A40011OrganisationLogo_GXI;
            if ( TRN_ORGANI2_n11OrganisationId[0] )
            {
               A11OrganisationId = Guid.Empty;
               n11OrganisationId = false;
            }
            else
            {
               n11OrganisationId = false;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A12OrganisationKvkNumber)) )
            {
               A12OrganisationKvkNumber = " ";
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A13OrganisationName)) )
            {
               A13OrganisationName = " ";
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A16OrganisationEmail)) )
            {
               A16OrganisationEmail = " ";
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A17OrganisationPhone)) )
            {
               A17OrganisationPhone = " ";
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A18OrganisationVATNumber)) )
            {
               A18OrganisationVATNumber = " ";
            }
            else
            {
            }
            if ( (Guid.Empty==A19OrganisationTypeId) )
            {
               A19OrganisationTypeId = Guid.Empty;
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A251OrganisationAddressZipCode)) )
            {
               A251OrganisationAddressZipCode = " ";
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A252OrganisationAddressCity)) )
            {
               A252OrganisationAddressCity = " ";
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A303OrganisationAddressCountry)) )
            {
               A303OrganisationAddressCountry = " ";
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A304OrganisationAddressLine1)) )
            {
               A304OrganisationAddressLine1 = " ";
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A305OrganisationAddressLine2)) )
            {
               A305OrganisationAddressLine2 = " ";
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A361OrganisationPhoneCode)) )
            {
               A361OrganisationPhoneCode = " ";
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A362OrganisationPhoneNumber)) )
            {
               A362OrganisationPhoneNumber = " ";
            }
            else
            {
            }
            if ( TRN_ORGANI2_n506OrganisationLogo[0] )
            {
               A506OrganisationLogo = "";
            }
            else
            {
            }
            /* Using cursor TRN_ORGANI3 */
            pr_default.execute(1, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(1) != 101) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
               /* Using cursor TRN_ORGANI4 */
               pr_default.execute(2, new Object[] {n11OrganisationId, A11OrganisationId, A12OrganisationKvkNumber, A13OrganisationName, A16OrganisationEmail, A17OrganisationPhone, A18OrganisationVATNumber, A19OrganisationTypeId, A251OrganisationAddressZipCode, A252OrganisationAddressCity, A303OrganisationAddressCountry, A304OrganisationAddressLine1, A305OrganisationAddressLine2, A361OrganisationPhoneCode, A362OrganisationPhoneNumber, A506OrganisationLogo, A40011OrganisationLogo_GXI});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("Trn_Organisation");
            }
            A11OrganisationId = W11OrganisationId;
            n11OrganisationId = false;
            A11OrganisationId = W11OrganisationId;
            n11OrganisationId = false;
            A12OrganisationKvkNumber = W12OrganisationKvkNumber;
            A12OrganisationKvkNumber = W12OrganisationKvkNumber;
            A13OrganisationName = W13OrganisationName;
            A13OrganisationName = W13OrganisationName;
            A16OrganisationEmail = W16OrganisationEmail;
            A16OrganisationEmail = W16OrganisationEmail;
            A17OrganisationPhone = W17OrganisationPhone;
            A17OrganisationPhone = W17OrganisationPhone;
            A18OrganisationVATNumber = W18OrganisationVATNumber;
            A18OrganisationVATNumber = W18OrganisationVATNumber;
            A19OrganisationTypeId = W19OrganisationTypeId;
            A19OrganisationTypeId = W19OrganisationTypeId;
            A251OrganisationAddressZipCode = W251OrganisationAddressZipCode;
            A251OrganisationAddressZipCode = W251OrganisationAddressZipCode;
            A252OrganisationAddressCity = W252OrganisationAddressCity;
            A252OrganisationAddressCity = W252OrganisationAddressCity;
            A303OrganisationAddressCountry = W303OrganisationAddressCountry;
            A303OrganisationAddressCountry = W303OrganisationAddressCountry;
            A304OrganisationAddressLine1 = W304OrganisationAddressLine1;
            A304OrganisationAddressLine1 = W304OrganisationAddressLine1;
            A305OrganisationAddressLine2 = W305OrganisationAddressLine2;
            A305OrganisationAddressLine2 = W305OrganisationAddressLine2;
            A361OrganisationPhoneCode = W361OrganisationPhoneCode;
            A361OrganisationPhoneCode = W361OrganisationPhoneCode;
            A362OrganisationPhoneNumber = W362OrganisationPhoneNumber;
            A362OrganisationPhoneNumber = W362OrganisationPhoneNumber;
            A506OrganisationLogo = W506OrganisationLogo;
            A506OrganisationLogo = W506OrganisationLogo;
            A40011OrganisationLogo_GXI = W40011OrganisationLogo_GXI;
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
         TRN_ORGANI2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_ORGANI2_n11OrganisationId = new bool[] {false} ;
         TRN_ORGANI2_A40011OrganisationLogo_GXI = new string[] {""} ;
         TRN_ORGANI2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         TRN_ORGANI2_A506OrganisationLogo = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A40011OrganisationLogo_GXI = "";
         A273Trn_ThemeId = Guid.Empty;
         A506OrganisationLogo = "";
         W11OrganisationId = Guid.Empty;
         W12OrganisationKvkNumber = "";
         A12OrganisationKvkNumber = "";
         W13OrganisationName = "";
         A13OrganisationName = "";
         W16OrganisationEmail = "";
         A16OrganisationEmail = "";
         W17OrganisationPhone = "";
         A17OrganisationPhone = "";
         W18OrganisationVATNumber = "";
         A18OrganisationVATNumber = "";
         W19OrganisationTypeId = Guid.Empty;
         A19OrganisationTypeId = Guid.Empty;
         W251OrganisationAddressZipCode = "";
         A251OrganisationAddressZipCode = "";
         W252OrganisationAddressCity = "";
         A252OrganisationAddressCity = "";
         W303OrganisationAddressCountry = "";
         A303OrganisationAddressCountry = "";
         W304OrganisationAddressLine1 = "";
         A304OrganisationAddressLine1 = "";
         W305OrganisationAddressLine2 = "";
         A305OrganisationAddressLine2 = "";
         W361OrganisationPhoneCode = "";
         A361OrganisationPhoneCode = "";
         W362OrganisationPhoneNumber = "";
         A362OrganisationPhoneNumber = "";
         W506OrganisationLogo = "";
         W40011OrganisationLogo_GXI = "";
         TRN_ORGANI2_n506OrganisationLogo = new bool[] {false} ;
         TRN_ORGANI3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_ORGANI3_n11OrganisationId = new bool[] {false} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationupdatereferentialintegrity__default(),
            new Object[][] {
                new Object[] {
               TRN_ORGANI2_A11OrganisationId, TRN_ORGANI2_n11OrganisationId, TRN_ORGANI2_A40011OrganisationLogo_GXI, TRN_ORGANI2_A273Trn_ThemeId, TRN_ORGANI2_A506OrganisationLogo
               }
               , new Object[] {
               TRN_ORGANI3_A11OrganisationId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS3 ;
      private string W17OrganisationPhone ;
      private string A17OrganisationPhone ;
      private string Gx_emsg ;
      private bool n11OrganisationId ;
      private string A40011OrganisationLogo_GXI ;
      private string W12OrganisationKvkNumber ;
      private string A12OrganisationKvkNumber ;
      private string W13OrganisationName ;
      private string A13OrganisationName ;
      private string W16OrganisationEmail ;
      private string A16OrganisationEmail ;
      private string W18OrganisationVATNumber ;
      private string A18OrganisationVATNumber ;
      private string W251OrganisationAddressZipCode ;
      private string A251OrganisationAddressZipCode ;
      private string W252OrganisationAddressCity ;
      private string A252OrganisationAddressCity ;
      private string W303OrganisationAddressCountry ;
      private string A303OrganisationAddressCountry ;
      private string W304OrganisationAddressLine1 ;
      private string A304OrganisationAddressLine1 ;
      private string W305OrganisationAddressLine2 ;
      private string A305OrganisationAddressLine2 ;
      private string W361OrganisationPhoneCode ;
      private string A361OrganisationPhoneCode ;
      private string W362OrganisationPhoneNumber ;
      private string A362OrganisationPhoneNumber ;
      private string W40011OrganisationLogo_GXI ;
      private string A506OrganisationLogo ;
      private string W506OrganisationLogo ;
      private Guid A11OrganisationId ;
      private Guid A273Trn_ThemeId ;
      private Guid W11OrganisationId ;
      private Guid W19OrganisationTypeId ;
      private Guid A19OrganisationTypeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_ORGANI2_A11OrganisationId ;
      private bool[] TRN_ORGANI2_n11OrganisationId ;
      private string[] TRN_ORGANI2_A40011OrganisationLogo_GXI ;
      private Guid[] TRN_ORGANI2_A273Trn_ThemeId ;
      private string[] TRN_ORGANI2_A506OrganisationLogo ;
      private bool[] TRN_ORGANI2_n506OrganisationLogo ;
      private Guid[] TRN_ORGANI3_A11OrganisationId ;
      private bool[] TRN_ORGANI3_n11OrganisationId ;
   }

   public class trn_organisationupdatereferentialintegrity__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTRN_ORGANI2;
          prmTRN_ORGANI2 = new Object[] {
          };
          Object[] prmTRN_ORGANI3;
          prmTRN_ORGANI3 = new Object[] {
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmTRN_ORGANI4;
          prmTRN_ORGANI4 = new Object[] {
          new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("OrganisationKvkNumber",GXType.VarChar,8,0) ,
          new ParDef("OrganisationName",GXType.VarChar,100,0) ,
          new ParDef("OrganisationEmail",GXType.VarChar,100,0) ,
          new ParDef("OrganisationPhone",GXType.Char,20,0) ,
          new ParDef("OrganisationVATNumber",GXType.VarChar,14,0) ,
          new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("OrganisationAddressZipCode",GXType.VarChar,100,0) ,
          new ParDef("OrganisationAddressCity",GXType.VarChar,100,0) ,
          new ParDef("OrganisationAddressCountry",GXType.VarChar,100,0) ,
          new ParDef("OrganisationAddressLine1",GXType.VarChar,100,0) ,
          new ParDef("OrganisationAddressLine2",GXType.VarChar,100,0) ,
          new ParDef("OrganisationPhoneCode",GXType.VarChar,40,0) ,
          new ParDef("OrganisationPhoneNumber",GXType.VarChar,9,0) ,
          new ParDef("OrganisationLogo",GXType.Byte,1024,0){InDB=false} ,
          new ParDef("OrganisationLogo_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=14, Tbl="Trn_Organisation", Fld="OrganisationLogo"}
          };
          def= new CursorDef[] {
              new CursorDef("TRN_ORGANI2", "SELECT T1.OrganisationId, T2.OrganisationLogo_GXI, T1.Trn_ThemeId, T2.OrganisationLogo FROM (Trn_Theme T1 LEFT JOIN Trn_Organisation T2 ON T2.OrganisationId = T1.OrganisationId) ORDER BY T1.Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_ORGANI2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_ORGANI3", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_ORGANI3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_ORGANI4", "INSERT INTO Trn_Organisation(OrganisationId, OrganisationKvkNumber, OrganisationName, OrganisationEmail, OrganisationPhone, OrganisationVATNumber, OrganisationTypeId, OrganisationAddressZipCode, OrganisationAddressCity, OrganisationAddressCountry, OrganisationAddressLine1, OrganisationAddressLine2, OrganisationPhoneCode, OrganisationPhoneNumber, OrganisationLogo, OrganisationLogo_GXI) VALUES(:OrganisationId, :OrganisationKvkNumber, :OrganisationName, :OrganisationEmail, :OrganisationPhone, :OrganisationVATNumber, :OrganisationTypeId, :OrganisationAddressZipCode, :OrganisationAddressCity, :OrganisationAddressCountry, :OrganisationAddressLine1, :OrganisationAddressLine2, :OrganisationPhoneCode, :OrganisationPhoneNumber, :OrganisationLogo, :OrganisationLogo_GXI)", GxErrorMask.GX_NOMASK,prmTRN_ORGANI4)
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
