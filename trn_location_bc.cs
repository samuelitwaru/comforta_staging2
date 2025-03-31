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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_location_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_location_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_location_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow046( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey046( ) ;
         standaloneModal( ) ;
         AddRow046( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_040( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls046( ) ;
            }
            else
            {
               CheckExtendedTable046( ) ;
               if ( AnyError == 0 )
               {
                  ZM046( 24) ;
                  ZM046( 25) ;
                  ZM046( 26) ;
               }
               CloseExtendedTableCursors046( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12042( )
      {
         /* Start Routine */
         returnInSub = false;
         AV31ReceptionDescriptionVar = context.GetMessage( "Welkom bij de receptie van onze app. Hier kunt u al uw vragen stellen en krijgt u direct hulp van ons team. Of het nu gaat om technische ondersteuning, informatie over diensten, of algemene vragen, wij zijn er om u te helpen.", "");
         imgReceptionimagevar_gximage = "ReceptionImageFile";
         AV30ReceptionImageVar = context.GetImagePath( "7a779875-7e6f-4e4f-8ef6-6c9464d2a2f0", "", context.GetTheme( ));
         AV34Receptionimagevar_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7a779875-7e6f-4e4f-8ef6-6c9464d2a2f0", "", context.GetTheme( )), context);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV35Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV36GXV1 = 1;
            while ( AV36GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV26TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV36GXV1));
               if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "Trn_ThemeId") == 0 )
               {
                  AV25Insert_Trn_ThemeId = StringUtil.StrToGuid( AV26TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV26TrnContextAtt.gxTpr_Attributename, "LocationThemeId") == 0 )
               {
                  AV32Insert_LocationThemeId = StringUtil.StrToGuid( AV26TrnContextAtt.gxTpr_Attributevalue);
               }
               AV36GXV1 = (int)(AV36GXV1+1);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
         }
      }

      protected void E11042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Updated successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Deleted successfully", ""));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV13WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location Inserted successfully", ""));
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM046( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            Z35LocationPhone = A35LocationPhone;
            Z329LocationZipCode = A329LocationZipCode;
            Z31LocationName = A31LocationName;
            Z327LocationCountry = A327LocationCountry;
            Z328LocationCity = A328LocationCity;
            Z330LocationAddressLine1 = A330LocationAddressLine1;
            Z331LocationAddressLine2 = A331LocationAddressLine2;
            Z34LocationEmail = A34LocationEmail;
            Z355LocationPhoneCode = A355LocationPhoneCode;
            Z356LocationPhoneNumber = A356LocationPhoneNumber;
            Z570LocationHasMyCare = A570LocationHasMyCare;
            Z571LocationHasMyServices = A571LocationHasMyServices;
            Z572LocationHasMyLiving = A572LocationHasMyLiving;
            Z573LocationHasOwnBrand = A573LocationHasOwnBrand;
            Z504ToolBoxDefaultProfileImage = A504ToolBoxDefaultProfileImage;
            Z503ToolBoxDefaultLogo = A503ToolBoxDefaultLogo;
            Z575ReceptionDescription = A575ReceptionDescription;
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z576LocationThemeId = A576LocationThemeId;
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -23 )
         {
            Z29LocationId = A29LocationId;
            Z35LocationPhone = A35LocationPhone;
            Z329LocationZipCode = A329LocationZipCode;
            Z31LocationName = A31LocationName;
            Z494LocationImage = A494LocationImage;
            Z40000LocationImage_GXI = A40000LocationImage_GXI;
            Z327LocationCountry = A327LocationCountry;
            Z328LocationCity = A328LocationCity;
            Z330LocationAddressLine1 = A330LocationAddressLine1;
            Z331LocationAddressLine2 = A331LocationAddressLine2;
            Z34LocationEmail = A34LocationEmail;
            Z355LocationPhoneCode = A355LocationPhoneCode;
            Z356LocationPhoneNumber = A356LocationPhoneNumber;
            Z36LocationDescription = A36LocationDescription;
            Z568LocationBrandTheme = A568LocationBrandTheme;
            Z569LocationCtaTheme = A569LocationCtaTheme;
            Z570LocationHasMyCare = A570LocationHasMyCare;
            Z571LocationHasMyServices = A571LocationHasMyServices;
            Z572LocationHasMyLiving = A572LocationHasMyLiving;
            Z573LocationHasOwnBrand = A573LocationHasOwnBrand;
            Z504ToolBoxDefaultProfileImage = A504ToolBoxDefaultProfileImage;
            Z503ToolBoxDefaultLogo = A503ToolBoxDefaultLogo;
            Z574ReceptionImage = A574ReceptionImage;
            Z40001ReceptionImage_GXI = A40001ReceptionImage_GXI;
            Z575ReceptionDescription = A575ReceptionDescription;
            Z11OrganisationId = A11OrganisationId;
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z576LocationThemeId = A576LocationThemeId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV35Pgmname = "Trn_Location_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A29LocationId) )
         {
            A29LocationId = Guid.NewGuid( );
            n29LocationId = false;
         }
         if ( IsIns( )  && (false==A573LocationHasOwnBrand) && ( Gx_BScreen == 0 ) )
         {
            A573LocationHasOwnBrand = false;
         }
         if ( IsIns( )  && (false==A572LocationHasMyLiving) && ( Gx_BScreen == 0 ) )
         {
            A572LocationHasMyLiving = false;
         }
         if ( IsIns( )  && (false==A571LocationHasMyServices) && ( Gx_BScreen == 0 ) )
         {
            A571LocationHasMyServices = false;
         }
         if ( IsIns( )  && (false==A570LocationHasMyCare) && ( Gx_BScreen == 0 ) )
         {
            A570LocationHasMyCare = false;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A575ReceptionDescription)) && ( Gx_BScreen == 0 ) )
         {
            A575ReceptionDescription = AV31ReceptionDescriptionVar;
            n575ReceptionDescription = false;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A574ReceptionImage)) && ( Gx_BScreen == 0 ) )
         {
            A574ReceptionImage = AV30ReceptionImageVar;
            n574ReceptionImage = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load046( )
      {
         /* Using cursor BC00047 */
         pr_default.execute(5, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound6 = 1;
            A35LocationPhone = BC00047_A35LocationPhone[0];
            A329LocationZipCode = BC00047_A329LocationZipCode[0];
            A31LocationName = BC00047_A31LocationName[0];
            A40000LocationImage_GXI = BC00047_A40000LocationImage_GXI[0];
            A327LocationCountry = BC00047_A327LocationCountry[0];
            A328LocationCity = BC00047_A328LocationCity[0];
            A330LocationAddressLine1 = BC00047_A330LocationAddressLine1[0];
            A331LocationAddressLine2 = BC00047_A331LocationAddressLine2[0];
            A34LocationEmail = BC00047_A34LocationEmail[0];
            A355LocationPhoneCode = BC00047_A355LocationPhoneCode[0];
            A356LocationPhoneNumber = BC00047_A356LocationPhoneNumber[0];
            A36LocationDescription = BC00047_A36LocationDescription[0];
            A568LocationBrandTheme = BC00047_A568LocationBrandTheme[0];
            n568LocationBrandTheme = BC00047_n568LocationBrandTheme[0];
            A569LocationCtaTheme = BC00047_A569LocationCtaTheme[0];
            n569LocationCtaTheme = BC00047_n569LocationCtaTheme[0];
            A570LocationHasMyCare = BC00047_A570LocationHasMyCare[0];
            A571LocationHasMyServices = BC00047_A571LocationHasMyServices[0];
            A572LocationHasMyLiving = BC00047_A572LocationHasMyLiving[0];
            A573LocationHasOwnBrand = BC00047_A573LocationHasOwnBrand[0];
            A504ToolBoxDefaultProfileImage = BC00047_A504ToolBoxDefaultProfileImage[0];
            n504ToolBoxDefaultProfileImage = BC00047_n504ToolBoxDefaultProfileImage[0];
            A503ToolBoxDefaultLogo = BC00047_A503ToolBoxDefaultLogo[0];
            n503ToolBoxDefaultLogo = BC00047_n503ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = BC00047_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = BC00047_n40001ReceptionImage_GXI[0];
            A575ReceptionDescription = BC00047_A575ReceptionDescription[0];
            n575ReceptionDescription = BC00047_n575ReceptionDescription[0];
            A273Trn_ThemeId = BC00047_A273Trn_ThemeId[0];
            n273Trn_ThemeId = BC00047_n273Trn_ThemeId[0];
            A576LocationThemeId = BC00047_A576LocationThemeId[0];
            n576LocationThemeId = BC00047_n576LocationThemeId[0];
            A494LocationImage = BC00047_A494LocationImage[0];
            A574ReceptionImage = BC00047_A574ReceptionImage[0];
            n574ReceptionImage = BC00047_n574ReceptionImage[0];
            ZM046( -23) ;
         }
         pr_default.close(5);
         OnLoadActions046( ) ;
      }

      protected void OnLoadActions046( )
      {
         A329LocationZipCode = StringUtil.Upper( A329LocationZipCode);
         GXt_char1 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A355LocationPhoneCode,  A356LocationPhoneNumber, out  GXt_char1) ;
         A35LocationPhone = GXt_char1;
         if ( (Guid.Empty==A576LocationThemeId) )
         {
            A576LocationThemeId = Guid.Empty;
            n576LocationThemeId = false;
            n576LocationThemeId = true;
         }
         if ( (Guid.Empty==A273Trn_ThemeId) )
         {
            A273Trn_ThemeId = Guid.Empty;
            n273Trn_ThemeId = false;
            n273Trn_ThemeId = true;
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A273Trn_ThemeId) && ( Gx_BScreen == 0 ) )
            {
               GXt_guid2 = A273Trn_ThemeId;
               new prc_getdefaulttheme(context ).execute( out  GXt_guid2) ;
               A273Trn_ThemeId = GXt_guid2;
               n273Trn_ThemeId = false;
            }
         }
      }

      protected void CheckExtendedTable046( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         A329LocationZipCode = StringUtil.Upper( A329LocationZipCode);
         if ( ! GxRegex.IsMatch(A329LocationZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( A329LocationZipCode)) )
         {
            GX_msglist.addItem(context.GetMessage( "Zip Code is incorrect", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A34LocationEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Location Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A34LocationEmail)) && ! GxRegex.IsMatch(A34LocationEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Email format is invalid", ""), 1, "");
            AnyError = 1;
         }
         GXt_char1 = A35LocationPhone;
         new prc_concatenateintlphone(context ).execute(  A355LocationPhoneCode,  A356LocationPhoneNumber, out  GXt_char1) ;
         A35LocationPhone = GXt_char1;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A356LocationPhoneNumber)) && ! GxRegex.IsMatch(A356LocationPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone contains 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( (Guid.Empty==A576LocationThemeId) )
         {
            A576LocationThemeId = Guid.Empty;
            n576LocationThemeId = false;
            n576LocationThemeId = true;
         }
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {n576LocationThemeId, A576LocationThemeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A576LocationThemeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location Theme", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LOCATIONTHEMEID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
         if ( (Guid.Empty==A273Trn_ThemeId) )
         {
            A273Trn_ThemeId = Guid.Empty;
            n273Trn_ThemeId = false;
            n273Trn_ThemeId = true;
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A273Trn_ThemeId) && ( Gx_BScreen == 0 ) )
            {
               GXt_guid2 = A273Trn_ThemeId;
               new prc_getdefaulttheme(context ).execute( out  GXt_guid2) ;
               A273Trn_ThemeId = GXt_guid2;
               n273Trn_ThemeId = false;
            }
         }
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A273Trn_ThemeId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), "", "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_THEMEID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors046( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey046( )
      {
         /* Using cursor BC00048 */
         pr_default.execute(6, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM046( 23) ;
            RcdFound6 = 1;
            A29LocationId = BC00043_A29LocationId[0];
            n29LocationId = BC00043_n29LocationId[0];
            A35LocationPhone = BC00043_A35LocationPhone[0];
            A329LocationZipCode = BC00043_A329LocationZipCode[0];
            A31LocationName = BC00043_A31LocationName[0];
            A40000LocationImage_GXI = BC00043_A40000LocationImage_GXI[0];
            A327LocationCountry = BC00043_A327LocationCountry[0];
            A328LocationCity = BC00043_A328LocationCity[0];
            A330LocationAddressLine1 = BC00043_A330LocationAddressLine1[0];
            A331LocationAddressLine2 = BC00043_A331LocationAddressLine2[0];
            A34LocationEmail = BC00043_A34LocationEmail[0];
            A355LocationPhoneCode = BC00043_A355LocationPhoneCode[0];
            A356LocationPhoneNumber = BC00043_A356LocationPhoneNumber[0];
            A36LocationDescription = BC00043_A36LocationDescription[0];
            A568LocationBrandTheme = BC00043_A568LocationBrandTheme[0];
            n568LocationBrandTheme = BC00043_n568LocationBrandTheme[0];
            A569LocationCtaTheme = BC00043_A569LocationCtaTheme[0];
            n569LocationCtaTheme = BC00043_n569LocationCtaTheme[0];
            A570LocationHasMyCare = BC00043_A570LocationHasMyCare[0];
            A571LocationHasMyServices = BC00043_A571LocationHasMyServices[0];
            A572LocationHasMyLiving = BC00043_A572LocationHasMyLiving[0];
            A573LocationHasOwnBrand = BC00043_A573LocationHasOwnBrand[0];
            A504ToolBoxDefaultProfileImage = BC00043_A504ToolBoxDefaultProfileImage[0];
            n504ToolBoxDefaultProfileImage = BC00043_n504ToolBoxDefaultProfileImage[0];
            A503ToolBoxDefaultLogo = BC00043_A503ToolBoxDefaultLogo[0];
            n503ToolBoxDefaultLogo = BC00043_n503ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = BC00043_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = BC00043_n40001ReceptionImage_GXI[0];
            A575ReceptionDescription = BC00043_A575ReceptionDescription[0];
            n575ReceptionDescription = BC00043_n575ReceptionDescription[0];
            A11OrganisationId = BC00043_A11OrganisationId[0];
            n11OrganisationId = BC00043_n11OrganisationId[0];
            A273Trn_ThemeId = BC00043_A273Trn_ThemeId[0];
            n273Trn_ThemeId = BC00043_n273Trn_ThemeId[0];
            A576LocationThemeId = BC00043_A576LocationThemeId[0];
            n576LocationThemeId = BC00043_n576LocationThemeId[0];
            A494LocationImage = BC00043_A494LocationImage[0];
            A574ReceptionImage = BC00043_A574ReceptionImage[0];
            n574ReceptionImage = BC00043_n574ReceptionImage[0];
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load046( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey046( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey046( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey046( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_040( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency046( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Location"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z35LocationPhone, BC00042_A35LocationPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z329LocationZipCode, BC00042_A329LocationZipCode[0]) != 0 ) || ( StringUtil.StrCmp(Z31LocationName, BC00042_A31LocationName[0]) != 0 ) || ( StringUtil.StrCmp(Z327LocationCountry, BC00042_A327LocationCountry[0]) != 0 ) || ( StringUtil.StrCmp(Z328LocationCity, BC00042_A328LocationCity[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z330LocationAddressLine1, BC00042_A330LocationAddressLine1[0]) != 0 ) || ( StringUtil.StrCmp(Z331LocationAddressLine2, BC00042_A331LocationAddressLine2[0]) != 0 ) || ( StringUtil.StrCmp(Z34LocationEmail, BC00042_A34LocationEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z355LocationPhoneCode, BC00042_A355LocationPhoneCode[0]) != 0 ) || ( StringUtil.StrCmp(Z356LocationPhoneNumber, BC00042_A356LocationPhoneNumber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z570LocationHasMyCare != BC00042_A570LocationHasMyCare[0] ) || ( Z571LocationHasMyServices != BC00042_A571LocationHasMyServices[0] ) || ( Z572LocationHasMyLiving != BC00042_A572LocationHasMyLiving[0] ) || ( Z573LocationHasOwnBrand != BC00042_A573LocationHasOwnBrand[0] ) || ( StringUtil.StrCmp(Z504ToolBoxDefaultProfileImage, BC00042_A504ToolBoxDefaultProfileImage[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z503ToolBoxDefaultLogo, BC00042_A503ToolBoxDefaultLogo[0]) != 0 ) || ( StringUtil.StrCmp(Z575ReceptionDescription, BC00042_A575ReceptionDescription[0]) != 0 ) || ( Z273Trn_ThemeId != BC00042_A273Trn_ThemeId[0] ) || ( Z576LocationThemeId != BC00042_A576LocationThemeId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Location"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert046( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM046( 0) ;
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00049 */
                     pr_default.execute(7, new Object[] {n29LocationId, A29LocationId, A35LocationPhone, A329LocationZipCode, A31LocationName, A494LocationImage, A40000LocationImage_GXI, A327LocationCountry, A328LocationCity, A330LocationAddressLine1, A331LocationAddressLine2, A34LocationEmail, A355LocationPhoneCode, A356LocationPhoneNumber, A36LocationDescription, n568LocationBrandTheme, A568LocationBrandTheme, n569LocationCtaTheme, A569LocationCtaTheme, A570LocationHasMyCare, A571LocationHasMyServices, A572LocationHasMyLiving, A573LocationHasOwnBrand, n504ToolBoxDefaultProfileImage, A504ToolBoxDefaultProfileImage, n503ToolBoxDefaultLogo, A503ToolBoxDefaultLogo, n574ReceptionImage, A574ReceptionImage, n40001ReceptionImage_GXI, A40001ReceptionImage_GXI, n575ReceptionDescription, A575ReceptionDescription, n11OrganisationId, A11OrganisationId, n273Trn_ThemeId, A273Trn_ThemeId, n576LocationThemeId, A576LocationThemeId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
                     if ( (pr_default.getStatus(7) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load046( ) ;
            }
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void Update046( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000410 */
                     pr_default.execute(8, new Object[] {A35LocationPhone, A329LocationZipCode, A31LocationName, A327LocationCountry, A328LocationCity, A330LocationAddressLine1, A331LocationAddressLine2, A34LocationEmail, A355LocationPhoneCode, A356LocationPhoneNumber, A36LocationDescription, n568LocationBrandTheme, A568LocationBrandTheme, n569LocationCtaTheme, A569LocationCtaTheme, A570LocationHasMyCare, A571LocationHasMyServices, A572LocationHasMyLiving, A573LocationHasOwnBrand, n504ToolBoxDefaultProfileImage, A504ToolBoxDefaultProfileImage, n503ToolBoxDefaultLogo, A503ToolBoxDefaultLogo, n575ReceptionDescription, A575ReceptionDescription, n273Trn_ThemeId, A273Trn_ThemeId, n576LocationThemeId, A576LocationThemeId, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Location"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate046( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void DeferredUpdate046( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000411 */
            pr_default.execute(9, new Object[] {A494LocationImage, A40000LocationImage_GXI, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000412 */
            pr_default.execute(10, new Object[] {n574ReceptionImage, A574ReceptionImage, n40001ReceptionImage_GXI, A40001ReceptionImage_GXI, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls046( ) ;
            AfterConfirm046( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete046( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000413 */
                  pr_default.execute(11, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Location");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel046( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls046( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000414 */
            pr_default.execute(12, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_ResidentPackage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000415 */
            pr_default.execute(13, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_AppVersion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000416 */
            pr_default.execute(14, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agenda/Calendar", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC000417 */
            pr_default.execute(15, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Location Dynamic Forms", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC000418 */
            pr_default.execute(16, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Services", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC000419 */
            pr_default.execute(17, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Resident", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC000420 */
            pr_default.execute(18, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Receptionists", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel046( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete046( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart046( )
      {
         /* Scan By routine */
         /* Using cursor BC000421 */
         pr_default.execute(19, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound6 = 1;
            A29LocationId = BC000421_A29LocationId[0];
            n29LocationId = BC000421_n29LocationId[0];
            A35LocationPhone = BC000421_A35LocationPhone[0];
            A329LocationZipCode = BC000421_A329LocationZipCode[0];
            A31LocationName = BC000421_A31LocationName[0];
            A40000LocationImage_GXI = BC000421_A40000LocationImage_GXI[0];
            A327LocationCountry = BC000421_A327LocationCountry[0];
            A328LocationCity = BC000421_A328LocationCity[0];
            A330LocationAddressLine1 = BC000421_A330LocationAddressLine1[0];
            A331LocationAddressLine2 = BC000421_A331LocationAddressLine2[0];
            A34LocationEmail = BC000421_A34LocationEmail[0];
            A355LocationPhoneCode = BC000421_A355LocationPhoneCode[0];
            A356LocationPhoneNumber = BC000421_A356LocationPhoneNumber[0];
            A36LocationDescription = BC000421_A36LocationDescription[0];
            A568LocationBrandTheme = BC000421_A568LocationBrandTheme[0];
            n568LocationBrandTheme = BC000421_n568LocationBrandTheme[0];
            A569LocationCtaTheme = BC000421_A569LocationCtaTheme[0];
            n569LocationCtaTheme = BC000421_n569LocationCtaTheme[0];
            A570LocationHasMyCare = BC000421_A570LocationHasMyCare[0];
            A571LocationHasMyServices = BC000421_A571LocationHasMyServices[0];
            A572LocationHasMyLiving = BC000421_A572LocationHasMyLiving[0];
            A573LocationHasOwnBrand = BC000421_A573LocationHasOwnBrand[0];
            A504ToolBoxDefaultProfileImage = BC000421_A504ToolBoxDefaultProfileImage[0];
            n504ToolBoxDefaultProfileImage = BC000421_n504ToolBoxDefaultProfileImage[0];
            A503ToolBoxDefaultLogo = BC000421_A503ToolBoxDefaultLogo[0];
            n503ToolBoxDefaultLogo = BC000421_n503ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = BC000421_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = BC000421_n40001ReceptionImage_GXI[0];
            A575ReceptionDescription = BC000421_A575ReceptionDescription[0];
            n575ReceptionDescription = BC000421_n575ReceptionDescription[0];
            A11OrganisationId = BC000421_A11OrganisationId[0];
            n11OrganisationId = BC000421_n11OrganisationId[0];
            A273Trn_ThemeId = BC000421_A273Trn_ThemeId[0];
            n273Trn_ThemeId = BC000421_n273Trn_ThemeId[0];
            A576LocationThemeId = BC000421_A576LocationThemeId[0];
            n576LocationThemeId = BC000421_n576LocationThemeId[0];
            A494LocationImage = BC000421_A494LocationImage[0];
            A574ReceptionImage = BC000421_A574ReceptionImage[0];
            n574ReceptionImage = BC000421_n574ReceptionImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext046( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound6 = 0;
         ScanKeyLoad046( ) ;
      }

      protected void ScanKeyLoad046( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound6 = 1;
            A29LocationId = BC000421_A29LocationId[0];
            n29LocationId = BC000421_n29LocationId[0];
            A35LocationPhone = BC000421_A35LocationPhone[0];
            A329LocationZipCode = BC000421_A329LocationZipCode[0];
            A31LocationName = BC000421_A31LocationName[0];
            A40000LocationImage_GXI = BC000421_A40000LocationImage_GXI[0];
            A327LocationCountry = BC000421_A327LocationCountry[0];
            A328LocationCity = BC000421_A328LocationCity[0];
            A330LocationAddressLine1 = BC000421_A330LocationAddressLine1[0];
            A331LocationAddressLine2 = BC000421_A331LocationAddressLine2[0];
            A34LocationEmail = BC000421_A34LocationEmail[0];
            A355LocationPhoneCode = BC000421_A355LocationPhoneCode[0];
            A356LocationPhoneNumber = BC000421_A356LocationPhoneNumber[0];
            A36LocationDescription = BC000421_A36LocationDescription[0];
            A568LocationBrandTheme = BC000421_A568LocationBrandTheme[0];
            n568LocationBrandTheme = BC000421_n568LocationBrandTheme[0];
            A569LocationCtaTheme = BC000421_A569LocationCtaTheme[0];
            n569LocationCtaTheme = BC000421_n569LocationCtaTheme[0];
            A570LocationHasMyCare = BC000421_A570LocationHasMyCare[0];
            A571LocationHasMyServices = BC000421_A571LocationHasMyServices[0];
            A572LocationHasMyLiving = BC000421_A572LocationHasMyLiving[0];
            A573LocationHasOwnBrand = BC000421_A573LocationHasOwnBrand[0];
            A504ToolBoxDefaultProfileImage = BC000421_A504ToolBoxDefaultProfileImage[0];
            n504ToolBoxDefaultProfileImage = BC000421_n504ToolBoxDefaultProfileImage[0];
            A503ToolBoxDefaultLogo = BC000421_A503ToolBoxDefaultLogo[0];
            n503ToolBoxDefaultLogo = BC000421_n503ToolBoxDefaultLogo[0];
            A40001ReceptionImage_GXI = BC000421_A40001ReceptionImage_GXI[0];
            n40001ReceptionImage_GXI = BC000421_n40001ReceptionImage_GXI[0];
            A575ReceptionDescription = BC000421_A575ReceptionDescription[0];
            n575ReceptionDescription = BC000421_n575ReceptionDescription[0];
            A11OrganisationId = BC000421_A11OrganisationId[0];
            n11OrganisationId = BC000421_n11OrganisationId[0];
            A273Trn_ThemeId = BC000421_A273Trn_ThemeId[0];
            n273Trn_ThemeId = BC000421_n273Trn_ThemeId[0];
            A576LocationThemeId = BC000421_A576LocationThemeId[0];
            n576LocationThemeId = BC000421_n576LocationThemeId[0];
            A494LocationImage = BC000421_A494LocationImage[0];
            A574ReceptionImage = BC000421_A574ReceptionImage[0];
            n574ReceptionImage = BC000421_n574ReceptionImage[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd046( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm046( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert046( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate046( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete046( )
      {
         /* Before Delete Rules */
         new trn_deletelocationpages(context ).execute(  A29LocationId) ;
      }

      protected void BeforeComplete046( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate046( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes046( )
      {
      }

      protected void send_integrity_lvl_hashes046( )
      {
      }

      protected void AddRow046( )
      {
         VarsToRow6( bcTrn_Location) ;
      }

      protected void ReadRow046( )
      {
         RowToVars6( bcTrn_Location, 1) ;
      }

      protected void InitializeNonKey046( )
      {
         A35LocationPhone = "";
         A329LocationZipCode = "";
         A31LocationName = "";
         A494LocationImage = "";
         A40000LocationImage_GXI = "";
         A327LocationCountry = "";
         A328LocationCity = "";
         A330LocationAddressLine1 = "";
         A331LocationAddressLine2 = "";
         A34LocationEmail = "";
         A355LocationPhoneCode = "";
         A356LocationPhoneNumber = "";
         A36LocationDescription = "";
         A568LocationBrandTheme = "";
         n568LocationBrandTheme = false;
         A569LocationCtaTheme = "";
         n569LocationCtaTheme = false;
         A504ToolBoxDefaultProfileImage = "";
         n504ToolBoxDefaultProfileImage = false;
         A503ToolBoxDefaultLogo = "";
         n503ToolBoxDefaultLogo = false;
         A40001ReceptionImage_GXI = "";
         n40001ReceptionImage_GXI = false;
         A576LocationThemeId = Guid.Empty;
         n576LocationThemeId = false;
         A570LocationHasMyCare = false;
         A571LocationHasMyServices = false;
         A572LocationHasMyLiving = false;
         A573LocationHasOwnBrand = false;
         A574ReceptionImage = AV30ReceptionImageVar;
         n574ReceptionImage = false;
         A575ReceptionDescription = AV31ReceptionDescriptionVar;
         n575ReceptionDescription = false;
         A273Trn_ThemeId = new prc_getdefaulttheme(context).executeUdp( );
         n273Trn_ThemeId = false;
         Z35LocationPhone = "";
         Z329LocationZipCode = "";
         Z31LocationName = "";
         Z327LocationCountry = "";
         Z328LocationCity = "";
         Z330LocationAddressLine1 = "";
         Z331LocationAddressLine2 = "";
         Z34LocationEmail = "";
         Z355LocationPhoneCode = "";
         Z356LocationPhoneNumber = "";
         Z570LocationHasMyCare = false;
         Z571LocationHasMyServices = false;
         Z572LocationHasMyLiving = false;
         Z573LocationHasOwnBrand = false;
         Z504ToolBoxDefaultProfileImage = "";
         Z503ToolBoxDefaultLogo = "";
         Z575ReceptionDescription = "";
         Z273Trn_ThemeId = Guid.Empty;
         Z576LocationThemeId = Guid.Empty;
      }

      protected void InitAll046( )
      {
         A29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         InitializeNonKey046( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A573LocationHasOwnBrand = i573LocationHasOwnBrand;
         A572LocationHasMyLiving = i572LocationHasMyLiving;
         A571LocationHasMyServices = i571LocationHasMyServices;
         A570LocationHasMyCare = i570LocationHasMyCare;
         A575ReceptionDescription = i575ReceptionDescription;
         n575ReceptionDescription = false;
         A574ReceptionImage = i574ReceptionImage;
         n574ReceptionImage = false;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow6( SdtTrn_Location obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Locationphone = A35LocationPhone;
         obj6.gxTpr_Locationzipcode = A329LocationZipCode;
         obj6.gxTpr_Locationname = A31LocationName;
         obj6.gxTpr_Locationimage = A494LocationImage;
         obj6.gxTpr_Locationimage_gxi = A40000LocationImage_GXI;
         obj6.gxTpr_Locationcountry = A327LocationCountry;
         obj6.gxTpr_Locationcity = A328LocationCity;
         obj6.gxTpr_Locationaddressline1 = A330LocationAddressLine1;
         obj6.gxTpr_Locationaddressline2 = A331LocationAddressLine2;
         obj6.gxTpr_Locationemail = A34LocationEmail;
         obj6.gxTpr_Locationphonecode = A355LocationPhoneCode;
         obj6.gxTpr_Locationphonenumber = A356LocationPhoneNumber;
         obj6.gxTpr_Locationdescription = A36LocationDescription;
         obj6.gxTpr_Locationbrandtheme = A568LocationBrandTheme;
         obj6.gxTpr_Locationctatheme = A569LocationCtaTheme;
         obj6.gxTpr_Toolboxdefaultprofileimage = A504ToolBoxDefaultProfileImage;
         obj6.gxTpr_Toolboxdefaultlogo = A503ToolBoxDefaultLogo;
         obj6.gxTpr_Receptionimage_gxi = A40001ReceptionImage_GXI;
         obj6.gxTpr_Locationthemeid = A576LocationThemeId;
         obj6.gxTpr_Locationhasmycare = A570LocationHasMyCare;
         obj6.gxTpr_Locationhasmyservices = A571LocationHasMyServices;
         obj6.gxTpr_Locationhasmyliving = A572LocationHasMyLiving;
         obj6.gxTpr_Locationhasownbrand = A573LocationHasOwnBrand;
         obj6.gxTpr_Receptionimage = A574ReceptionImage;
         obj6.gxTpr_Receptiondescription = A575ReceptionDescription;
         obj6.gxTpr_Trn_themeid = A273Trn_ThemeId;
         obj6.gxTpr_Locationid = A29LocationId;
         obj6.gxTpr_Organisationid = A11OrganisationId;
         obj6.gxTpr_Locationid_Z = Z29LocationId;
         obj6.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj6.gxTpr_Locationname_Z = Z31LocationName;
         obj6.gxTpr_Locationcountry_Z = Z327LocationCountry;
         obj6.gxTpr_Locationcity_Z = Z328LocationCity;
         obj6.gxTpr_Locationzipcode_Z = Z329LocationZipCode;
         obj6.gxTpr_Locationaddressline1_Z = Z330LocationAddressLine1;
         obj6.gxTpr_Locationaddressline2_Z = Z331LocationAddressLine2;
         obj6.gxTpr_Locationemail_Z = Z34LocationEmail;
         obj6.gxTpr_Locationphonecode_Z = Z355LocationPhoneCode;
         obj6.gxTpr_Locationphonenumber_Z = Z356LocationPhoneNumber;
         obj6.gxTpr_Locationphone_Z = Z35LocationPhone;
         obj6.gxTpr_Locationhasmycare_Z = Z570LocationHasMyCare;
         obj6.gxTpr_Locationhasmyservices_Z = Z571LocationHasMyServices;
         obj6.gxTpr_Locationhasmyliving_Z = Z572LocationHasMyLiving;
         obj6.gxTpr_Locationhasownbrand_Z = Z573LocationHasOwnBrand;
         obj6.gxTpr_Toolboxdefaultprofileimage_Z = Z504ToolBoxDefaultProfileImage;
         obj6.gxTpr_Toolboxdefaultlogo_Z = Z503ToolBoxDefaultLogo;
         obj6.gxTpr_Receptiondescription_Z = Z575ReceptionDescription;
         obj6.gxTpr_Trn_themeid_Z = Z273Trn_ThemeId;
         obj6.gxTpr_Locationthemeid_Z = Z576LocationThemeId;
         obj6.gxTpr_Locationimage_gxi_Z = Z40000LocationImage_GXI;
         obj6.gxTpr_Receptionimage_gxi_Z = Z40001ReceptionImage_GXI;
         obj6.gxTpr_Locationid_N = (short)(Convert.ToInt16(n29LocationId));
         obj6.gxTpr_Organisationid_N = (short)(Convert.ToInt16(n11OrganisationId));
         obj6.gxTpr_Locationbrandtheme_N = (short)(Convert.ToInt16(n568LocationBrandTheme));
         obj6.gxTpr_Locationctatheme_N = (short)(Convert.ToInt16(n569LocationCtaTheme));
         obj6.gxTpr_Toolboxdefaultprofileimage_N = (short)(Convert.ToInt16(n504ToolBoxDefaultProfileImage));
         obj6.gxTpr_Toolboxdefaultlogo_N = (short)(Convert.ToInt16(n503ToolBoxDefaultLogo));
         obj6.gxTpr_Receptionimage_N = (short)(Convert.ToInt16(n574ReceptionImage));
         obj6.gxTpr_Receptiondescription_N = (short)(Convert.ToInt16(n575ReceptionDescription));
         obj6.gxTpr_Trn_themeid_N = (short)(Convert.ToInt16(n273Trn_ThemeId));
         obj6.gxTpr_Locationthemeid_N = (short)(Convert.ToInt16(n576LocationThemeId));
         obj6.gxTpr_Receptionimage_gxi_N = (short)(Convert.ToInt16(n40001ReceptionImage_GXI));
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( SdtTrn_Location obj6 )
      {
         obj6.gxTpr_Locationid = A29LocationId;
         obj6.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars6( SdtTrn_Location obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A35LocationPhone = obj6.gxTpr_Locationphone;
         A329LocationZipCode = obj6.gxTpr_Locationzipcode;
         A31LocationName = obj6.gxTpr_Locationname;
         A494LocationImage = obj6.gxTpr_Locationimage;
         A40000LocationImage_GXI = obj6.gxTpr_Locationimage_gxi;
         A327LocationCountry = obj6.gxTpr_Locationcountry;
         A328LocationCity = obj6.gxTpr_Locationcity;
         A330LocationAddressLine1 = obj6.gxTpr_Locationaddressline1;
         A331LocationAddressLine2 = obj6.gxTpr_Locationaddressline2;
         A34LocationEmail = obj6.gxTpr_Locationemail;
         A355LocationPhoneCode = obj6.gxTpr_Locationphonecode;
         A356LocationPhoneNumber = obj6.gxTpr_Locationphonenumber;
         A36LocationDescription = obj6.gxTpr_Locationdescription;
         A568LocationBrandTheme = obj6.gxTpr_Locationbrandtheme;
         n568LocationBrandTheme = false;
         A569LocationCtaTheme = obj6.gxTpr_Locationctatheme;
         n569LocationCtaTheme = false;
         A504ToolBoxDefaultProfileImage = obj6.gxTpr_Toolboxdefaultprofileimage;
         n504ToolBoxDefaultProfileImage = false;
         A503ToolBoxDefaultLogo = obj6.gxTpr_Toolboxdefaultlogo;
         n503ToolBoxDefaultLogo = false;
         A40001ReceptionImage_GXI = obj6.gxTpr_Receptionimage_gxi;
         n40001ReceptionImage_GXI = false;
         A576LocationThemeId = obj6.gxTpr_Locationthemeid;
         n576LocationThemeId = false;
         A570LocationHasMyCare = obj6.gxTpr_Locationhasmycare;
         A571LocationHasMyServices = obj6.gxTpr_Locationhasmyservices;
         A572LocationHasMyLiving = obj6.gxTpr_Locationhasmyliving;
         A573LocationHasOwnBrand = obj6.gxTpr_Locationhasownbrand;
         A574ReceptionImage = obj6.gxTpr_Receptionimage;
         n574ReceptionImage = false;
         A575ReceptionDescription = obj6.gxTpr_Receptiondescription;
         n575ReceptionDescription = false;
         A273Trn_ThemeId = obj6.gxTpr_Trn_themeid;
         n273Trn_ThemeId = false;
         A29LocationId = obj6.gxTpr_Locationid;
         n29LocationId = false;
         A11OrganisationId = obj6.gxTpr_Organisationid;
         n11OrganisationId = false;
         Z29LocationId = obj6.gxTpr_Locationid_Z;
         Z11OrganisationId = obj6.gxTpr_Organisationid_Z;
         Z31LocationName = obj6.gxTpr_Locationname_Z;
         Z327LocationCountry = obj6.gxTpr_Locationcountry_Z;
         Z328LocationCity = obj6.gxTpr_Locationcity_Z;
         Z329LocationZipCode = obj6.gxTpr_Locationzipcode_Z;
         Z330LocationAddressLine1 = obj6.gxTpr_Locationaddressline1_Z;
         Z331LocationAddressLine2 = obj6.gxTpr_Locationaddressline2_Z;
         Z34LocationEmail = obj6.gxTpr_Locationemail_Z;
         Z355LocationPhoneCode = obj6.gxTpr_Locationphonecode_Z;
         Z356LocationPhoneNumber = obj6.gxTpr_Locationphonenumber_Z;
         Z35LocationPhone = obj6.gxTpr_Locationphone_Z;
         Z570LocationHasMyCare = obj6.gxTpr_Locationhasmycare_Z;
         Z571LocationHasMyServices = obj6.gxTpr_Locationhasmyservices_Z;
         Z572LocationHasMyLiving = obj6.gxTpr_Locationhasmyliving_Z;
         Z573LocationHasOwnBrand = obj6.gxTpr_Locationhasownbrand_Z;
         Z504ToolBoxDefaultProfileImage = obj6.gxTpr_Toolboxdefaultprofileimage_Z;
         Z503ToolBoxDefaultLogo = obj6.gxTpr_Toolboxdefaultlogo_Z;
         Z575ReceptionDescription = obj6.gxTpr_Receptiondescription_Z;
         Z273Trn_ThemeId = obj6.gxTpr_Trn_themeid_Z;
         Z576LocationThemeId = obj6.gxTpr_Locationthemeid_Z;
         Z40000LocationImage_GXI = obj6.gxTpr_Locationimage_gxi_Z;
         Z40001ReceptionImage_GXI = obj6.gxTpr_Receptionimage_gxi_Z;
         n29LocationId = (bool)(Convert.ToBoolean(obj6.gxTpr_Locationid_N));
         n11OrganisationId = (bool)(Convert.ToBoolean(obj6.gxTpr_Organisationid_N));
         n568LocationBrandTheme = (bool)(Convert.ToBoolean(obj6.gxTpr_Locationbrandtheme_N));
         n569LocationCtaTheme = (bool)(Convert.ToBoolean(obj6.gxTpr_Locationctatheme_N));
         n504ToolBoxDefaultProfileImage = (bool)(Convert.ToBoolean(obj6.gxTpr_Toolboxdefaultprofileimage_N));
         n503ToolBoxDefaultLogo = (bool)(Convert.ToBoolean(obj6.gxTpr_Toolboxdefaultlogo_N));
         n574ReceptionImage = (bool)(Convert.ToBoolean(obj6.gxTpr_Receptionimage_N));
         n575ReceptionDescription = (bool)(Convert.ToBoolean(obj6.gxTpr_Receptiondescription_N));
         n273Trn_ThemeId = (bool)(Convert.ToBoolean(obj6.gxTpr_Trn_themeid_N));
         n576LocationThemeId = (bool)(Convert.ToBoolean(obj6.gxTpr_Locationthemeid_N));
         n40001ReceptionImage_GXI = (bool)(Convert.ToBoolean(obj6.gxTpr_Receptionimage_gxi_N));
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A29LocationId = (Guid)getParm(obj,0);
         n29LocationId = false;
         A11OrganisationId = (Guid)getParm(obj,1);
         n11OrganisationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey046( ) ;
         ScanKeyStart046( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000422 */
            pr_default.execute(20, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(20) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(20);
         }
         else
         {
            Gx_mode = "UPD";
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM046( -23) ;
         OnLoadActions046( ) ;
         AddRow046( ) ;
         ScanKeyEnd046( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars6( bcTrn_Location, 0) ;
         ScanKeyStart046( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000422 */
            pr_default.execute(20, new Object[] {n11OrganisationId, A11OrganisationId});
            if ( (pr_default.getStatus(20) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(20);
         }
         else
         {
            Gx_mode = "UPD";
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM046( -23) ;
         OnLoadActions046( ) ;
         AddRow046( ) ;
         ScanKeyEnd046( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey046( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert046( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A29LocationId = Z29LocationId;
                  n29LocationId = false;
                  A11OrganisationId = Z11OrganisationId;
                  n11OrganisationId = false;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update046( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert046( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert046( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcTrn_Location, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcTrn_Location) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcTrn_Location, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert046( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcTrn_Location) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow6( bcTrn_Location) ;
         }
         else
         {
            SdtTrn_Location auxBC = new SdtTrn_Location(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A29LocationId, A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Location);
               auxBC.Save();
               bcTrn_Location.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcTrn_Location, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcTrn_Location, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert046( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow6( bcTrn_Location) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow6( bcTrn_Location) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcTrn_Location, 0) ;
         GetKey046( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               A29LocationId = Z29LocationId;
               n29LocationId = false;
               A11OrganisationId = Z11OrganisationId;
               n11OrganisationId = false;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("trn_location_bc",pr_default);
         VarsToRow6( bcTrn_Location) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcTrn_Location.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Location.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Location )
         {
            bcTrn_Location = (SdtTrn_Location)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Location.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Location.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcTrn_Location) ;
            }
            else
            {
               RowToVars6( bcTrn_Location, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Location.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Location.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcTrn_Location, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Location Trn_Location_BC
      {
         get {
            return bcTrn_Location ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_location_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV31ReceptionDescriptionVar = "";
         AV30ReceptionImageVar = "";
         imgReceptionimagevar_gximage = "";
         AV34Receptionimagevar_GXI = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV35Pgmname = "";
         AV26TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV25Insert_Trn_ThemeId = Guid.Empty;
         AV32Insert_LocationThemeId = Guid.Empty;
         Z35LocationPhone = "";
         A35LocationPhone = "";
         Z329LocationZipCode = "";
         A329LocationZipCode = "";
         Z31LocationName = "";
         A31LocationName = "";
         Z327LocationCountry = "";
         A327LocationCountry = "";
         Z328LocationCity = "";
         A328LocationCity = "";
         Z330LocationAddressLine1 = "";
         A330LocationAddressLine1 = "";
         Z331LocationAddressLine2 = "";
         A331LocationAddressLine2 = "";
         Z34LocationEmail = "";
         A34LocationEmail = "";
         Z355LocationPhoneCode = "";
         A355LocationPhoneCode = "";
         Z356LocationPhoneNumber = "";
         A356LocationPhoneNumber = "";
         Z504ToolBoxDefaultProfileImage = "";
         A504ToolBoxDefaultProfileImage = "";
         Z503ToolBoxDefaultLogo = "";
         A503ToolBoxDefaultLogo = "";
         Z575ReceptionDescription = "";
         A575ReceptionDescription = "";
         Z273Trn_ThemeId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         Z576LocationThemeId = Guid.Empty;
         A576LocationThemeId = Guid.Empty;
         Z494LocationImage = "";
         A494LocationImage = "";
         Z40000LocationImage_GXI = "";
         A40000LocationImage_GXI = "";
         Z36LocationDescription = "";
         A36LocationDescription = "";
         Z568LocationBrandTheme = "";
         A568LocationBrandTheme = "";
         Z569LocationCtaTheme = "";
         A569LocationCtaTheme = "";
         Z574ReceptionImage = "";
         A574ReceptionImage = "";
         Z40001ReceptionImage_GXI = "";
         A40001ReceptionImage_GXI = "";
         BC00047_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00047_n29LocationId = new bool[] {false} ;
         BC00047_A35LocationPhone = new string[] {""} ;
         BC00047_A329LocationZipCode = new string[] {""} ;
         BC00047_A31LocationName = new string[] {""} ;
         BC00047_A40000LocationImage_GXI = new string[] {""} ;
         BC00047_A327LocationCountry = new string[] {""} ;
         BC00047_A328LocationCity = new string[] {""} ;
         BC00047_A330LocationAddressLine1 = new string[] {""} ;
         BC00047_A331LocationAddressLine2 = new string[] {""} ;
         BC00047_A34LocationEmail = new string[] {""} ;
         BC00047_A355LocationPhoneCode = new string[] {""} ;
         BC00047_A356LocationPhoneNumber = new string[] {""} ;
         BC00047_A36LocationDescription = new string[] {""} ;
         BC00047_A568LocationBrandTheme = new string[] {""} ;
         BC00047_n568LocationBrandTheme = new bool[] {false} ;
         BC00047_A569LocationCtaTheme = new string[] {""} ;
         BC00047_n569LocationCtaTheme = new bool[] {false} ;
         BC00047_A570LocationHasMyCare = new bool[] {false} ;
         BC00047_A571LocationHasMyServices = new bool[] {false} ;
         BC00047_A572LocationHasMyLiving = new bool[] {false} ;
         BC00047_A573LocationHasOwnBrand = new bool[] {false} ;
         BC00047_A504ToolBoxDefaultProfileImage = new string[] {""} ;
         BC00047_n504ToolBoxDefaultProfileImage = new bool[] {false} ;
         BC00047_A503ToolBoxDefaultLogo = new string[] {""} ;
         BC00047_n503ToolBoxDefaultLogo = new bool[] {false} ;
         BC00047_A40001ReceptionImage_GXI = new string[] {""} ;
         BC00047_n40001ReceptionImage_GXI = new bool[] {false} ;
         BC00047_A575ReceptionDescription = new string[] {""} ;
         BC00047_n575ReceptionDescription = new bool[] {false} ;
         BC00047_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00047_n11OrganisationId = new bool[] {false} ;
         BC00047_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC00047_n273Trn_ThemeId = new bool[] {false} ;
         BC00047_A576LocationThemeId = new Guid[] {Guid.Empty} ;
         BC00047_n576LocationThemeId = new bool[] {false} ;
         BC00047_A494LocationImage = new string[] {""} ;
         BC00047_A574ReceptionImage = new string[] {""} ;
         BC00047_n574ReceptionImage = new bool[] {false} ;
         BC00044_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00044_n11OrganisationId = new bool[] {false} ;
         GXt_char1 = "";
         BC00046_A576LocationThemeId = new Guid[] {Guid.Empty} ;
         BC00046_n576LocationThemeId = new bool[] {false} ;
         GXt_guid2 = Guid.Empty;
         BC00045_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC00045_n273Trn_ThemeId = new bool[] {false} ;
         BC00048_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00048_n29LocationId = new bool[] {false} ;
         BC00048_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00048_n11OrganisationId = new bool[] {false} ;
         BC00043_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00043_n29LocationId = new bool[] {false} ;
         BC00043_A35LocationPhone = new string[] {""} ;
         BC00043_A329LocationZipCode = new string[] {""} ;
         BC00043_A31LocationName = new string[] {""} ;
         BC00043_A40000LocationImage_GXI = new string[] {""} ;
         BC00043_A327LocationCountry = new string[] {""} ;
         BC00043_A328LocationCity = new string[] {""} ;
         BC00043_A330LocationAddressLine1 = new string[] {""} ;
         BC00043_A331LocationAddressLine2 = new string[] {""} ;
         BC00043_A34LocationEmail = new string[] {""} ;
         BC00043_A355LocationPhoneCode = new string[] {""} ;
         BC00043_A356LocationPhoneNumber = new string[] {""} ;
         BC00043_A36LocationDescription = new string[] {""} ;
         BC00043_A568LocationBrandTheme = new string[] {""} ;
         BC00043_n568LocationBrandTheme = new bool[] {false} ;
         BC00043_A569LocationCtaTheme = new string[] {""} ;
         BC00043_n569LocationCtaTheme = new bool[] {false} ;
         BC00043_A570LocationHasMyCare = new bool[] {false} ;
         BC00043_A571LocationHasMyServices = new bool[] {false} ;
         BC00043_A572LocationHasMyLiving = new bool[] {false} ;
         BC00043_A573LocationHasOwnBrand = new bool[] {false} ;
         BC00043_A504ToolBoxDefaultProfileImage = new string[] {""} ;
         BC00043_n504ToolBoxDefaultProfileImage = new bool[] {false} ;
         BC00043_A503ToolBoxDefaultLogo = new string[] {""} ;
         BC00043_n503ToolBoxDefaultLogo = new bool[] {false} ;
         BC00043_A40001ReceptionImage_GXI = new string[] {""} ;
         BC00043_n40001ReceptionImage_GXI = new bool[] {false} ;
         BC00043_A575ReceptionDescription = new string[] {""} ;
         BC00043_n575ReceptionDescription = new bool[] {false} ;
         BC00043_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00043_n11OrganisationId = new bool[] {false} ;
         BC00043_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC00043_n273Trn_ThemeId = new bool[] {false} ;
         BC00043_A576LocationThemeId = new Guid[] {Guid.Empty} ;
         BC00043_n576LocationThemeId = new bool[] {false} ;
         BC00043_A494LocationImage = new string[] {""} ;
         BC00043_A574ReceptionImage = new string[] {""} ;
         BC00043_n574ReceptionImage = new bool[] {false} ;
         sMode6 = "";
         BC00042_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00042_n29LocationId = new bool[] {false} ;
         BC00042_A35LocationPhone = new string[] {""} ;
         BC00042_A329LocationZipCode = new string[] {""} ;
         BC00042_A31LocationName = new string[] {""} ;
         BC00042_A40000LocationImage_GXI = new string[] {""} ;
         BC00042_A327LocationCountry = new string[] {""} ;
         BC00042_A328LocationCity = new string[] {""} ;
         BC00042_A330LocationAddressLine1 = new string[] {""} ;
         BC00042_A331LocationAddressLine2 = new string[] {""} ;
         BC00042_A34LocationEmail = new string[] {""} ;
         BC00042_A355LocationPhoneCode = new string[] {""} ;
         BC00042_A356LocationPhoneNumber = new string[] {""} ;
         BC00042_A36LocationDescription = new string[] {""} ;
         BC00042_A568LocationBrandTheme = new string[] {""} ;
         BC00042_n568LocationBrandTheme = new bool[] {false} ;
         BC00042_A569LocationCtaTheme = new string[] {""} ;
         BC00042_n569LocationCtaTheme = new bool[] {false} ;
         BC00042_A570LocationHasMyCare = new bool[] {false} ;
         BC00042_A571LocationHasMyServices = new bool[] {false} ;
         BC00042_A572LocationHasMyLiving = new bool[] {false} ;
         BC00042_A573LocationHasOwnBrand = new bool[] {false} ;
         BC00042_A504ToolBoxDefaultProfileImage = new string[] {""} ;
         BC00042_n504ToolBoxDefaultProfileImage = new bool[] {false} ;
         BC00042_A503ToolBoxDefaultLogo = new string[] {""} ;
         BC00042_n503ToolBoxDefaultLogo = new bool[] {false} ;
         BC00042_A40001ReceptionImage_GXI = new string[] {""} ;
         BC00042_n40001ReceptionImage_GXI = new bool[] {false} ;
         BC00042_A575ReceptionDescription = new string[] {""} ;
         BC00042_n575ReceptionDescription = new bool[] {false} ;
         BC00042_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00042_n11OrganisationId = new bool[] {false} ;
         BC00042_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC00042_n273Trn_ThemeId = new bool[] {false} ;
         BC00042_A576LocationThemeId = new Guid[] {Guid.Empty} ;
         BC00042_n576LocationThemeId = new bool[] {false} ;
         BC00042_A494LocationImage = new string[] {""} ;
         BC00042_A574ReceptionImage = new string[] {""} ;
         BC00042_n574ReceptionImage = new bool[] {false} ;
         BC000414_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC000415_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC000416_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         BC000417_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC000417_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000417_n11OrganisationId = new bool[] {false} ;
         BC000417_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000417_n29LocationId = new bool[] {false} ;
         BC000418_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000418_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000418_n29LocationId = new bool[] {false} ;
         BC000418_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000418_n11OrganisationId = new bool[] {false} ;
         BC000419_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000419_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000419_n29LocationId = new bool[] {false} ;
         BC000419_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000419_n11OrganisationId = new bool[] {false} ;
         BC000420_A89ReceptionistId = new Guid[] {Guid.Empty} ;
         BC000420_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000420_n11OrganisationId = new bool[] {false} ;
         BC000420_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000420_n29LocationId = new bool[] {false} ;
         BC000421_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000421_n29LocationId = new bool[] {false} ;
         BC000421_A35LocationPhone = new string[] {""} ;
         BC000421_A329LocationZipCode = new string[] {""} ;
         BC000421_A31LocationName = new string[] {""} ;
         BC000421_A40000LocationImage_GXI = new string[] {""} ;
         BC000421_A327LocationCountry = new string[] {""} ;
         BC000421_A328LocationCity = new string[] {""} ;
         BC000421_A330LocationAddressLine1 = new string[] {""} ;
         BC000421_A331LocationAddressLine2 = new string[] {""} ;
         BC000421_A34LocationEmail = new string[] {""} ;
         BC000421_A355LocationPhoneCode = new string[] {""} ;
         BC000421_A356LocationPhoneNumber = new string[] {""} ;
         BC000421_A36LocationDescription = new string[] {""} ;
         BC000421_A568LocationBrandTheme = new string[] {""} ;
         BC000421_n568LocationBrandTheme = new bool[] {false} ;
         BC000421_A569LocationCtaTheme = new string[] {""} ;
         BC000421_n569LocationCtaTheme = new bool[] {false} ;
         BC000421_A570LocationHasMyCare = new bool[] {false} ;
         BC000421_A571LocationHasMyServices = new bool[] {false} ;
         BC000421_A572LocationHasMyLiving = new bool[] {false} ;
         BC000421_A573LocationHasOwnBrand = new bool[] {false} ;
         BC000421_A504ToolBoxDefaultProfileImage = new string[] {""} ;
         BC000421_n504ToolBoxDefaultProfileImage = new bool[] {false} ;
         BC000421_A503ToolBoxDefaultLogo = new string[] {""} ;
         BC000421_n503ToolBoxDefaultLogo = new bool[] {false} ;
         BC000421_A40001ReceptionImage_GXI = new string[] {""} ;
         BC000421_n40001ReceptionImage_GXI = new bool[] {false} ;
         BC000421_A575ReceptionDescription = new string[] {""} ;
         BC000421_n575ReceptionDescription = new bool[] {false} ;
         BC000421_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000421_n11OrganisationId = new bool[] {false} ;
         BC000421_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000421_n273Trn_ThemeId = new bool[] {false} ;
         BC000421_A576LocationThemeId = new Guid[] {Guid.Empty} ;
         BC000421_n576LocationThemeId = new bool[] {false} ;
         BC000421_A494LocationImage = new string[] {""} ;
         BC000421_A574ReceptionImage = new string[] {""} ;
         BC000421_n574ReceptionImage = new bool[] {false} ;
         i575ReceptionDescription = "";
         i574ReceptionImage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000422_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000422_n11OrganisationId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_location_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_location_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_location_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A29LocationId, BC00042_A35LocationPhone, BC00042_A329LocationZipCode, BC00042_A31LocationName, BC00042_A40000LocationImage_GXI, BC00042_A327LocationCountry, BC00042_A328LocationCity, BC00042_A330LocationAddressLine1, BC00042_A331LocationAddressLine2, BC00042_A34LocationEmail,
               BC00042_A355LocationPhoneCode, BC00042_A356LocationPhoneNumber, BC00042_A36LocationDescription, BC00042_A568LocationBrandTheme, BC00042_n568LocationBrandTheme, BC00042_A569LocationCtaTheme, BC00042_n569LocationCtaTheme, BC00042_A570LocationHasMyCare, BC00042_A571LocationHasMyServices, BC00042_A572LocationHasMyLiving,
               BC00042_A573LocationHasOwnBrand, BC00042_A504ToolBoxDefaultProfileImage, BC00042_n504ToolBoxDefaultProfileImage, BC00042_A503ToolBoxDefaultLogo, BC00042_n503ToolBoxDefaultLogo, BC00042_A40001ReceptionImage_GXI, BC00042_n40001ReceptionImage_GXI, BC00042_A575ReceptionDescription, BC00042_n575ReceptionDescription, BC00042_A11OrganisationId,
               BC00042_A273Trn_ThemeId, BC00042_n273Trn_ThemeId, BC00042_A576LocationThemeId, BC00042_n576LocationThemeId, BC00042_A494LocationImage, BC00042_A574ReceptionImage, BC00042_n574ReceptionImage
               }
               , new Object[] {
               BC00043_A29LocationId, BC00043_A35LocationPhone, BC00043_A329LocationZipCode, BC00043_A31LocationName, BC00043_A40000LocationImage_GXI, BC00043_A327LocationCountry, BC00043_A328LocationCity, BC00043_A330LocationAddressLine1, BC00043_A331LocationAddressLine2, BC00043_A34LocationEmail,
               BC00043_A355LocationPhoneCode, BC00043_A356LocationPhoneNumber, BC00043_A36LocationDescription, BC00043_A568LocationBrandTheme, BC00043_n568LocationBrandTheme, BC00043_A569LocationCtaTheme, BC00043_n569LocationCtaTheme, BC00043_A570LocationHasMyCare, BC00043_A571LocationHasMyServices, BC00043_A572LocationHasMyLiving,
               BC00043_A573LocationHasOwnBrand, BC00043_A504ToolBoxDefaultProfileImage, BC00043_n504ToolBoxDefaultProfileImage, BC00043_A503ToolBoxDefaultLogo, BC00043_n503ToolBoxDefaultLogo, BC00043_A40001ReceptionImage_GXI, BC00043_n40001ReceptionImage_GXI, BC00043_A575ReceptionDescription, BC00043_n575ReceptionDescription, BC00043_A11OrganisationId,
               BC00043_A273Trn_ThemeId, BC00043_n273Trn_ThemeId, BC00043_A576LocationThemeId, BC00043_n576LocationThemeId, BC00043_A494LocationImage, BC00043_A574ReceptionImage, BC00043_n574ReceptionImage
               }
               , new Object[] {
               BC00044_A11OrganisationId
               }
               , new Object[] {
               BC00045_A273Trn_ThemeId
               }
               , new Object[] {
               BC00046_A576LocationThemeId
               }
               , new Object[] {
               BC00047_A29LocationId, BC00047_A35LocationPhone, BC00047_A329LocationZipCode, BC00047_A31LocationName, BC00047_A40000LocationImage_GXI, BC00047_A327LocationCountry, BC00047_A328LocationCity, BC00047_A330LocationAddressLine1, BC00047_A331LocationAddressLine2, BC00047_A34LocationEmail,
               BC00047_A355LocationPhoneCode, BC00047_A356LocationPhoneNumber, BC00047_A36LocationDescription, BC00047_A568LocationBrandTheme, BC00047_n568LocationBrandTheme, BC00047_A569LocationCtaTheme, BC00047_n569LocationCtaTheme, BC00047_A570LocationHasMyCare, BC00047_A571LocationHasMyServices, BC00047_A572LocationHasMyLiving,
               BC00047_A573LocationHasOwnBrand, BC00047_A504ToolBoxDefaultProfileImage, BC00047_n504ToolBoxDefaultProfileImage, BC00047_A503ToolBoxDefaultLogo, BC00047_n503ToolBoxDefaultLogo, BC00047_A40001ReceptionImage_GXI, BC00047_n40001ReceptionImage_GXI, BC00047_A575ReceptionDescription, BC00047_n575ReceptionDescription, BC00047_A11OrganisationId,
               BC00047_A273Trn_ThemeId, BC00047_n273Trn_ThemeId, BC00047_A576LocationThemeId, BC00047_n576LocationThemeId, BC00047_A494LocationImage, BC00047_A574ReceptionImage, BC00047_n574ReceptionImage
               }
               , new Object[] {
               BC00048_A29LocationId, BC00048_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000414_A527ResidentPackageId
               }
               , new Object[] {
               BC000415_A523AppVersionId
               }
               , new Object[] {
               BC000416_A268AgendaCalendarId
               }
               , new Object[] {
               BC000417_A366LocationDynamicFormId, BC000417_A11OrganisationId, BC000417_A29LocationId
               }
               , new Object[] {
               BC000418_A58ProductServiceId, BC000418_A29LocationId, BC000418_A11OrganisationId
               }
               , new Object[] {
               BC000419_A62ResidentId, BC000419_A29LocationId, BC000419_A11OrganisationId
               }
               , new Object[] {
               BC000420_A89ReceptionistId, BC000420_A11OrganisationId, BC000420_A29LocationId
               }
               , new Object[] {
               BC000421_A29LocationId, BC000421_A35LocationPhone, BC000421_A329LocationZipCode, BC000421_A31LocationName, BC000421_A40000LocationImage_GXI, BC000421_A327LocationCountry, BC000421_A328LocationCity, BC000421_A330LocationAddressLine1, BC000421_A331LocationAddressLine2, BC000421_A34LocationEmail,
               BC000421_A355LocationPhoneCode, BC000421_A356LocationPhoneNumber, BC000421_A36LocationDescription, BC000421_A568LocationBrandTheme, BC000421_n568LocationBrandTheme, BC000421_A569LocationCtaTheme, BC000421_n569LocationCtaTheme, BC000421_A570LocationHasMyCare, BC000421_A571LocationHasMyServices, BC000421_A572LocationHasMyLiving,
               BC000421_A573LocationHasOwnBrand, BC000421_A504ToolBoxDefaultProfileImage, BC000421_n504ToolBoxDefaultProfileImage, BC000421_A503ToolBoxDefaultLogo, BC000421_n503ToolBoxDefaultLogo, BC000421_A40001ReceptionImage_GXI, BC000421_n40001ReceptionImage_GXI, BC000421_A575ReceptionDescription, BC000421_n575ReceptionDescription, BC000421_A11OrganisationId,
               BC000421_A273Trn_ThemeId, BC000421_n273Trn_ThemeId, BC000421_A576LocationThemeId, BC000421_n576LocationThemeId, BC000421_A494LocationImage, BC000421_A574ReceptionImage, BC000421_n574ReceptionImage
               }
               , new Object[] {
               BC000422_A11OrganisationId
               }
            }
         );
         Z573LocationHasOwnBrand = false;
         A573LocationHasOwnBrand = false;
         i573LocationHasOwnBrand = false;
         Z572LocationHasMyLiving = false;
         A572LocationHasMyLiving = false;
         i572LocationHasMyLiving = false;
         Z571LocationHasMyServices = false;
         A571LocationHasMyServices = false;
         i571LocationHasMyServices = false;
         Z570LocationHasMyCare = false;
         A570LocationHasMyCare = false;
         i570LocationHasMyCare = false;
         Z29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         A29LocationId = Guid.NewGuid( );
         n29LocationId = false;
         AV35Pgmname = "Trn_Location_BC";
         Z574ReceptionImage = "";
         n574ReceptionImage = false;
         A574ReceptionImage = "";
         n574ReceptionImage = false;
         i574ReceptionImage = "";
         n574ReceptionImage = false;
         Z575ReceptionDescription = "";
         n575ReceptionDescription = false;
         A575ReceptionDescription = "";
         n575ReceptionDescription = false;
         i575ReceptionDescription = "";
         n575ReceptionDescription = false;
         Z273Trn_ThemeId = new prc_getdefaulttheme(context).executeUdp( );
         n273Trn_ThemeId = false;
         A273Trn_ThemeId = new prc_getdefaulttheme(context).executeUdp( );
         n273Trn_ThemeId = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12042 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound6 ;
      private int trnEnded ;
      private int AV36GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string imgReceptionimagevar_gximage ;
      private string AV35Pgmname ;
      private string Z35LocationPhone ;
      private string A35LocationPhone ;
      private string GXt_char1 ;
      private string sMode6 ;
      private bool returnInSub ;
      private bool Z570LocationHasMyCare ;
      private bool A570LocationHasMyCare ;
      private bool Z571LocationHasMyServices ;
      private bool A571LocationHasMyServices ;
      private bool Z572LocationHasMyLiving ;
      private bool A572LocationHasMyLiving ;
      private bool Z573LocationHasOwnBrand ;
      private bool A573LocationHasOwnBrand ;
      private bool n29LocationId ;
      private bool n575ReceptionDescription ;
      private bool n574ReceptionImage ;
      private bool n11OrganisationId ;
      private bool n568LocationBrandTheme ;
      private bool n569LocationCtaTheme ;
      private bool n504ToolBoxDefaultProfileImage ;
      private bool n503ToolBoxDefaultLogo ;
      private bool n40001ReceptionImage_GXI ;
      private bool n273Trn_ThemeId ;
      private bool n576LocationThemeId ;
      private bool Gx_longc ;
      private bool i573LocationHasOwnBrand ;
      private bool i572LocationHasMyLiving ;
      private bool i571LocationHasMyServices ;
      private bool i570LocationHasMyCare ;
      private string Z36LocationDescription ;
      private string A36LocationDescription ;
      private string Z568LocationBrandTheme ;
      private string A568LocationBrandTheme ;
      private string Z569LocationCtaTheme ;
      private string A569LocationCtaTheme ;
      private string AV31ReceptionDescriptionVar ;
      private string AV34Receptionimagevar_GXI ;
      private string Z329LocationZipCode ;
      private string A329LocationZipCode ;
      private string Z31LocationName ;
      private string A31LocationName ;
      private string Z327LocationCountry ;
      private string A327LocationCountry ;
      private string Z328LocationCity ;
      private string A328LocationCity ;
      private string Z330LocationAddressLine1 ;
      private string A330LocationAddressLine1 ;
      private string Z331LocationAddressLine2 ;
      private string A331LocationAddressLine2 ;
      private string Z34LocationEmail ;
      private string A34LocationEmail ;
      private string Z355LocationPhoneCode ;
      private string A355LocationPhoneCode ;
      private string Z356LocationPhoneNumber ;
      private string A356LocationPhoneNumber ;
      private string Z504ToolBoxDefaultProfileImage ;
      private string A504ToolBoxDefaultProfileImage ;
      private string Z503ToolBoxDefaultLogo ;
      private string A503ToolBoxDefaultLogo ;
      private string Z575ReceptionDescription ;
      private string A575ReceptionDescription ;
      private string Z40000LocationImage_GXI ;
      private string A40000LocationImage_GXI ;
      private string Z40001ReceptionImage_GXI ;
      private string A40001ReceptionImage_GXI ;
      private string i575ReceptionDescription ;
      private string AV30ReceptionImageVar ;
      private string Z494LocationImage ;
      private string A494LocationImage ;
      private string Z574ReceptionImage ;
      private string A574ReceptionImage ;
      private string i574ReceptionImage ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid AV25Insert_Trn_ThemeId ;
      private Guid AV32Insert_LocationThemeId ;
      private Guid Z273Trn_ThemeId ;
      private Guid A273Trn_ThemeId ;
      private Guid Z576LocationThemeId ;
      private Guid A576LocationThemeId ;
      private Guid GXt_guid2 ;
      private IGxSession AV13WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV26TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00047_A29LocationId ;
      private bool[] BC00047_n29LocationId ;
      private string[] BC00047_A35LocationPhone ;
      private string[] BC00047_A329LocationZipCode ;
      private string[] BC00047_A31LocationName ;
      private string[] BC00047_A40000LocationImage_GXI ;
      private string[] BC00047_A327LocationCountry ;
      private string[] BC00047_A328LocationCity ;
      private string[] BC00047_A330LocationAddressLine1 ;
      private string[] BC00047_A331LocationAddressLine2 ;
      private string[] BC00047_A34LocationEmail ;
      private string[] BC00047_A355LocationPhoneCode ;
      private string[] BC00047_A356LocationPhoneNumber ;
      private string[] BC00047_A36LocationDescription ;
      private string[] BC00047_A568LocationBrandTheme ;
      private bool[] BC00047_n568LocationBrandTheme ;
      private string[] BC00047_A569LocationCtaTheme ;
      private bool[] BC00047_n569LocationCtaTheme ;
      private bool[] BC00047_A570LocationHasMyCare ;
      private bool[] BC00047_A571LocationHasMyServices ;
      private bool[] BC00047_A572LocationHasMyLiving ;
      private bool[] BC00047_A573LocationHasOwnBrand ;
      private string[] BC00047_A504ToolBoxDefaultProfileImage ;
      private bool[] BC00047_n504ToolBoxDefaultProfileImage ;
      private string[] BC00047_A503ToolBoxDefaultLogo ;
      private bool[] BC00047_n503ToolBoxDefaultLogo ;
      private string[] BC00047_A40001ReceptionImage_GXI ;
      private bool[] BC00047_n40001ReceptionImage_GXI ;
      private string[] BC00047_A575ReceptionDescription ;
      private bool[] BC00047_n575ReceptionDescription ;
      private Guid[] BC00047_A11OrganisationId ;
      private bool[] BC00047_n11OrganisationId ;
      private Guid[] BC00047_A273Trn_ThemeId ;
      private bool[] BC00047_n273Trn_ThemeId ;
      private Guid[] BC00047_A576LocationThemeId ;
      private bool[] BC00047_n576LocationThemeId ;
      private string[] BC00047_A494LocationImage ;
      private string[] BC00047_A574ReceptionImage ;
      private bool[] BC00047_n574ReceptionImage ;
      private Guid[] BC00044_A11OrganisationId ;
      private bool[] BC00044_n11OrganisationId ;
      private Guid[] BC00046_A576LocationThemeId ;
      private bool[] BC00046_n576LocationThemeId ;
      private Guid[] BC00045_A273Trn_ThemeId ;
      private bool[] BC00045_n273Trn_ThemeId ;
      private Guid[] BC00048_A29LocationId ;
      private bool[] BC00048_n29LocationId ;
      private Guid[] BC00048_A11OrganisationId ;
      private bool[] BC00048_n11OrganisationId ;
      private Guid[] BC00043_A29LocationId ;
      private bool[] BC00043_n29LocationId ;
      private string[] BC00043_A35LocationPhone ;
      private string[] BC00043_A329LocationZipCode ;
      private string[] BC00043_A31LocationName ;
      private string[] BC00043_A40000LocationImage_GXI ;
      private string[] BC00043_A327LocationCountry ;
      private string[] BC00043_A328LocationCity ;
      private string[] BC00043_A330LocationAddressLine1 ;
      private string[] BC00043_A331LocationAddressLine2 ;
      private string[] BC00043_A34LocationEmail ;
      private string[] BC00043_A355LocationPhoneCode ;
      private string[] BC00043_A356LocationPhoneNumber ;
      private string[] BC00043_A36LocationDescription ;
      private string[] BC00043_A568LocationBrandTheme ;
      private bool[] BC00043_n568LocationBrandTheme ;
      private string[] BC00043_A569LocationCtaTheme ;
      private bool[] BC00043_n569LocationCtaTheme ;
      private bool[] BC00043_A570LocationHasMyCare ;
      private bool[] BC00043_A571LocationHasMyServices ;
      private bool[] BC00043_A572LocationHasMyLiving ;
      private bool[] BC00043_A573LocationHasOwnBrand ;
      private string[] BC00043_A504ToolBoxDefaultProfileImage ;
      private bool[] BC00043_n504ToolBoxDefaultProfileImage ;
      private string[] BC00043_A503ToolBoxDefaultLogo ;
      private bool[] BC00043_n503ToolBoxDefaultLogo ;
      private string[] BC00043_A40001ReceptionImage_GXI ;
      private bool[] BC00043_n40001ReceptionImage_GXI ;
      private string[] BC00043_A575ReceptionDescription ;
      private bool[] BC00043_n575ReceptionDescription ;
      private Guid[] BC00043_A11OrganisationId ;
      private bool[] BC00043_n11OrganisationId ;
      private Guid[] BC00043_A273Trn_ThemeId ;
      private bool[] BC00043_n273Trn_ThemeId ;
      private Guid[] BC00043_A576LocationThemeId ;
      private bool[] BC00043_n576LocationThemeId ;
      private string[] BC00043_A494LocationImage ;
      private string[] BC00043_A574ReceptionImage ;
      private bool[] BC00043_n574ReceptionImage ;
      private Guid[] BC00042_A29LocationId ;
      private bool[] BC00042_n29LocationId ;
      private string[] BC00042_A35LocationPhone ;
      private string[] BC00042_A329LocationZipCode ;
      private string[] BC00042_A31LocationName ;
      private string[] BC00042_A40000LocationImage_GXI ;
      private string[] BC00042_A327LocationCountry ;
      private string[] BC00042_A328LocationCity ;
      private string[] BC00042_A330LocationAddressLine1 ;
      private string[] BC00042_A331LocationAddressLine2 ;
      private string[] BC00042_A34LocationEmail ;
      private string[] BC00042_A355LocationPhoneCode ;
      private string[] BC00042_A356LocationPhoneNumber ;
      private string[] BC00042_A36LocationDescription ;
      private string[] BC00042_A568LocationBrandTheme ;
      private bool[] BC00042_n568LocationBrandTheme ;
      private string[] BC00042_A569LocationCtaTheme ;
      private bool[] BC00042_n569LocationCtaTheme ;
      private bool[] BC00042_A570LocationHasMyCare ;
      private bool[] BC00042_A571LocationHasMyServices ;
      private bool[] BC00042_A572LocationHasMyLiving ;
      private bool[] BC00042_A573LocationHasOwnBrand ;
      private string[] BC00042_A504ToolBoxDefaultProfileImage ;
      private bool[] BC00042_n504ToolBoxDefaultProfileImage ;
      private string[] BC00042_A503ToolBoxDefaultLogo ;
      private bool[] BC00042_n503ToolBoxDefaultLogo ;
      private string[] BC00042_A40001ReceptionImage_GXI ;
      private bool[] BC00042_n40001ReceptionImage_GXI ;
      private string[] BC00042_A575ReceptionDescription ;
      private bool[] BC00042_n575ReceptionDescription ;
      private Guid[] BC00042_A11OrganisationId ;
      private bool[] BC00042_n11OrganisationId ;
      private Guid[] BC00042_A273Trn_ThemeId ;
      private bool[] BC00042_n273Trn_ThemeId ;
      private Guid[] BC00042_A576LocationThemeId ;
      private bool[] BC00042_n576LocationThemeId ;
      private string[] BC00042_A494LocationImage ;
      private string[] BC00042_A574ReceptionImage ;
      private bool[] BC00042_n574ReceptionImage ;
      private Guid[] BC000414_A527ResidentPackageId ;
      private Guid[] BC000415_A523AppVersionId ;
      private Guid[] BC000416_A268AgendaCalendarId ;
      private Guid[] BC000417_A366LocationDynamicFormId ;
      private Guid[] BC000417_A11OrganisationId ;
      private bool[] BC000417_n11OrganisationId ;
      private Guid[] BC000417_A29LocationId ;
      private bool[] BC000417_n29LocationId ;
      private Guid[] BC000418_A58ProductServiceId ;
      private Guid[] BC000418_A29LocationId ;
      private bool[] BC000418_n29LocationId ;
      private Guid[] BC000418_A11OrganisationId ;
      private bool[] BC000418_n11OrganisationId ;
      private Guid[] BC000419_A62ResidentId ;
      private Guid[] BC000419_A29LocationId ;
      private bool[] BC000419_n29LocationId ;
      private Guid[] BC000419_A11OrganisationId ;
      private bool[] BC000419_n11OrganisationId ;
      private Guid[] BC000420_A89ReceptionistId ;
      private Guid[] BC000420_A11OrganisationId ;
      private bool[] BC000420_n11OrganisationId ;
      private Guid[] BC000420_A29LocationId ;
      private bool[] BC000420_n29LocationId ;
      private Guid[] BC000421_A29LocationId ;
      private bool[] BC000421_n29LocationId ;
      private string[] BC000421_A35LocationPhone ;
      private string[] BC000421_A329LocationZipCode ;
      private string[] BC000421_A31LocationName ;
      private string[] BC000421_A40000LocationImage_GXI ;
      private string[] BC000421_A327LocationCountry ;
      private string[] BC000421_A328LocationCity ;
      private string[] BC000421_A330LocationAddressLine1 ;
      private string[] BC000421_A331LocationAddressLine2 ;
      private string[] BC000421_A34LocationEmail ;
      private string[] BC000421_A355LocationPhoneCode ;
      private string[] BC000421_A356LocationPhoneNumber ;
      private string[] BC000421_A36LocationDescription ;
      private string[] BC000421_A568LocationBrandTheme ;
      private bool[] BC000421_n568LocationBrandTheme ;
      private string[] BC000421_A569LocationCtaTheme ;
      private bool[] BC000421_n569LocationCtaTheme ;
      private bool[] BC000421_A570LocationHasMyCare ;
      private bool[] BC000421_A571LocationHasMyServices ;
      private bool[] BC000421_A572LocationHasMyLiving ;
      private bool[] BC000421_A573LocationHasOwnBrand ;
      private string[] BC000421_A504ToolBoxDefaultProfileImage ;
      private bool[] BC000421_n504ToolBoxDefaultProfileImage ;
      private string[] BC000421_A503ToolBoxDefaultLogo ;
      private bool[] BC000421_n503ToolBoxDefaultLogo ;
      private string[] BC000421_A40001ReceptionImage_GXI ;
      private bool[] BC000421_n40001ReceptionImage_GXI ;
      private string[] BC000421_A575ReceptionDescription ;
      private bool[] BC000421_n575ReceptionDescription ;
      private Guid[] BC000421_A11OrganisationId ;
      private bool[] BC000421_n11OrganisationId ;
      private Guid[] BC000421_A273Trn_ThemeId ;
      private bool[] BC000421_n273Trn_ThemeId ;
      private Guid[] BC000421_A576LocationThemeId ;
      private bool[] BC000421_n576LocationThemeId ;
      private string[] BC000421_A494LocationImage ;
      private string[] BC000421_A574ReceptionImage ;
      private bool[] BC000421_n574ReceptionImage ;
      private SdtTrn_Location bcTrn_Location ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC000422_A11OrganisationId ;
      private bool[] BC000422_n11OrganisationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_location_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class trn_location_bc__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class trn_location_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
      ,new ForEachCursor(def[5])
      ,new ForEachCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00042;
       prmBC00042 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00043;
       prmBC00043 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00044;
       prmBC00044 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00045;
       prmBC00045 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00046;
       prmBC00046 = new Object[] {
       new ParDef("LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00047;
       prmBC00047 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00048;
       prmBC00048 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00049;
       prmBC00049 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationPhone",GXType.Char,20,0) ,
       new ParDef("LocationZipCode",GXType.VarChar,100,0) ,
       new ParDef("LocationName",GXType.VarChar,100,0) ,
       new ParDef("LocationImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("LocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="Trn_Location", Fld="LocationImage"} ,
       new ParDef("LocationCountry",GXType.VarChar,100,0) ,
       new ParDef("LocationCity",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("LocationEmail",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("LocationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("LocationDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("LocationBrandTheme",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("LocationCtaTheme",GXType.LongVarChar,1000,0){Nullable=true} ,
       new ParDef("LocationHasMyCare",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyServices",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyLiving",GXType.Boolean,4,0) ,
       new ParDef("LocationHasOwnBrand",GXType.Boolean,4,0) ,
       new ParDef("ToolBoxDefaultProfileImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ToolBoxDefaultLogo",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ReceptionImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ReceptionImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=22, Tbl="Trn_Location", Fld="ReceptionImage"} ,
       new ParDef("ReceptionDescription",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000410;
       prmBC000410 = new Object[] {
       new ParDef("LocationPhone",GXType.Char,20,0) ,
       new ParDef("LocationZipCode",GXType.VarChar,100,0) ,
       new ParDef("LocationName",GXType.VarChar,100,0) ,
       new ParDef("LocationCountry",GXType.VarChar,100,0) ,
       new ParDef("LocationCity",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine1",GXType.VarChar,100,0) ,
       new ParDef("LocationAddressLine2",GXType.VarChar,100,0) ,
       new ParDef("LocationEmail",GXType.VarChar,100,0) ,
       new ParDef("LocationPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("LocationPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("LocationDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("LocationBrandTheme",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("LocationCtaTheme",GXType.LongVarChar,1000,0){Nullable=true} ,
       new ParDef("LocationHasMyCare",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyServices",GXType.Boolean,4,0) ,
       new ParDef("LocationHasMyLiving",GXType.Boolean,4,0) ,
       new ParDef("LocationHasOwnBrand",GXType.Boolean,4,0) ,
       new ParDef("ToolBoxDefaultProfileImage",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ToolBoxDefaultLogo",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("ReceptionDescription",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000411;
       prmBC000411 = new Object[] {
       new ParDef("LocationImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("LocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_Location", Fld="LocationImage"} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000412;
       prmBC000412 = new Object[] {
       new ParDef("ReceptionImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("ReceptionImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Location", Fld="ReceptionImage"} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000413;
       prmBC000413 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000414;
       prmBC000414 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000415;
       prmBC000415 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000416;
       prmBC000416 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000417;
       prmBC000417 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000418;
       prmBC000418 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000419;
       prmBC000419 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000420;
       prmBC000420 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000421;
       prmBC000421 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000422;
       prmBC000422 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC00042", "SELECT LocationId, LocationPhone, LocationZipCode, LocationName, LocationImage_GXI, LocationCountry, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneCode, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage_GXI, ReceptionDescription, OrganisationId, Trn_ThemeId, LocationThemeId, LocationImage, ReceptionImage FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_Location",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00043", "SELECT LocationId, LocationPhone, LocationZipCode, LocationName, LocationImage_GXI, LocationCountry, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneCode, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage_GXI, ReceptionDescription, OrganisationId, Trn_ThemeId, LocationThemeId, LocationImage, ReceptionImage FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00044", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00045", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00046", "SELECT Trn_ThemeId AS LocationThemeId FROM Trn_Theme WHERE Trn_ThemeId = :LocationThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00047", "SELECT TM1.LocationId, TM1.LocationPhone, TM1.LocationZipCode, TM1.LocationName, TM1.LocationImage_GXI, TM1.LocationCountry, TM1.LocationCity, TM1.LocationAddressLine1, TM1.LocationAddressLine2, TM1.LocationEmail, TM1.LocationPhoneCode, TM1.LocationPhoneNumber, TM1.LocationDescription, TM1.LocationBrandTheme, TM1.LocationCtaTheme, TM1.LocationHasMyCare, TM1.LocationHasMyServices, TM1.LocationHasMyLiving, TM1.LocationHasOwnBrand, TM1.ToolBoxDefaultProfileImage, TM1.ToolBoxDefaultLogo, TM1.ReceptionImage_GXI, TM1.ReceptionDescription, TM1.OrganisationId, TM1.Trn_ThemeId, TM1.LocationThemeId AS LocationThemeId, TM1.LocationImage, TM1.ReceptionImage FROM Trn_Location TM1 WHERE TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00048", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00048,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00049", "SAVEPOINT gxupdate;INSERT INTO Trn_Location(LocationId, LocationPhone, LocationZipCode, LocationName, LocationImage, LocationImage_GXI, LocationCountry, LocationCity, LocationAddressLine1, LocationAddressLine2, LocationEmail, LocationPhoneCode, LocationPhoneNumber, LocationDescription, LocationBrandTheme, LocationCtaTheme, LocationHasMyCare, LocationHasMyServices, LocationHasMyLiving, LocationHasOwnBrand, ToolBoxDefaultProfileImage, ToolBoxDefaultLogo, ReceptionImage, ReceptionImage_GXI, ReceptionDescription, OrganisationId, Trn_ThemeId, LocationThemeId) VALUES(:LocationId, :LocationPhone, :LocationZipCode, :LocationName, :LocationImage, :LocationImage_GXI, :LocationCountry, :LocationCity, :LocationAddressLine1, :LocationAddressLine2, :LocationEmail, :LocationPhoneCode, :LocationPhoneNumber, :LocationDescription, :LocationBrandTheme, :LocationCtaTheme, :LocationHasMyCare, :LocationHasMyServices, :LocationHasMyLiving, :LocationHasOwnBrand, :ToolBoxDefaultProfileImage, :ToolBoxDefaultLogo, :ReceptionImage, :ReceptionImage_GXI, :ReceptionDescription, :OrganisationId, :Trn_ThemeId, :LocationThemeId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00049)
          ,new CursorDef("BC000410", "SAVEPOINT gxupdate;UPDATE Trn_Location SET LocationPhone=:LocationPhone, LocationZipCode=:LocationZipCode, LocationName=:LocationName, LocationCountry=:LocationCountry, LocationCity=:LocationCity, LocationAddressLine1=:LocationAddressLine1, LocationAddressLine2=:LocationAddressLine2, LocationEmail=:LocationEmail, LocationPhoneCode=:LocationPhoneCode, LocationPhoneNumber=:LocationPhoneNumber, LocationDescription=:LocationDescription, LocationBrandTheme=:LocationBrandTheme, LocationCtaTheme=:LocationCtaTheme, LocationHasMyCare=:LocationHasMyCare, LocationHasMyServices=:LocationHasMyServices, LocationHasMyLiving=:LocationHasMyLiving, LocationHasOwnBrand=:LocationHasOwnBrand, ToolBoxDefaultProfileImage=:ToolBoxDefaultProfileImage, ToolBoxDefaultLogo=:ToolBoxDefaultLogo, ReceptionDescription=:ReceptionDescription, Trn_ThemeId=:Trn_ThemeId, LocationThemeId=:LocationThemeId  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000410)
          ,new CursorDef("BC000411", "SAVEPOINT gxupdate;UPDATE Trn_Location SET LocationImage=:LocationImage, LocationImage_GXI=:LocationImage_GXI  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000411)
          ,new CursorDef("BC000412", "SAVEPOINT gxupdate;UPDATE Trn_Location SET ReceptionImage=:ReceptionImage, ReceptionImage_GXI=:ReceptionImage_GXI  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000412)
          ,new CursorDef("BC000413", "SAVEPOINT gxupdate;DELETE FROM Trn_Location  WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000413)
          ,new CursorDef("BC000414", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE SG_LocationId = :LocationId AND SG_OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000414,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000415", "SELECT AppVersionId FROM Trn_AppVersion WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000415,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000416", "SELECT AgendaCalendarId FROM Trn_AgendaCalendar WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000416,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000417", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000417,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000418", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000418,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000419", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000419,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000420", "SELECT ReceptionistId, OrganisationId, LocationId FROM Trn_Receptionist WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000420,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000421", "SELECT TM1.LocationId, TM1.LocationPhone, TM1.LocationZipCode, TM1.LocationName, TM1.LocationImage_GXI, TM1.LocationCountry, TM1.LocationCity, TM1.LocationAddressLine1, TM1.LocationAddressLine2, TM1.LocationEmail, TM1.LocationPhoneCode, TM1.LocationPhoneNumber, TM1.LocationDescription, TM1.LocationBrandTheme, TM1.LocationCtaTheme, TM1.LocationHasMyCare, TM1.LocationHasMyServices, TM1.LocationHasMyLiving, TM1.LocationHasOwnBrand, TM1.ToolBoxDefaultProfileImage, TM1.ToolBoxDefaultLogo, TM1.ReceptionImage_GXI, TM1.ReceptionDescription, TM1.OrganisationId, TM1.Trn_ThemeId, TM1.LocationThemeId AS LocationThemeId, TM1.LocationImage, TM1.ReceptionImage FROM Trn_Location TM1 WHERE TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000421,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000422", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000422,1, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((Guid[]) buf[32])[0] = rslt.getGuid(26);
             ((bool[]) buf[33])[0] = rslt.wasNull(26);
             ((string[]) buf[34])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(5));
             ((string[]) buf[35])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(22));
             ((bool[]) buf[36])[0] = rslt.wasNull(28);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((Guid[]) buf[32])[0] = rslt.getGuid(26);
             ((bool[]) buf[33])[0] = rslt.wasNull(26);
             ((string[]) buf[34])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(5));
             ((string[]) buf[35])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(22));
             ((bool[]) buf[36])[0] = rslt.wasNull(28);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((Guid[]) buf[32])[0] = rslt.getGuid(26);
             ((bool[]) buf[33])[0] = rslt.wasNull(26);
             ((string[]) buf[34])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(5));
             ((string[]) buf[35])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(22));
             ((bool[]) buf[36])[0] = rslt.wasNull(28);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 20);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[16])[0] = rslt.wasNull(15);
             ((bool[]) buf[17])[0] = rslt.getBool(16);
             ((bool[]) buf[18])[0] = rslt.getBool(17);
             ((bool[]) buf[19])[0] = rslt.getBool(18);
             ((bool[]) buf[20])[0] = rslt.getBool(19);
             ((string[]) buf[21])[0] = rslt.getVarchar(20);
             ((bool[]) buf[22])[0] = rslt.wasNull(20);
             ((string[]) buf[23])[0] = rslt.getVarchar(21);
             ((bool[]) buf[24])[0] = rslt.wasNull(21);
             ((string[]) buf[25])[0] = rslt.getMultimediaUri(22);
             ((bool[]) buf[26])[0] = rslt.wasNull(22);
             ((string[]) buf[27])[0] = rslt.getVarchar(23);
             ((bool[]) buf[28])[0] = rslt.wasNull(23);
             ((Guid[]) buf[29])[0] = rslt.getGuid(24);
             ((Guid[]) buf[30])[0] = rslt.getGuid(25);
             ((bool[]) buf[31])[0] = rslt.wasNull(25);
             ((Guid[]) buf[32])[0] = rslt.getGuid(26);
             ((bool[]) buf[33])[0] = rslt.wasNull(26);
             ((string[]) buf[34])[0] = rslt.getMultimediaFile(27, rslt.getVarchar(5));
             ((string[]) buf[35])[0] = rslt.getMultimediaFile(28, rslt.getVarchar(22));
             ((bool[]) buf[36])[0] = rslt.wasNull(28);
             return;
          case 20 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
