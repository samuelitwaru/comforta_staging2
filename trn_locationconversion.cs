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
            A584ActiveAppVersionId = TRN_LOCATI2_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = TRN_LOCATI2_n584ActiveAppVersionId[0];
            A576LocationThemeId = TRN_LOCATI2_A576LocationThemeId[0];
            n576LocationThemeId = TRN_LOCATI2_n576LocationThemeId[0];
            A575ReceptionDescription = TRN_LOCATI2_A575ReceptionDescription[0];
            n575ReceptionDescription = TRN_LOCATI2_n575ReceptionDescription[0];
            A573LocationHasOwnBrand = TRN_LOCATI2_A573LocationHasOwnBrand[0];
            A572LocationHasMyLiving = TRN_LOCATI2_A572LocationHasMyLiving[0];
            A571LocationHasMyServices = TRN_LOCATI2_A571LocationHasMyServices[0];
            A570LocationHasMyCare = TRN_LOCATI2_A570LocationHasMyCare[0];
            A569LocationCtaTheme = TRN_LOCATI2_A569LocationCtaTheme[0];
            n569LocationCtaTheme = TRN_LOCATI2_n569LocationCtaTheme[0];
            A568LocationBrandTheme = TRN_LOCATI2_A568LocationBrandTheme[0];
            n568LocationBrandTheme = TRN_LOCATI2_n568LocationBrandTheme[0];
            A504ToolBoxDefaultProfileImage = TRN_LOCATI2_A504ToolBoxDefaultProfileImage[0];
            n504ToolBoxDefaultProfileImage = TRN_LOCATI2_n504ToolBoxDefaultProfileImage[0];
            A503ToolBoxDefaultLogo = TRN_LOCATI2_A503ToolBoxDefaultLogo[0];
            n503ToolBoxDefaultLogo = TRN_LOCATI2_n503ToolBoxDefaultLogo[0];
            A356LocationPhoneNumber = TRN_LOCATI2_A356LocationPhoneNumber[0];
            A355LocationPhoneCode = TRN_LOCATI2_A355LocationPhoneCode[0];
            A331LocationAddressLine2 = TRN_LOCATI2_A331LocationAddressLine2[0];
            A330LocationAddressLine1 = TRN_LOCATI2_A330LocationAddressLine1[0];
            A329LocationZipCode = TRN_LOCATI2_A329LocationZipCode[0];
            A328LocationCity = TRN_LOCATI2_A328LocationCity[0];
            A327LocationCountry = TRN_LOCATI2_A327LocationCountry[0];
            A273Trn_ThemeId = TRN_LOCATI2_A273Trn_ThemeId[0];
            n273Trn_ThemeId = TRN_LOCATI2_n273Trn_ThemeId[0];
            A36LocationDescription = TRN_LOCATI2_A36LocationDescription[0];
            A35LocationPhone = TRN_LOCATI2_A35LocationPhone[0];
            A34LocationEmail = TRN_LOCATI2_A34LocationEmail[0];
            A31LocationName = TRN_LOCATI2_A31LocationName[0];
            A11OrganisationId = TRN_LOCATI2_A11OrganisationId[0];
            A29LocationId = TRN_LOCATI2_A29LocationId[0];
            A40001ReceptionImage_GXI = TRN_LOCATI2_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = TRN_LOCATI2_n40001ReceptionImage_GXI[0];
            A40000LocationImage_GXI = TRN_LOCATI2_A40000LocationImage_GXI[0];
            A574ReceptionImage = TRN_LOCATI2_A574ReceptionImage[0];
            n574ReceptionImage = TRN_LOCATI2_n574ReceptionImage[0];
            A494LocationImage = TRN_LOCATI2_A494LocationImage[0];
            /*
               INSERT RECORD ON TABLE GXA0103

            */
            AV2LocationId = A29LocationId;
            AV3OrganisationId = A11OrganisationId;
            AV4LocationName = A31LocationName;
            AV5LocationEmail = A34LocationEmail;
            AV6LocationPhone = A35LocationPhone;
            AV7LocationDescription = A36LocationDescription;
            if ( TRN_LOCATI2_n273Trn_ThemeId[0] )
            {
               AV8Trn_ThemeId = Guid.Empty;
               nV8Trn_ThemeId = false;
               nV8Trn_ThemeId = true;
            }
            else
            {
               AV8Trn_ThemeId = A273Trn_ThemeId;
               nV8Trn_ThemeId = false;
            }
            AV9LocationCountry = A327LocationCountry;
            AV10LocationCity = A328LocationCity;
            AV11LocationZipCode = A329LocationZipCode;
            AV12LocationAddressLine1 = A330LocationAddressLine1;
            AV13LocationAddressLine2 = A331LocationAddressLine2;
            AV14LocationPhoneCode = A355LocationPhoneCode;
            AV15LocationPhoneNumber = A356LocationPhoneNumber;
            AV16LocationImage = A494LocationImage;
            AV17LocationImage_GXI = A40000LocationImage_GXI;
            AV17LocationImage_GXI = A40000LocationImage_GXI;
            if ( TRN_LOCATI2_n503ToolBoxDefaultLogo[0] )
            {
               AV18ToolBoxDefaultLogo = "";
               nV18ToolBoxDefaultLogo = false;
               nV18ToolBoxDefaultLogo = true;
            }
            else
            {
               AV18ToolBoxDefaultLogo = A503ToolBoxDefaultLogo;
               nV18ToolBoxDefaultLogo = false;
            }
            if ( TRN_LOCATI2_n504ToolBoxDefaultProfileImage[0] )
            {
               AV19ToolBoxDefaultProfileImage = "";
               nV19ToolBoxDefaultProfileImage = false;
               nV19ToolBoxDefaultProfileImage = true;
            }
            else
            {
               AV19ToolBoxDefaultProfileImage = A504ToolBoxDefaultProfileImage;
               nV19ToolBoxDefaultProfileImage = false;
            }
            if ( TRN_LOCATI2_n568LocationBrandTheme[0] )
            {
               AV20LocationBrandTheme = "";
               nV20LocationBrandTheme = false;
               nV20LocationBrandTheme = true;
            }
            else
            {
               AV20LocationBrandTheme = A568LocationBrandTheme;
               nV20LocationBrandTheme = false;
            }
            if ( TRN_LOCATI2_n569LocationCtaTheme[0] )
            {
               AV21LocationCtaTheme = "";
               nV21LocationCtaTheme = false;
               nV21LocationCtaTheme = true;
            }
            else
            {
               AV21LocationCtaTheme = A569LocationCtaTheme;
               nV21LocationCtaTheme = false;
            }
            AV22LocationHasMyCare = A570LocationHasMyCare;
            AV23LocationHasMyServices = A571LocationHasMyServices;
            AV24LocationHasMyLiving = A572LocationHasMyLiving;
            AV25LocationHasOwnBrand = A573LocationHasOwnBrand;
            if ( TRN_LOCATI2_n574ReceptionImage[0] )
            {
               AV26ReceptionImage = "";
               nV26ReceptionImage = false;
               nV26ReceptionImage = true;
            }
            else
            {
               AV26ReceptionImage = A574ReceptionImage;
               nV26ReceptionImage = false;
               AV27ReceptionImage_GXI = A40001ReceptionImage_GXI;
               nV27ReceptionImage_GXI = false;
            }
            if ( TRN_LOCATI2_n40001ReceptionImage_GXI[0] )
            {
               AV27ReceptionImage_GXI = "";
               nV27ReceptionImage_GXI = false;
               nV27ReceptionImage_GXI = true;
            }
            else
            {
               AV27ReceptionImage_GXI = A40001ReceptionImage_GXI;
               nV27ReceptionImage_GXI = false;
            }
            if ( TRN_LOCATI2_n575ReceptionDescription[0] )
            {
               AV28ReceptionDescription = "";
               nV28ReceptionDescription = false;
               nV28ReceptionDescription = true;
            }
            else
            {
               AV28ReceptionDescription = A575ReceptionDescription;
               nV28ReceptionDescription = false;
            }
            if ( TRN_LOCATI2_n576LocationThemeId[0] )
            {
               AV29LocationThemeId = Guid.Empty;
               nV29LocationThemeId = false;
               nV29LocationThemeId = true;
            }
            else
            {
               AV29LocationThemeId = A576LocationThemeId;
               nV29LocationThemeId = false;
            }
            if ( TRN_LOCATI2_n584ActiveAppVersionId[0] )
            {
               AV30ActiveAppVersionId = Guid.Empty;
               nV30ActiveAppVersionId = false;
               nV30ActiveAppVersionId = true;
            }
            else
            {
               AV30ActiveAppVersionId = A584ActiveAppVersionId;
               nV30ActiveAppVersionId = false;
            }
            if ( (Guid.Empty==A523AppVersionId) )
            {
               AV31PublishedActiveAppVersionId = Guid.Empty;
               nV31PublishedActiveAppVersionId = false;
               nV31PublishedActiveAppVersionId = true;
            }
            else
            {
               AV31PublishedActiveAppVersionId = A523AppVersionId;
               nV31PublishedActiveAppVersionId = false;
            }
            /* Using cursor TRN_LOCATI3 */
            pr_default.execute(1, new Object[] {AV2LocationId, AV3OrganisationId, AV4LocationName, AV5LocationEmail, AV6LocationPhone, AV7LocationDescription, nV8Trn_ThemeId, AV8Trn_ThemeId, AV9LocationCountry, AV10LocationCity, AV11LocationZipCode, AV12LocationAddressLine1, AV13LocationAddressLine2, AV14LocationPhoneCode, AV15LocationPhoneNumber, AV16LocationImage, AV17LocationImage_GXI, nV18ToolBoxDefaultLogo, AV18ToolBoxDefaultLogo, nV19ToolBoxDefaultProfileImage, AV19ToolBoxDefaultProfileImage, nV20LocationBrandTheme, AV20LocationBrandTheme, nV21LocationCtaTheme, AV21LocationCtaTheme, AV22LocationHasMyCare, AV23LocationHasMyServices, AV24LocationHasMyLiving, AV25LocationHasOwnBrand, nV26ReceptionImage, AV26ReceptionImage, nV27ReceptionImage_GXI, AV27ReceptionImage_GXI, nV28ReceptionDescription, AV28ReceptionDescription, nV29LocationThemeId, AV29LocationThemeId, nV30ActiveAppVersionId, AV30ActiveAppVersionId, nV31PublishedActiveAppVersionId, AV31PublishedActiveAppVersionId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0103");
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
         TRN_LOCATI2_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_n584ActiveAppVersionId = new bool[] {false} ;
         TRN_LOCATI2_A576LocationThemeId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_n576LocationThemeId = new bool[] {false} ;
         TRN_LOCATI2_A575ReceptionDescription = new string[] {""} ;
         TRN_LOCATI2_n575ReceptionDescription = new bool[] {false} ;
         TRN_LOCATI2_A573LocationHasOwnBrand = new bool[] {false} ;
         TRN_LOCATI2_A572LocationHasMyLiving = new bool[] {false} ;
         TRN_LOCATI2_A571LocationHasMyServices = new bool[] {false} ;
         TRN_LOCATI2_A570LocationHasMyCare = new bool[] {false} ;
         TRN_LOCATI2_A569LocationCtaTheme = new string[] {""} ;
         TRN_LOCATI2_n569LocationCtaTheme = new bool[] {false} ;
         TRN_LOCATI2_A568LocationBrandTheme = new string[] {""} ;
         TRN_LOCATI2_n568LocationBrandTheme = new bool[] {false} ;
         TRN_LOCATI2_A504ToolBoxDefaultProfileImage = new string[] {""} ;
         TRN_LOCATI2_n504ToolBoxDefaultProfileImage = new bool[] {false} ;
         TRN_LOCATI2_A503ToolBoxDefaultLogo = new string[] {""} ;
         TRN_LOCATI2_n503ToolBoxDefaultLogo = new bool[] {false} ;
         TRN_LOCATI2_A356LocationPhoneNumber = new string[] {""} ;
         TRN_LOCATI2_A355LocationPhoneCode = new string[] {""} ;
         TRN_LOCATI2_A331LocationAddressLine2 = new string[] {""} ;
         TRN_LOCATI2_A330LocationAddressLine1 = new string[] {""} ;
         TRN_LOCATI2_A329LocationZipCode = new string[] {""} ;
         TRN_LOCATI2_A328LocationCity = new string[] {""} ;
         TRN_LOCATI2_A327LocationCountry = new string[] {""} ;
         TRN_LOCATI2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_n273Trn_ThemeId = new bool[] {false} ;
         TRN_LOCATI2_A36LocationDescription = new string[] {""} ;
         TRN_LOCATI2_A35LocationPhone = new string[] {""} ;
         TRN_LOCATI2_A34LocationEmail = new string[] {""} ;
         TRN_LOCATI2_A31LocationName = new string[] {""} ;
         TRN_LOCATI2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_A29LocationId = new Guid[] {Guid.Empty} ;
         TRN_LOCATI2_A40001ReceptionImage_GXI = new string[] {""} ;
         TRN_LOCATI2_n40001ReceptionImage_GXI = new bool[] {false} ;
         TRN_LOCATI2_A40000LocationImage_GXI = new string[] {""} ;
         TRN_LOCATI2_A574ReceptionImage = new string[] {""} ;
         TRN_LOCATI2_n574ReceptionImage = new bool[] {false} ;
         TRN_LOCATI2_A494LocationImage = new string[] {""} ;
         A584ActiveAppVersionId = Guid.Empty;
         A576LocationThemeId = Guid.Empty;
         A575ReceptionDescription = "";
         A569LocationCtaTheme = "";
         A568LocationBrandTheme = "";
         A504ToolBoxDefaultProfileImage = "";
         A503ToolBoxDefaultLogo = "";
         A356LocationPhoneNumber = "";
         A355LocationPhoneCode = "";
         A331LocationAddressLine2 = "";
         A330LocationAddressLine1 = "";
         A329LocationZipCode = "";
         A328LocationCity = "";
         A327LocationCountry = "";
         A273Trn_ThemeId = Guid.Empty;
         A36LocationDescription = "";
         A35LocationPhone = "";
         A34LocationEmail = "";
         A31LocationName = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A40001ReceptionImage_GXI = "";
         A40000LocationImage_GXI = "";
         A574ReceptionImage = "";
         A494LocationImage = "";
         AV2LocationId = Guid.Empty;
         AV3OrganisationId = Guid.Empty;
         AV4LocationName = "";
         AV5LocationEmail = "";
         AV6LocationPhone = "";
         AV7LocationDescription = "";
         AV8Trn_ThemeId = Guid.Empty;
         AV9LocationCountry = "";
         AV10LocationCity = "";
         AV11LocationZipCode = "";
         AV12LocationAddressLine1 = "";
         AV13LocationAddressLine2 = "";
         AV14LocationPhoneCode = "";
         AV15LocationPhoneNumber = "";
         AV16LocationImage = "";
         AV17LocationImage_GXI = "";
         AV18ToolBoxDefaultLogo = "";
         AV19ToolBoxDefaultProfileImage = "";
         AV20LocationBrandTheme = "";
         AV21LocationCtaTheme = "";
         AV26ReceptionImage = "";
         AV27ReceptionImage_GXI = "";
         AV28ReceptionDescription = "";
         AV29LocationThemeId = Guid.Empty;
         AV30ActiveAppVersionId = Guid.Empty;
         A523AppVersionId = Guid.Empty;
         AV31PublishedActiveAppVersionId = Guid.Empty;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationconversion__default(),
            new Object[][] {
                new Object[] {
               TRN_LOCATI2_A584ActiveAppVersionId, TRN_LOCATI2_n584ActiveAppVersionId, TRN_LOCATI2_A576LocationThemeId, TRN_LOCATI2_n576LocationThemeId, TRN_LOCATI2_A575ReceptionDescription, TRN_LOCATI2_n575ReceptionDescription, TRN_LOCATI2_A573LocationHasOwnBrand, TRN_LOCATI2_A572LocationHasMyLiving, TRN_LOCATI2_A571LocationHasMyServices, TRN_LOCATI2_A570LocationHasMyCare,
               TRN_LOCATI2_A569LocationCtaTheme, TRN_LOCATI2_n569LocationCtaTheme, TRN_LOCATI2_A568LocationBrandTheme, TRN_LOCATI2_n568LocationBrandTheme, TRN_LOCATI2_A504ToolBoxDefaultProfileImage, TRN_LOCATI2_n504ToolBoxDefaultProfileImage, TRN_LOCATI2_A503ToolBoxDefaultLogo, TRN_LOCATI2_n503ToolBoxDefaultLogo, TRN_LOCATI2_A356LocationPhoneNumber, TRN_LOCATI2_A355LocationPhoneCode,
               TRN_LOCATI2_A331LocationAddressLine2, TRN_LOCATI2_A330LocationAddressLine1, TRN_LOCATI2_A329LocationZipCode, TRN_LOCATI2_A328LocationCity, TRN_LOCATI2_A327LocationCountry, TRN_LOCATI2_A273Trn_ThemeId, TRN_LOCATI2_n273Trn_ThemeId, TRN_LOCATI2_A36LocationDescription, TRN_LOCATI2_A35LocationPhone, TRN_LOCATI2_A34LocationEmail,
               TRN_LOCATI2_A31LocationName, TRN_LOCATI2_A11OrganisationId, TRN_LOCATI2_A29LocationId, TRN_LOCATI2_A40001ReceptionImage_GXI, TRN_LOCATI2_n40001ReceptionImage_GXI, TRN_LOCATI2_A40000LocationImage_GXI, TRN_LOCATI2_A574ReceptionImage, TRN_LOCATI2_n574ReceptionImage, TRN_LOCATI2_A494LocationImage
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0103 ;
      private string A35LocationPhone ;
      private string AV6LocationPhone ;
      private string Gx_emsg ;
      private bool n584ActiveAppVersionId ;
      private bool n576LocationThemeId ;
      private bool n575ReceptionDescription ;
      private bool A573LocationHasOwnBrand ;
      private bool A572LocationHasMyLiving ;
      private bool A571LocationHasMyServices ;
      private bool A570LocationHasMyCare ;
      private bool n569LocationCtaTheme ;
      private bool n568LocationBrandTheme ;
      private bool n504ToolBoxDefaultProfileImage ;
      private bool n503ToolBoxDefaultLogo ;
      private bool n273Trn_ThemeId ;
      private bool n40001ReceptionImage_GXI ;
      private bool n574ReceptionImage ;
      private bool nV8Trn_ThemeId ;
      private bool nV18ToolBoxDefaultLogo ;
      private bool nV19ToolBoxDefaultProfileImage ;
      private bool nV20LocationBrandTheme ;
      private bool nV21LocationCtaTheme ;
      private bool AV22LocationHasMyCare ;
      private bool AV23LocationHasMyServices ;
      private bool AV24LocationHasMyLiving ;
      private bool AV25LocationHasOwnBrand ;
      private bool nV26ReceptionImage ;
      private bool nV27ReceptionImage_GXI ;
      private bool nV28ReceptionDescription ;
      private bool nV29LocationThemeId ;
      private bool nV30ActiveAppVersionId ;
      private bool nV31PublishedActiveAppVersionId ;
      private string A569LocationCtaTheme ;
      private string A568LocationBrandTheme ;
      private string A36LocationDescription ;
      private string AV7LocationDescription ;
      private string AV20LocationBrandTheme ;
      private string AV21LocationCtaTheme ;
      private string A575ReceptionDescription ;
      private string A504ToolBoxDefaultProfileImage ;
      private string A503ToolBoxDefaultLogo ;
      private string A356LocationPhoneNumber ;
      private string A355LocationPhoneCode ;
      private string A331LocationAddressLine2 ;
      private string A330LocationAddressLine1 ;
      private string A329LocationZipCode ;
      private string A328LocationCity ;
      private string A327LocationCountry ;
      private string A34LocationEmail ;
      private string A31LocationName ;
      private string A40001ReceptionImage_GXI ;
      private string A40000LocationImage_GXI ;
      private string AV4LocationName ;
      private string AV5LocationEmail ;
      private string AV9LocationCountry ;
      private string AV10LocationCity ;
      private string AV11LocationZipCode ;
      private string AV12LocationAddressLine1 ;
      private string AV13LocationAddressLine2 ;
      private string AV14LocationPhoneCode ;
      private string AV15LocationPhoneNumber ;
      private string AV17LocationImage_GXI ;
      private string AV18ToolBoxDefaultLogo ;
      private string AV19ToolBoxDefaultProfileImage ;
      private string AV27ReceptionImage_GXI ;
      private string AV28ReceptionDescription ;
      private string A574ReceptionImage ;
      private string A494LocationImage ;
      private string AV16LocationImage ;
      private string AV26ReceptionImage ;
      private Guid A584ActiveAppVersionId ;
      private Guid A576LocationThemeId ;
      private Guid A273Trn_ThemeId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid AV2LocationId ;
      private Guid AV3OrganisationId ;
      private Guid AV8Trn_ThemeId ;
      private Guid AV29LocationThemeId ;
      private Guid AV30ActiveAppVersionId ;
      private Guid A523AppVersionId ;
      private Guid AV31PublishedActiveAppVersionId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TRN_LOCATI2_A584ActiveAppVersionId ;
      private bool[] TRN_LOCATI2_n584ActiveAppVersionId ;
      private Guid[] TRN_LOCATI2_A576LocationThemeId ;
      private bool[] TRN_LOCATI2_n576LocationThemeId ;
      private string[] TRN_LOCATI2_A575ReceptionDescription ;
      private bool[] TRN_LOCATI2_n575ReceptionDescription ;
      private bool[] TRN_LOCATI2_A573LocationHasOwnBrand ;
      private bool[] TRN_LOCATI2_A572LocationHasMyLiving ;
      private bool[] TRN_LOCATI2_A571LocationHasMyServices ;
      private bool[] TRN_LOCATI2_A570LocationHasMyCare ;
      private string[] TRN_LOCATI2_A569LocationCtaTheme ;
      private bool[] TRN_LOCATI2_n569LocationCtaTheme ;
      private string[] TRN_LOCATI2_A568LocationBrandTheme ;
      private bool[] TRN_LOCATI2_n568LocationBrandTheme ;
      private string[] TRN_LOCATI2_A504ToolBoxDefaultProfileImage ;
      private bool[] TRN_LOCATI2_n504ToolBoxDefaultProfileImage ;
      private string[] TRN_LOCATI2_A503ToolBoxDefaultLogo ;
      private bool[] TRN_LOCATI2_n503ToolBoxDefaultLogo ;
      private string[] TRN_LOCATI2_A356LocationPhoneNumber ;
      private string[] TRN_LOCATI2_A355LocationPhoneCode ;
      private string[] TRN_LOCATI2_A331LocationAddressLine2 ;
      private string[] TRN_LOCATI2_A330LocationAddressLine1 ;
      private string[] TRN_LOCATI2_A329LocationZipCode ;
      private string[] TRN_LOCATI2_A328LocationCity ;
      private string[] TRN_LOCATI2_A327LocationCountry ;
      private Guid[] TRN_LOCATI2_A273Trn_ThemeId ;
      private bool[] TRN_LOCATI2_n273Trn_ThemeId ;
      private string[] TRN_LOCATI2_A36LocationDescription ;
      private string[] TRN_LOCATI2_A35LocationPhone ;
      private string[] TRN_LOCATI2_A34LocationEmail ;
      private string[] TRN_LOCATI2_A31LocationName ;
      private Guid[] TRN_LOCATI2_A11OrganisationId ;
      private Guid[] TRN_LOCATI2_A29LocationId ;
      private string[] TRN_LOCATI2_A40001ReceptionImage_GXI ;
      private bool[] TRN_LOCATI2_n40001ReceptionImage_GXI ;
      private string[] TRN_LOCATI2_A40000LocationImage_GXI ;
      private string[] TRN_LOCATI2_A574ReceptionImage ;
      private bool[] TRN_LOCATI2_n574ReceptionImage ;
      private string[] TRN_LOCATI2_A494LocationImage ;
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
          new ParDef("AV2LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV4LocationName",GXType.VarChar,100,0) ,
          new ParDef("AV5LocationEmail",GXType.VarChar,100,0) ,
          new ParDef("AV6LocationPhone",GXType.Char,20,0) ,
          new ParDef("AV7LocationDescription",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV8Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV9LocationCountry",GXType.VarChar,100,0) ,
          new ParDef("AV10LocationCity",GXType.VarChar,100,0) ,
          new ParDef("AV11LocationZipCode",GXType.VarChar,100,0) ,
          new ParDef("AV12LocationAddressLine1",GXType.VarChar,100,0) ,
          new ParDef("AV13LocationAddressLine2",GXType.VarChar,100,0) ,
          new ParDef("AV14LocationPhoneCode",GXType.VarChar,40,0) ,
          new ParDef("AV15LocationPhoneNumber",GXType.VarChar,9,0) ,
          new ParDef("AV16LocationImage",GXType.Byte,1024,0){InDB=false} ,
          new ParDef("AV17LocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=14, Tbl="GXA0103", Fld="LocationImage"} ,
          new ParDef("AV18ToolBoxDefaultLogo",GXType.VarChar,200,0){Nullable=true} ,
          new ParDef("AV19ToolBoxDefaultProfileImage",GXType.VarChar,200,0){Nullable=true} ,
          new ParDef("AV20LocationBrandTheme",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("AV21LocationCtaTheme",GXType.LongVarChar,1000,0){Nullable=true} ,
          new ParDef("AV22LocationHasMyCare",GXType.Boolean,4,0) ,
          new ParDef("AV23LocationHasMyServices",GXType.Boolean,4,0) ,
          new ParDef("AV24LocationHasMyLiving",GXType.Boolean,4,0) ,
          new ParDef("AV25LocationHasOwnBrand",GXType.Boolean,4,0) ,
          new ParDef("AV26ReceptionImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
          new ParDef("AV27ReceptionImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=24, Tbl="GXA0103", Fld="ReceptionImage"} ,
          new ParDef("AV28ReceptionDescription",GXType.VarChar,200,0){Nullable=true} ,
          new ParDef("AV29LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV30ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV31PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TRN_LOCATI2", "SELECT ActiveAppVersionId, LocationThemeId, ReceptionDescription, LocationHasOwnBrand, LocationHasMyLiving, LocationHasMyServices, LocationHasMyCare, LocationCtaTheme, LocationBrandTheme, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, LocationPhoneNumber, LocationPhoneCode, LocationAddressLine2, LocationAddressLine1, LocationZipCode, LocationCity, LocationCountry, Trn_ThemeId, LocationDescription, LocationPhone, LocationEmail, LocationName, OrganisationId, LocationId, ReceptionImage_GXI, LocationImage_GXI, ReceptionImage, LocationImage FROM Trn_Location ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRN_LOCATI2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRN_LOCATI3", "INSERT INTO GXA0103(LocationId, OrganisationId, LocationName, LocationEmail, LocationPhone, LocationDescription, Trn_ThemeId, LocationCountry, LocationCity, LocationZipCode, LocationAddressLine1, LocationAddressLine2, LocationPhoneCode, LocationPhoneNumber, LocationImage, LocationImage_GXI, ToolBoxDefaultLogo, ToolBoxDefaultProfileImage, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ReceptionImage, ReceptionImage_GXI, ReceptionDescription, LocationThemeId, ActiveAppVersionId, PublishedActiveAppVersionId) VALUES(:AV2LocationId, :AV3OrganisationId, :AV4LocationName, :AV5LocationEmail, :AV6LocationPhone, :AV7LocationDescription, :AV8Trn_ThemeId, :AV9LocationCountry, :AV10LocationCity, :AV11LocationZipCode, :AV12LocationAddressLine1, :AV13LocationAddressLine2, :AV14LocationPhoneCode, :AV15LocationPhoneNumber, :AV16LocationImage, :AV17LocationImage_GXI, :AV18ToolBoxDefaultLogo, :AV19ToolBoxDefaultProfileImage, :AV20LocationBrandTheme, :AV21LocationCtaTheme, :AV22LocationHasMyCare, :AV23LocationHasMyServices, :AV24LocationHasMyLiving, :AV25LocationHasOwnBrand, :AV26ReceptionImage, :AV27ReceptionImage_GXI, :AV28ReceptionDescription, :AV29LocationThemeId, :AV30ActiveAppVersionId, :AV31PublishedActiveAppVersionId)", GxErrorMask.GX_NOMASK,prmTRN_LOCATI3)
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((string[]) buf[14])[0] = rslt.getVarchar(10);
                ((bool[]) buf[15])[0] = rslt.wasNull(10);
                ((string[]) buf[16])[0] = rslt.getVarchar(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((string[]) buf[18])[0] = rslt.getVarchar(12);
                ((string[]) buf[19])[0] = rslt.getVarchar(13);
                ((string[]) buf[20])[0] = rslt.getVarchar(14);
                ((string[]) buf[21])[0] = rslt.getVarchar(15);
                ((string[]) buf[22])[0] = rslt.getVarchar(16);
                ((string[]) buf[23])[0] = rslt.getVarchar(17);
                ((string[]) buf[24])[0] = rslt.getVarchar(18);
                ((Guid[]) buf[25])[0] = rslt.getGuid(19);
                ((bool[]) buf[26])[0] = rslt.wasNull(19);
                ((string[]) buf[27])[0] = rslt.getLongVarchar(20);
                ((string[]) buf[28])[0] = rslt.getString(21, 20);
                ((string[]) buf[29])[0] = rslt.getVarchar(22);
                ((string[]) buf[30])[0] = rslt.getVarchar(23);
                ((Guid[]) buf[31])[0] = rslt.getGuid(24);
                ((Guid[]) buf[32])[0] = rslt.getGuid(25);
                ((string[]) buf[33])[0] = rslt.getMultimediaUri(26);
                ((bool[]) buf[34])[0] = rslt.wasNull(26);
                ((string[]) buf[35])[0] = rslt.getMultimediaUri(27);
                ((string[]) buf[36])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(26));
                ((bool[]) buf[37])[0] = rslt.wasNull(28);
                ((string[]) buf[38])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(27));
                return;
       }
    }

 }

}
