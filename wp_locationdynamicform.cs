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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wp_locationdynamicform : GXDataArea
   {
      public wp_locationdynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_locationdynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormType ,
                           bool aP1_WWPFormIsForDynamicValidations )
      {
         this.AV47WWPFormType = aP0_WWPFormType;
         this.AV84WWPFormIsForDynamicValidations = aP1_WWPFormIsForDynamicValidations;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavOrganisationidfilter = new GXCombobox();
         dynavLocationidfilter = new GXCombobox();
         cmbavActiongroup = new GXCombobox();
         cmbWWPFormType = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "WWPFormType");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vORGANISATIONIDFILTER") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvORGANISATIONIDFILTER6B2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLOCATIONIDFILTER") == 0 )
            {
               AV82OrganisationIdFilter = StringUtil.StrToGuid( GetPar( "OrganisationIdFilter"));
               AssignAttri("", false, "AV82OrganisationIdFilter", AV82OrganisationIdFilter.ToString());
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvLOCATIONIDFILTER6B2( AV82OrganisationIdFilter) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPFormType");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPFormType");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_47 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_47"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_47_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_47_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_47_idx = GetPar( "sGXsfl_47_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6WWPContext);
         AV19ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV77ColumnsSelector);
         AV86Pgmname = GetPar( "Pgmname");
         AV47WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
         AV15FilterFullText = GetPar( "FilterFullText");
         AV22TFWWPFormTitle = GetPar( "TFWWPFormTitle");
         AV23TFWWPFormTitle_Sel = GetPar( "TFWWPFormTitle_Sel");
         AV20TFWWPFormReferenceName = GetPar( "TFWWPFormReferenceName");
         AV21TFWWPFormReferenceName_Sel = GetPar( "TFWWPFormReferenceName_Sel");
         AV24TFWWPFormDate = context.localUtil.ParseDTimeParm( GetPar( "TFWWPFormDate"));
         AV25TFWWPFormDate_To = context.localUtil.ParseDTimeParm( GetPar( "TFWWPFormDate_To"));
         AV29TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormVersionNumber"), "."), 18, MidpointRounding.ToEven));
         AV30TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormVersionNumber_To"), "."), 18, MidpointRounding.ToEven));
         AV31TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormLatestVersionNumber"), "."), 18, MidpointRounding.ToEven));
         AV32TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFWWPFormLatestVersionNumber_To"), "."), 18, MidpointRounding.ToEven));
         AV84WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
         AV49IsAuthorized_UserActionEdit = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionEdit"));
         AV51IsAuthorized_UserActionDisplay = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionDisplay"));
         AV80IsAuthorized_UserActionCopy = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionCopy"));
         AV81IsAuthorized_UserActionDelete = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionDelete"));
         AV70IsAuthorized_UserActionFilledForms = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionFilledForms"));
         AV72IsAuthorized_UserActionFillOutForm = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionFillOutForm"));
         AV85IsAuthorized_WWPFormTitle = StringUtil.StrToBool( GetPar( "IsAuthorized_WWPFormTitle"));
         dynavOrganisationidfilter.FromJSonString( GetNextPar( ));
         AV82OrganisationIdFilter = StringUtil.StrToGuid( GetPar( "OrganisationIdFilter"));
         A366LocationDynamicFormId = StringUtil.StrToGuid( GetPar( "LocationDynamicFormId"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV6WWPContext, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV86Pgmname, AV47WWPFormType, AV15FilterFullText, AV22TFWWPFormTitle, AV23TFWWPFormTitle_Sel, AV20TFWWPFormReferenceName, AV21TFWWPFormReferenceName_Sel, AV24TFWWPFormDate, AV25TFWWPFormDate_To, AV29TFWWPFormVersionNumber, AV30TFWWPFormVersionNumber_To, AV31TFWWPFormLatestVersionNumber, AV32TFWWPFormLatestVersionNumber_To, AV84WWPFormIsForDynamicValidations, AV49IsAuthorized_UserActionEdit, AV51IsAuthorized_UserActionDisplay, AV80IsAuthorized_UserActionCopy, AV81IsAuthorized_UserActionDelete, AV70IsAuthorized_UserActionFilledForms, AV72IsAuthorized_UserActionFillOutForm, AV85IsAuthorized_WWPFormTitle, AV82OrganisationIdFilter, A366LocationDynamicFormId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "wp_locationdynamicform_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA6B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6B2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1918140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_locationdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(AV47WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV84WWPFormIsForDynamicValidations));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_locationdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV86Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV86Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONEDIT", AV49IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( "", AV49IsAuthorized_UserActionEdit, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONDISPLAY", AV51IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( "", AV51IsAuthorized_UserActionDisplay, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONCOPY", AV80IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( "", AV80IsAuthorized_UserActionCopy, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONDELETE", AV81IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( "", AV81IsAuthorized_UserActionDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONFILLEDFORMS", AV70IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( "", AV70IsAuthorized_UserActionFilledForms, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONFILLOUTFORM", AV72IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( "", AV72IsAuthorized_UserActionFillOutForm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_WWPFORMTITLE", AV85IsAuthorized_WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_WWPFORMTITLE", GetSecureSignedToken( "", AV85IsAuthorized_WWPFormTitle, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONDYNAMICFORMID", A366LocationDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONDYNAMICFORMID", GetSecureSignedToken( "", A366LocationDynamicFormId, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47WWPFormType), "9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISFORDYNAMICVALIDATIONS", AV84WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV84WWPFormIsForDynamicValidations, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_47", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_47), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV39GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV33DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV33DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV77ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV77ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_WWPFORMDATEAUXDATE", context.localUtil.DToC( AV26DDO_WWPFormDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_WWPFORMDATEAUXDATETO", context.localUtil.DToC( AV27DDO_WWPFormDateAuxDateTo, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV86Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV86Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47WWPFormType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMTITLE", AV22TFWWPFormTitle);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMTITLE_SEL", AV23TFWWPFormTitle_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMREFERENCENAME", AV20TFWWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMREFERENCENAME_SEL", AV21TFWWPFormReferenceName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMDATE", context.localUtil.TToC( AV24TFWWPFormDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMDATE_TO", context.localUtil.TToC( AV25TFWWPFormDate_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29TFWWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMVERSIONNUMBER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TFWWPFormVersionNumber_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMLATESTVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFWWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMLATESTVERSIONNUMBER_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFWWPFormLatestVersionNumber_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISFORDYNAMICVALIDATIONS", AV84WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV84WWPFormIsForDynamicValidations, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONEDIT", AV49IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( "", AV49IsAuthorized_UserActionEdit, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONDISPLAY", AV51IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( "", AV51IsAuthorized_UserActionDisplay, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONCOPY", AV80IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( "", AV80IsAuthorized_UserActionCopy, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONDELETE", AV81IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( "", AV81IsAuthorized_UserActionDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONFILLEDFORMS", AV70IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( "", AV70IsAuthorized_UserActionFilledForms, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONFILLOUTFORM", AV72IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( "", AV72IsAuthorized_UserActionFillOutForm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_WWPFORMTITLE", AV85IsAuthorized_WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_WWPFORMTITLE", GetSecureSignedToken( "", AV85IsAuthorized_WWPFormTitle, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV61LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV60OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vRESULTMSG", AV58ResultMsg);
         GxWebStd.gx_hidden_field( context, "LOCATIONDYNAMICFORMID", A366LocationDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONDYNAMICFORMID", GetSecureSignedToken( "", A366LocationDynamicFormId, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Result));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractiondelete_Result));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE6B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6B2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_locationdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(AV47WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV84WWPFormIsForDynamicValidations));
         return formatLink("wp_locationdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_LocationDynamicForm" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Location Dynamic Form", "") ;
      }

      protected void WB6B0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuseractioninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", context.GetMessage( "Insert", ""), bttBtnuseractioninsert_Jsonclick, 5, context.GetMessage( "Insert", ""), "", StyleString, ClassString, bttBtnuseractioninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUSERACTIONINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_LocationDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_LocationDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(47), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_LocationDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV17ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WP_LocationDynamicForm.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOrganisationidfilter_cell_Internalname, 1, 0, "px", 0, "px", divOrganisationidfilter_cell_Class, "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", dynavOrganisationidfilter.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynavOrganisationidfilter_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_47_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavOrganisationidfilter, dynavOrganisationidfilter_Internalname, AV82OrganisationIdFilter.ToString(), 1, dynavOrganisationidfilter_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "guid", "", dynavOrganisationidfilter.Visible, dynavOrganisationidfilter.Enabled, 0, 0, 20, "em", 0, "", "", "AddressAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WP_LocationDynamicForm.htm");
            dynavOrganisationidfilter.CurrentValue = AV82OrganisationIdFilter.ToString();
            AssignProp("", false, dynavOrganisationidfilter_Internalname, "Values", (string)(dynavOrganisationidfilter.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLocationidfilter_cell_Internalname, 1, 0, "px", 0, "px", divLocationidfilter_cell_Class, "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", dynavLocationidfilter.Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynavLocationidfilter_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_47_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLocationidfilter, dynavLocationidfilter_Internalname, AV83LocationIdFilter.ToString(), 1, dynavLocationidfilter_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "guid", "", dynavLocationidfilter.Visible, dynavLocationidfilter.Enabled, 0, 0, 20, "em", 0, "", "", "AddressAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", true, 0, "HLP_WP_LocationDynamicForm.htm");
            dynavLocationidfilter.CurrentValue = AV83LocationIdFilter.ToString();
            AssignProp("", false, dynavLocationidfilter_Internalname, "Values", (string)(dynavLocationidfilter.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders GridHover HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl47( ) ;
         }
         if ( wbEnd == 47 )
         {
            wbEnd = 0;
            nRC_GXsfl_47 = (int)(nGXsfl_47_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV37GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV38GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV39GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV33DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormType, cmbWWPFormType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0)), 1, cmbWWPFormType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbWWPFormType.Visible, 0, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_WP_LocationDynamicForm.htm");
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp("", false, cmbWWPFormType_Internalname, "Values", (string)(cmbWWPFormType.ToJavascriptSource()), true);
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV33DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV77ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_67_6B2( true) ;
         }
         else
         {
            wb_table1_67_6B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_67_6B2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0074"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0074"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_47_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0074"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_wwpformdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_47_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_wwpformdateauxdatetext_Internalname, AV28DDO_WWPFormDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV28DDO_WWPFormDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_wwpformdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_LocationDynamicForm.htm");
            /* User Defined Control */
            ucTfwwpformdate_rangepicker.SetProperty("Start Date", AV26DDO_WWPFormDateAuxDate);
            ucTfwwpformdate_rangepicker.SetProperty("End Date", AV27DDO_WWPFormDateAuxDateTo);
            ucTfwwpformdate_rangepicker.Render(context, "wwp.daterangepicker", Tfwwpformdate_rangepicker_Internalname, "TFWWPFORMDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 47 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START6B2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Location Dynamic Form", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6B0( ) ;
      }

      protected void WS6B2( )
      {
         START6B2( ) ;
         EVT6B2( ) ;
      }

      protected void EVT6B2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E116B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E126B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E136B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E146B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E156B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E166B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_useractiondelete.Close */
                              E176B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTIONINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUserActionInsert' */
                              E186B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VLOCATIONIDFILTER.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E196B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              nGXsfl_47_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
                              SubsflControlProps_472( ) ;
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                              A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
                              A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
                              A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname), 0);
                              A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormLatestVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV71ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV71ActionGroup), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E206B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E216B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E226B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E236B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 74 )
                        {
                           OldWwpaux_wc = cgiGet( "W0074");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0074", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE6B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA6B2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_locationdynamicform.aspx")), "wp_locationdynamicform.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_locationdynamicform.aspx")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "WWPFormType");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV47WWPFormType = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV47WWPFormType", StringUtil.Str( (decimal)(AV47WWPFormType), 1, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47WWPFormType), "9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV84WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
                        AssignAttri("", false, "AV84WWPFormIsForDynamicValidations", AV84WWPFormIsForDynamicValidations);
                        GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV84WWPFormIsForDynamicValidations, context));
                     }
                  }
                  if ( toggleJsOutput )
                  {
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvORGANISATIONIDFILTER6B2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvORGANISATIONIDFILTER_data6B2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvORGANISATIONIDFILTER_html6B2( )
      {
         Guid gxdynajaxvalue;
         GXDLVvORGANISATIONIDFILTER_data6B2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavOrganisationidfilter.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavOrganisationidfilter.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvORGANISATIONIDFILTER_data6B2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(Guid.Empty.ToString());
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Organisation", ""));
         /* Using cursor H006B2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H006B2_A11OrganisationId[0].ToString());
            gxdynajaxctrldescr.Add(H006B2_A13OrganisationName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvLOCATIONIDFILTER6B2( Guid AV82OrganisationIdFilter )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLOCATIONIDFILTER_data6B2( AV82OrganisationIdFilter) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLOCATIONIDFILTER_html6B2( Guid AV82OrganisationIdFilter )
      {
         Guid gxdynajaxvalue;
         GXDLVvLOCATIONIDFILTER_data6B2( AV82OrganisationIdFilter) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLocationidfilter.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynavLocationidfilter.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvLOCATIONIDFILTER_data6B2( Guid AV82OrganisationIdFilter )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(Guid.Empty.ToString());
         gxdynajaxctrldescr.Add(context.GetMessage( "Select Location", ""));
         /* Using cursor H006B3 */
         pr_default.execute(1, new Object[] {AV82OrganisationIdFilter});
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(H006B3_A29LocationId[0].ToString());
            gxdynajaxctrldescr.Add(H006B3_A31LocationName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_472( ) ;
         while ( nGXsfl_47_idx <= nRC_GXsfl_47 )
         {
            sendrow_472( ) ;
            nGXsfl_47_idx = ((subGrid_Islastpage==1)&&(nGXsfl_47_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ,
                                       short AV19ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV77ColumnsSelector ,
                                       string AV86Pgmname ,
                                       short AV47WWPFormType ,
                                       string AV15FilterFullText ,
                                       string AV22TFWWPFormTitle ,
                                       string AV23TFWWPFormTitle_Sel ,
                                       string AV20TFWWPFormReferenceName ,
                                       string AV21TFWWPFormReferenceName_Sel ,
                                       DateTime AV24TFWWPFormDate ,
                                       DateTime AV25TFWWPFormDate_To ,
                                       short AV29TFWWPFormVersionNumber ,
                                       short AV30TFWWPFormVersionNumber_To ,
                                       short AV31TFWWPFormLatestVersionNumber ,
                                       short AV32TFWWPFormLatestVersionNumber_To ,
                                       bool AV84WWPFormIsForDynamicValidations ,
                                       bool AV49IsAuthorized_UserActionEdit ,
                                       bool AV51IsAuthorized_UserActionDisplay ,
                                       bool AV80IsAuthorized_UserActionCopy ,
                                       bool AV81IsAuthorized_UserActionDelete ,
                                       bool AV70IsAuthorized_UserActionFilledForms ,
                                       bool AV72IsAuthorized_UserActionFillOutForm ,
                                       bool AV85IsAuthorized_WWPFormTitle ,
                                       Guid AV82OrganisationIdFilter ,
                                       Guid A366LocationDynamicFormId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF6B2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "LOCATIONID", A29LocationId.ToString());
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvORGANISATIONIDFILTER_html6B2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavOrganisationidfilter.ItemCount > 0 )
         {
            AV82OrganisationIdFilter = StringUtil.StrToGuid( dynavOrganisationidfilter.getValidValue(AV82OrganisationIdFilter.ToString()));
            AssignAttri("", false, "AV82OrganisationIdFilter", AV82OrganisationIdFilter.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavOrganisationidfilter.CurrentValue = AV82OrganisationIdFilter.ToString();
            AssignProp("", false, dynavOrganisationidfilter_Internalname, "Values", dynavOrganisationidfilter.ToJavascriptSource(), true);
         }
         if ( dynavLocationidfilter.ItemCount > 0 )
         {
            AV83LocationIdFilter = StringUtil.StrToGuid( dynavLocationidfilter.getValidValue(AV83LocationIdFilter.ToString()));
            AssignAttri("", false, "AV83LocationIdFilter", AV83LocationIdFilter.ToString());
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationidfilter.CurrentValue = AV83LocationIdFilter.ToString();
            AssignProp("", false, dynavLocationidfilter_Internalname, "Values", dynavLocationidfilter.ToJavascriptSource(), true);
         }
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp("", false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF6B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV86Pgmname = "WP_LocationDynamicForm";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV87Wp_locationdynamicformds_1_wwpformtype = AV47WWPFormType;
         AV88Wp_locationdynamicformds_2_filterfulltext = AV15FilterFullText;
         AV89Wp_locationdynamicformds_3_tfwwpformtitle = AV22TFWWPFormTitle;
         AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel = AV23TFWWPFormTitle_Sel;
         AV91Wp_locationdynamicformds_5_tfwwpformreferencename = AV20TFWWPFormReferenceName;
         AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel = AV21TFWWPFormReferenceName_Sel;
         AV93Wp_locationdynamicformds_7_tfwwpformdate = AV24TFWWPFormDate;
         AV94Wp_locationdynamicformds_8_tfwwpformdate_to = AV25TFWWPFormDate_To;
         AV95Wp_locationdynamicformds_9_tfwwpformversionnumber = AV29TFWWPFormVersionNumber;
         AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to = AV30TFWWPFormVersionNumber_To;
         AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber = AV31TFWWPFormLatestVersionNumber;
         AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to = AV32TFWWPFormLatestVersionNumber_To;
         GRID_nRecordCount = 0;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel ,
                                              AV89Wp_locationdynamicformds_3_tfwwpformtitle ,
                                              AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel ,
                                              AV91Wp_locationdynamicformds_5_tfwwpformreferencename ,
                                              AV93Wp_locationdynamicformds_7_tfwwpformdate ,
                                              AV94Wp_locationdynamicformds_8_tfwwpformdate_to ,
                                              AV95Wp_locationdynamicformds_9_tfwwpformversionnumber ,
                                              AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to ,
                                              A209WWPFormTitle ,
                                              A208WWPFormReferenceName ,
                                              A231WWPFormDate ,
                                              A207WWPFormVersionNumber ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV88Wp_locationdynamicformds_2_filterfulltext ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber ,
                                              AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to ,
                                              A240WWPFormType ,
                                              AV87Wp_locationdynamicformds_1_wwpformtype ,
                                              A29LocationId ,
                                              AV61LocationId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV89Wp_locationdynamicformds_3_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV89Wp_locationdynamicformds_3_tfwwpformtitle), "%", "");
         lV91Wp_locationdynamicformds_5_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV91Wp_locationdynamicformds_5_tfwwpformreferencename), "%", "");
         /* Using cursor H006B4 */
         pr_default.execute(2, new Object[] {AV87Wp_locationdynamicformds_1_wwpformtype, AV61LocationId, lV89Wp_locationdynamicformds_3_tfwwpformtitle, AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel, lV91Wp_locationdynamicformds_5_tfwwpformreferencename, AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel, AV93Wp_locationdynamicformds_7_tfwwpformdate, AV94Wp_locationdynamicformds_8_tfwwpformdate_to, AV95Wp_locationdynamicformds_9_tfwwpformversionnumber, AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A366LocationDynamicFormId = H006B4_A366LocationDynamicFormId[0];
            A240WWPFormType = H006B4_A240WWPFormType[0];
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A207WWPFormVersionNumber = H006B4_A207WWPFormVersionNumber[0];
            A231WWPFormDate = H006B4_A231WWPFormDate[0];
            A208WWPFormReferenceName = H006B4_A208WWPFormReferenceName[0];
            A209WWPFormTitle = H006B4_A209WWPFormTitle[0];
            A29LocationId = H006B4_A29LocationId[0];
            A11OrganisationId = H006B4_A11OrganisationId[0];
            A206WWPFormId = H006B4_A206WWPFormId[0];
            A240WWPFormType = H006B4_A240WWPFormType[0];
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            A231WWPFormDate = H006B4_A231WWPFormDate[0];
            A208WWPFormReferenceName = H006B4_A208WWPFormReferenceName[0];
            A209WWPFormTitle = H006B4_A209WWPFormTitle[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wp_locationdynamicformds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV88Wp_locationdynamicformds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A208WWPFormReferenceName) , StringUtil.PadR( "%" + StringUtil.Lower( AV88Wp_locationdynamicformds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV88Wp_locationdynamicformds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV88Wp_locationdynamicformds_2_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber) || ( ( A219WWPFormLatestVersionNumber >= AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber ) ) )
               {
                  if ( (0==AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to) || ( ( A219WWPFormLatestVersionNumber <= AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to ) ) )
                  {
                     if ( A207WWPFormVersionNumber == A219WWPFormLatestVersionNumber )
                     {
                        GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                     }
                  }
               }
            }
            pr_default.readNext(2);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(2);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF6B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 47;
         /* Execute user event: Refresh */
         E216B2 ();
         nGXsfl_47_idx = 1;
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_472( ) ;
         bGXsfl_47_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_472( ) ;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel ,
                                                 AV89Wp_locationdynamicformds_3_tfwwpformtitle ,
                                                 AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel ,
                                                 AV91Wp_locationdynamicformds_5_tfwwpformreferencename ,
                                                 AV93Wp_locationdynamicformds_7_tfwwpformdate ,
                                                 AV94Wp_locationdynamicformds_8_tfwwpformdate_to ,
                                                 AV95Wp_locationdynamicformds_9_tfwwpformversionnumber ,
                                                 AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to ,
                                                 A209WWPFormTitle ,
                                                 A208WWPFormReferenceName ,
                                                 A231WWPFormDate ,
                                                 A207WWPFormVersionNumber ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV88Wp_locationdynamicformds_2_filterfulltext ,
                                                 A219WWPFormLatestVersionNumber ,
                                                 AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber ,
                                                 AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to ,
                                                 A240WWPFormType ,
                                                 AV87Wp_locationdynamicformds_1_wwpformtype ,
                                                 A29LocationId ,
                                                 AV61LocationId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV89Wp_locationdynamicformds_3_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV89Wp_locationdynamicformds_3_tfwwpformtitle), "%", "");
            lV91Wp_locationdynamicformds_5_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV91Wp_locationdynamicformds_5_tfwwpformreferencename), "%", "");
            /* Using cursor H006B5 */
            pr_default.execute(3, new Object[] {AV87Wp_locationdynamicformds_1_wwpformtype, AV61LocationId, lV89Wp_locationdynamicformds_3_tfwwpformtitle, AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel, lV91Wp_locationdynamicformds_5_tfwwpformreferencename, AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel, AV93Wp_locationdynamicformds_7_tfwwpformdate, AV94Wp_locationdynamicformds_8_tfwwpformdate_to, AV95Wp_locationdynamicformds_9_tfwwpformversionnumber, AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to});
            nGXsfl_47_idx = 1;
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A366LocationDynamicFormId = H006B5_A366LocationDynamicFormId[0];
               A240WWPFormType = H006B5_A240WWPFormType[0];
               AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
               A207WWPFormVersionNumber = H006B5_A207WWPFormVersionNumber[0];
               A231WWPFormDate = H006B5_A231WWPFormDate[0];
               A208WWPFormReferenceName = H006B5_A208WWPFormReferenceName[0];
               A209WWPFormTitle = H006B5_A209WWPFormTitle[0];
               A29LocationId = H006B5_A29LocationId[0];
               A11OrganisationId = H006B5_A11OrganisationId[0];
               A206WWPFormId = H006B5_A206WWPFormId[0];
               A240WWPFormType = H006B5_A240WWPFormType[0];
               AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
               A231WWPFormDate = H006B5_A231WWPFormDate[0];
               A208WWPFormReferenceName = H006B5_A208WWPFormReferenceName[0];
               A209WWPFormTitle = H006B5_A209WWPFormTitle[0];
               GXt_int1 = A219WWPFormLatestVersionNumber;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
               A219WWPFormLatestVersionNumber = GXt_int1;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wp_locationdynamicformds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV88Wp_locationdynamicformds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A208WWPFormReferenceName) , StringUtil.PadR( "%" + StringUtil.Lower( AV88Wp_locationdynamicformds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV88Wp_locationdynamicformds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV88Wp_locationdynamicformds_2_filterfulltext , 254 , "%"),  ' ' ) ) ) )
               {
                  if ( (0==AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber) || ( ( A219WWPFormLatestVersionNumber >= AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber ) ) )
                  {
                     if ( (0==AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to) || ( ( A219WWPFormLatestVersionNumber <= AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to ) ) )
                     {
                        if ( A207WWPFormVersionNumber == A219WWPFormLatestVersionNumber )
                        {
                           /* Execute user event: Grid.Load */
                           E226B2 ();
                        }
                     }
                  }
               }
               pr_default.readNext(3);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 47;
            WB6B0( ) ;
         }
         bGXsfl_47_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6B2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV6WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV86Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV86Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONEDIT", AV49IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( "", AV49IsAuthorized_UserActionEdit, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONDISPLAY", AV51IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( "", AV51IsAuthorized_UserActionDisplay, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONCOPY", AV80IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( "", AV80IsAuthorized_UserActionCopy, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONDELETE", AV81IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( "", AV81IsAuthorized_UserActionDelete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONFILLEDFORMS", AV70IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( "", AV70IsAuthorized_UserActionFilledForms, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONFILLOUTFORM", AV72IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( "", AV72IsAuthorized_UserActionFillOutForm, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_WWPFORMTITLE", AV85IsAuthorized_WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_WWPFORMTITLE", GetSecureSignedToken( "", AV85IsAuthorized_WWPFormTitle, context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID"+"_"+sGXsfl_47_idx, GetSecureSignedToken( sGXsfl_47_idx, context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER"+"_"+sGXsfl_47_idx, GetSecureSignedToken( sGXsfl_47_idx, context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "LOCATIONDYNAMICFORMID", A366LocationDynamicFormId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONDYNAMICFORMID", GetSecureSignedToken( "", A366LocationDynamicFormId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID"+"_"+sGXsfl_47_idx, GetSecureSignedToken( sGXsfl_47_idx, A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID"+"_"+sGXsfl_47_idx, GetSecureSignedToken( sGXsfl_47_idx, A29LocationId, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(subGridclient_rec_count_fnc()) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV87Wp_locationdynamicformds_1_wwpformtype = AV47WWPFormType;
         AV88Wp_locationdynamicformds_2_filterfulltext = AV15FilterFullText;
         AV89Wp_locationdynamicformds_3_tfwwpformtitle = AV22TFWWPFormTitle;
         AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel = AV23TFWWPFormTitle_Sel;
         AV91Wp_locationdynamicformds_5_tfwwpformreferencename = AV20TFWWPFormReferenceName;
         AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel = AV21TFWWPFormReferenceName_Sel;
         AV93Wp_locationdynamicformds_7_tfwwpformdate = AV24TFWWPFormDate;
         AV94Wp_locationdynamicformds_8_tfwwpformdate_to = AV25TFWWPFormDate_To;
         AV95Wp_locationdynamicformds_9_tfwwpformversionnumber = AV29TFWWPFormVersionNumber;
         AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to = AV30TFWWPFormVersionNumber_To;
         AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber = AV31TFWWPFormLatestVersionNumber;
         AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to = AV32TFWWPFormLatestVersionNumber_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV6WWPContext, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV86Pgmname, AV47WWPFormType, AV15FilterFullText, AV22TFWWPFormTitle, AV23TFWWPFormTitle_Sel, AV20TFWWPFormReferenceName, AV21TFWWPFormReferenceName_Sel, AV24TFWWPFormDate, AV25TFWWPFormDate_To, AV29TFWWPFormVersionNumber, AV30TFWWPFormVersionNumber_To, AV31TFWWPFormLatestVersionNumber, AV32TFWWPFormLatestVersionNumber_To, AV84WWPFormIsForDynamicValidations, AV49IsAuthorized_UserActionEdit, AV51IsAuthorized_UserActionDisplay, AV80IsAuthorized_UserActionCopy, AV81IsAuthorized_UserActionDelete, AV70IsAuthorized_UserActionFilledForms, AV72IsAuthorized_UserActionFillOutForm, AV85IsAuthorized_WWPFormTitle, AV82OrganisationIdFilter, A366LocationDynamicFormId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV87Wp_locationdynamicformds_1_wwpformtype = AV47WWPFormType;
         AV88Wp_locationdynamicformds_2_filterfulltext = AV15FilterFullText;
         AV89Wp_locationdynamicformds_3_tfwwpformtitle = AV22TFWWPFormTitle;
         AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel = AV23TFWWPFormTitle_Sel;
         AV91Wp_locationdynamicformds_5_tfwwpformreferencename = AV20TFWWPFormReferenceName;
         AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel = AV21TFWWPFormReferenceName_Sel;
         AV93Wp_locationdynamicformds_7_tfwwpformdate = AV24TFWWPFormDate;
         AV94Wp_locationdynamicformds_8_tfwwpformdate_to = AV25TFWWPFormDate_To;
         AV95Wp_locationdynamicformds_9_tfwwpformversionnumber = AV29TFWWPFormVersionNumber;
         AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to = AV30TFWWPFormVersionNumber_To;
         AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber = AV31TFWWPFormLatestVersionNumber;
         AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to = AV32TFWWPFormLatestVersionNumber_To;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV6WWPContext, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV86Pgmname, AV47WWPFormType, AV15FilterFullText, AV22TFWWPFormTitle, AV23TFWWPFormTitle_Sel, AV20TFWWPFormReferenceName, AV21TFWWPFormReferenceName_Sel, AV24TFWWPFormDate, AV25TFWWPFormDate_To, AV29TFWWPFormVersionNumber, AV30TFWWPFormVersionNumber_To, AV31TFWWPFormLatestVersionNumber, AV32TFWWPFormLatestVersionNumber_To, AV84WWPFormIsForDynamicValidations, AV49IsAuthorized_UserActionEdit, AV51IsAuthorized_UserActionDisplay, AV80IsAuthorized_UserActionCopy, AV81IsAuthorized_UserActionDelete, AV70IsAuthorized_UserActionFilledForms, AV72IsAuthorized_UserActionFillOutForm, AV85IsAuthorized_WWPFormTitle, AV82OrganisationIdFilter, A366LocationDynamicFormId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV87Wp_locationdynamicformds_1_wwpformtype = AV47WWPFormType;
         AV88Wp_locationdynamicformds_2_filterfulltext = AV15FilterFullText;
         AV89Wp_locationdynamicformds_3_tfwwpformtitle = AV22TFWWPFormTitle;
         AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel = AV23TFWWPFormTitle_Sel;
         AV91Wp_locationdynamicformds_5_tfwwpformreferencename = AV20TFWWPFormReferenceName;
         AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel = AV21TFWWPFormReferenceName_Sel;
         AV93Wp_locationdynamicformds_7_tfwwpformdate = AV24TFWWPFormDate;
         AV94Wp_locationdynamicformds_8_tfwwpformdate_to = AV25TFWWPFormDate_To;
         AV95Wp_locationdynamicformds_9_tfwwpformversionnumber = AV29TFWWPFormVersionNumber;
         AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to = AV30TFWWPFormVersionNumber_To;
         AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber = AV31TFWWPFormLatestVersionNumber;
         AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to = AV32TFWWPFormLatestVersionNumber_To;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV6WWPContext, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV86Pgmname, AV47WWPFormType, AV15FilterFullText, AV22TFWWPFormTitle, AV23TFWWPFormTitle_Sel, AV20TFWWPFormReferenceName, AV21TFWWPFormReferenceName_Sel, AV24TFWWPFormDate, AV25TFWWPFormDate_To, AV29TFWWPFormVersionNumber, AV30TFWWPFormVersionNumber_To, AV31TFWWPFormLatestVersionNumber, AV32TFWWPFormLatestVersionNumber_To, AV84WWPFormIsForDynamicValidations, AV49IsAuthorized_UserActionEdit, AV51IsAuthorized_UserActionDisplay, AV80IsAuthorized_UserActionCopy, AV81IsAuthorized_UserActionDelete, AV70IsAuthorized_UserActionFilledForms, AV72IsAuthorized_UserActionFillOutForm, AV85IsAuthorized_WWPFormTitle, AV82OrganisationIdFilter, A366LocationDynamicFormId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV87Wp_locationdynamicformds_1_wwpformtype = AV47WWPFormType;
         AV88Wp_locationdynamicformds_2_filterfulltext = AV15FilterFullText;
         AV89Wp_locationdynamicformds_3_tfwwpformtitle = AV22TFWWPFormTitle;
         AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel = AV23TFWWPFormTitle_Sel;
         AV91Wp_locationdynamicformds_5_tfwwpformreferencename = AV20TFWWPFormReferenceName;
         AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel = AV21TFWWPFormReferenceName_Sel;
         AV93Wp_locationdynamicformds_7_tfwwpformdate = AV24TFWWPFormDate;
         AV94Wp_locationdynamicformds_8_tfwwpformdate_to = AV25TFWWPFormDate_To;
         AV95Wp_locationdynamicformds_9_tfwwpformversionnumber = AV29TFWWPFormVersionNumber;
         AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to = AV30TFWWPFormVersionNumber_To;
         AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber = AV31TFWWPFormLatestVersionNumber;
         AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to = AV32TFWWPFormLatestVersionNumber_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV6WWPContext, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV86Pgmname, AV47WWPFormType, AV15FilterFullText, AV22TFWWPFormTitle, AV23TFWWPFormTitle_Sel, AV20TFWWPFormReferenceName, AV21TFWWPFormReferenceName_Sel, AV24TFWWPFormDate, AV25TFWWPFormDate_To, AV29TFWWPFormVersionNumber, AV30TFWWPFormVersionNumber_To, AV31TFWWPFormLatestVersionNumber, AV32TFWWPFormLatestVersionNumber_To, AV84WWPFormIsForDynamicValidations, AV49IsAuthorized_UserActionEdit, AV51IsAuthorized_UserActionDisplay, AV80IsAuthorized_UserActionCopy, AV81IsAuthorized_UserActionDelete, AV70IsAuthorized_UserActionFilledForms, AV72IsAuthorized_UserActionFillOutForm, AV85IsAuthorized_WWPFormTitle, AV82OrganisationIdFilter, A366LocationDynamicFormId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV87Wp_locationdynamicformds_1_wwpformtype = AV47WWPFormType;
         AV88Wp_locationdynamicformds_2_filterfulltext = AV15FilterFullText;
         AV89Wp_locationdynamicformds_3_tfwwpformtitle = AV22TFWWPFormTitle;
         AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel = AV23TFWWPFormTitle_Sel;
         AV91Wp_locationdynamicformds_5_tfwwpformreferencename = AV20TFWWPFormReferenceName;
         AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel = AV21TFWWPFormReferenceName_Sel;
         AV93Wp_locationdynamicformds_7_tfwwpformdate = AV24TFWWPFormDate;
         AV94Wp_locationdynamicformds_8_tfwwpformdate_to = AV25TFWWPFormDate_To;
         AV95Wp_locationdynamicformds_9_tfwwpformversionnumber = AV29TFWWPFormVersionNumber;
         AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to = AV30TFWWPFormVersionNumber_To;
         AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber = AV31TFWWPFormLatestVersionNumber;
         AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to = AV32TFWWPFormLatestVersionNumber_To;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV6WWPContext, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV86Pgmname, AV47WWPFormType, AV15FilterFullText, AV22TFWWPFormTitle, AV23TFWWPFormTitle_Sel, AV20TFWWPFormReferenceName, AV21TFWWPFormReferenceName_Sel, AV24TFWWPFormDate, AV25TFWWPFormDate_To, AV29TFWWPFormVersionNumber, AV30TFWWPFormVersionNumber_To, AV31TFWWPFormLatestVersionNumber, AV32TFWWPFormLatestVersionNumber_To, AV84WWPFormIsForDynamicValidations, AV49IsAuthorized_UserActionEdit, AV51IsAuthorized_UserActionDisplay, AV80IsAuthorized_UserActionCopy, AV81IsAuthorized_UserActionDelete, AV70IsAuthorized_UserActionFilledForms, AV72IsAuthorized_UserActionFillOutForm, AV85IsAuthorized_WWPFormTitle, AV82OrganisationIdFilter, A366LocationDynamicFormId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV86Pgmname = "WP_LocationDynamicForm";
         GXVvORGANISATIONIDFILTER_html6B2( ) ;
         edtOrganisationId_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormDate_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormLatestVersionNumber_Enabled = 0;
         cmbWWPFormType.Enabled = 0;
         AssignProp("", false, cmbWWPFormType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E206B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         GXVvLOCATIONIDFILTER_html6B2( AV82OrganisationIdFilter) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV33DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV77ColumnsSelector);
            ajax_req_read_hidden_sdt(cgiGet( "vWWPCONTEXT"), AV6WWPContext);
            /* Read saved values. */
            nRC_GXsfl_47 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_47"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV37GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV38GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV39GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV26DDO_WWPFormDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_WWPFORMDATEAUXDATE"), 0);
            AV27DDO_WWPFormDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_WWPFORMDATEAUXDATETO"), 0);
            AV60OrganisationId = StringUtil.StrToGuid( cgiGet( "vORGANISATIONID"));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( "DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Dvelop_confirmpanel_useractiondelete_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Title");
            Dvelop_confirmpanel_useractiondelete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmationtext");
            Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Nobuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractiondelete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Yesbuttonposition");
            Dvelop_confirmpanel_useractiondelete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_useractiondelete_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONDELETE_Result");
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            dynavOrganisationidfilter.Name = dynavOrganisationidfilter_Internalname;
            dynavOrganisationidfilter.CurrentValue = cgiGet( dynavOrganisationidfilter_Internalname);
            AV82OrganisationIdFilter = StringUtil.StrToGuid( cgiGet( dynavOrganisationidfilter_Internalname));
            AssignAttri("", false, "AV82OrganisationIdFilter", AV82OrganisationIdFilter.ToString());
            dynavLocationidfilter.Name = dynavLocationidfilter_Internalname;
            dynavLocationidfilter.CurrentValue = cgiGet( dynavLocationidfilter_Internalname);
            AV83LocationIdFilter = StringUtil.StrToGuid( cgiGet( dynavLocationidfilter_Internalname));
            AssignAttri("", false, "AV83LocationIdFilter", AV83LocationIdFilter.ToString());
            cmbWWPFormType.Name = cmbWWPFormType_Internalname;
            cmbWWPFormType.CurrentValue = cgiGet( cmbWWPFormType_Internalname);
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AV28DDO_WWPFormDateAuxDateText = cgiGet( edtavDdo_wwpformdateauxdatetext_Internalname);
            AssignAttri("", false, "AV28DDO_WWPFormDateAuxDateText", AV28DDO_WWPFormDateAuxDateText);
            /* Read subfile selected row values. */
            nGXsfl_47_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
            if ( nGXsfl_47_idx > 0 )
            {
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
               A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
               A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
               A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname));
               A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A219WWPFormLatestVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormLatestVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV71ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV71ActionGroup), 4, 0));
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E206B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E206B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( ! (Guid.Empty==AV6WWPContext.gxTpr_Organisationid) )
         {
            AV82OrganisationIdFilter = AV6WWPContext.gxTpr_Organisationid;
            AssignAttri("", false, "AV82OrganisationIdFilter", AV82OrganisationIdFilter.ToString());
            AV60OrganisationId = AV6WWPContext.gxTpr_Organisationid;
            AssignAttri("", false, "AV60OrganisationId", AV60OrganisationId.ToString());
         }
         if ( ! (Guid.Empty==AV6WWPContext.gxTpr_Locationid) )
         {
            AV83LocationIdFilter = AV6WWPContext.gxTpr_Locationid;
            AssignAttri("", false, "AV83LocationIdFilter", AV83LocationIdFilter.ToString());
            AV61LocationId = AV6WWPContext.gxTpr_Locationid;
            AssignAttri("", false, "AV61LocationId", AV61LocationId.ToString());
         }
         this.executeUsercontrolMethod("", false, "TFWWPFORMDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_wwpformdateauxdatetext_Internalname});
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean2 = AV85IsAuthorized_WWPFormTitle;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "ucreatedynamicform_Execute", out  GXt_boolean2) ;
         AV85IsAuthorized_WWPFormTitle = GXt_boolean2;
         AssignAttri("", false, "AV85IsAuthorized_WWPFormTitle", AV85IsAuthorized_WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_WWPFORMTITLE", GetSecureSignedToken( "", AV85IsAuthorized_WWPFormTitle, context));
         AV34GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV35GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV34GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( "Location Dynamic Form", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         cmbWWPFormType.Visible = 0;
         AssignProp("", false, cmbWWPFormType_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = AV33DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3) ;
         AV33DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E216B2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV61LocationId = AV6WWPContext.gxTpr_Locationid;
         AssignAttri("", false, "AV61LocationId", AV61LocationId.ToString());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV19ManageFiltersExecutionStep == 1 )
         {
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV19ManageFiltersExecutionStep == 2 )
         {
            AV19ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV16Session.Get("WP_LocationDynamicFormColumnsSelector"), "") != 0 )
         {
            AV75ColumnsSelectorXML = AV16Session.Get("WP_LocationDynamicFormColumnsSelector");
            AV77ColumnsSelector.FromXml(AV75ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtWWPFormTitle_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV77ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormTitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Visible), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormReferenceName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV77ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormReferenceName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormReferenceName_Visible), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormDate_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV77ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Visible), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormVersionNumber_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV77ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormVersionNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormVersionNumber_Visible), 5, 0), !bGXsfl_47_Refreshing);
         edtWWPFormLatestVersionNumber_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV77ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormLatestVersionNumber_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormLatestVersionNumber_Visible), 5, 0), !bGXsfl_47_Refreshing);
         AV37GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV37GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV37GridCurrentPage), 10, 0));
         AV38GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV38GridPageCount", StringUtil.LTrimStr( (decimal)(AV38GridPageCount), 10, 0));
         GXt_char4 = AV39GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV86Pgmname, out  GXt_char4) ;
         AV39GridAppliedFilters = GXt_char4;
         AssignAttri("", false, "AV39GridAppliedFilters", AV39GridAppliedFilters);
         AV87Wp_locationdynamicformds_1_wwpformtype = AV47WWPFormType;
         AV88Wp_locationdynamicformds_2_filterfulltext = AV15FilterFullText;
         AV89Wp_locationdynamicformds_3_tfwwpformtitle = AV22TFWWPFormTitle;
         AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel = AV23TFWWPFormTitle_Sel;
         AV91Wp_locationdynamicformds_5_tfwwpformreferencename = AV20TFWWPFormReferenceName;
         AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel = AV21TFWWPFormReferenceName_Sel;
         AV93Wp_locationdynamicformds_7_tfwwpformdate = AV24TFWWPFormDate;
         AV94Wp_locationdynamicformds_8_tfwwpformdate_to = AV25TFWWPFormDate_To;
         AV95Wp_locationdynamicformds_9_tfwwpformversionnumber = AV29TFWWPFormVersionNumber;
         AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to = AV30TFWWPFormVersionNumber_To;
         AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber = AV31TFWWPFormLatestVersionNumber;
         AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to = AV32TFWWPFormLatestVersionNumber_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E126B2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV36PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV36PageToGo) ;
         }
      }

      protected void E136B2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E156B2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormTitle") == 0 )
            {
               AV22TFWWPFormTitle = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV22TFWWPFormTitle", AV22TFWWPFormTitle);
               AV23TFWWPFormTitle_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV23TFWWPFormTitle_Sel", AV23TFWWPFormTitle_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormReferenceName") == 0 )
            {
               AV20TFWWPFormReferenceName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV20TFWWPFormReferenceName", AV20TFWWPFormReferenceName);
               AV21TFWWPFormReferenceName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV21TFWWPFormReferenceName_Sel", AV21TFWWPFormReferenceName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormDate") == 0 )
            {
               AV24TFWWPFormDate = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV24TFWWPFormDate", context.localUtil.TToC( AV24TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV25TFWWPFormDate_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV25TFWWPFormDate_To", context.localUtil.TToC( AV25TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV25TFWWPFormDate_To) )
               {
                  AV25TFWWPFormDate_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV25TFWWPFormDate_To)), (short)(DateTimeUtil.Month( AV25TFWWPFormDate_To)), (short)(DateTimeUtil.Day( AV25TFWWPFormDate_To)), 23, 59, 59);
                  AssignAttri("", false, "AV25TFWWPFormDate_To", context.localUtil.TToC( AV25TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormVersionNumber") == 0 )
            {
               AV29TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV29TFWWPFormVersionNumber), 4, 0));
               AV30TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV30TFWWPFormVersionNumber_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormLatestVersionNumber") == 0 )
            {
               AV31TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV31TFWWPFormLatestVersionNumber), 4, 0));
               AV32TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV32TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV32TFWWPFormLatestVersionNumber_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E226B2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            if ( AV49IsAuthorized_UserActionEdit )
            {
               cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fas fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV51IsAuthorized_UserActionDisplay )
            {
               cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Display", ""), "fas fa-magnifying-glass", "", "", "", "", "", "", ""), 0);
            }
            if ( AV80IsAuthorized_UserActionCopy )
            {
               cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Copy", ""), "fa-clone far", "", "", "", "", "", "", ""), 0);
            }
            if ( AV81IsAuthorized_UserActionDelete )
            {
               cmbavActiongroup.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            }
            if ( AV70IsAuthorized_UserActionFilledForms )
            {
               cmbavActiongroup.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "Filled forms", ""), "far fa-eye", "", "", "", "", "", "", ""), 0);
            }
            if ( AV72IsAuthorized_UserActionFillOutForm )
            {
               cmbavActiongroup.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "fill out form", ""), "fas fa-file-circle-plus", "", "", "", "", "", "", ""), 0);
            }
            if ( cmbavActiongroup.ItemCount == 1 )
            {
               cmbavActiongroup_Class = "Invisible";
            }
            else
            {
               cmbavActiongroup_Class = "ConvertToDDO";
            }
            if ( AV85IsAuthorized_WWPFormTitle )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "ucreatedynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(A240WWPFormType,1,0));
               edtWWPFormTitle_Link = formatLink("ucreatedynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 47;
            }
            sendrow_472( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_47_Refreshing )
         {
            DoAjaxLoad(47, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV71ActionGroup), 4, 0));
      }

      protected void E166B2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV75ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV77ColumnsSelector.FromJSonString(AV75ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "WP_LocationDynamicFormColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV75ColumnsSelectorXML)) ? "" : AV77ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E116B2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WP_LocationDynamicFormFilters")) + "," + UrlEncode(StringUtil.RTrim(AV86Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WP_LocationDynamicFormFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char4 = AV18ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WP_LocationDynamicFormFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char4) ;
            AV18ManageFiltersXml = GXt_char4;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV86Pgmname+"GridState",  AV18ManageFiltersXml) ;
               AV11GridState.FromXml(AV18ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S152 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E236B2( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV71ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO USERACTIONEDIT' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV71ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO USERACTIONDISPLAY' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV71ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO USERACTIONCOPY' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV71ActionGroup == 4 )
         {
            /* Execute user subroutine: 'DO USERACTIONDELETE' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV71ActionGroup == 5 )
         {
            /* Execute user subroutine: 'DO USERACTIONFILLEDFORMS' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV71ActionGroup == 6 )
         {
            /* Execute user subroutine: 'DO USERACTIONFILLOUTFORM' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV71ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV71ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV71ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E176B2( )
      {
         /* Dvelop_confirmpanel_useractiondelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractiondelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONDELETE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E186B2( )
      {
         /* 'DoUserActionInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "ucreatedynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(AV47WWPFormType,1,0));
         CallWebObject(formatLink("ucreatedynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E146B2( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0074",(string)"",(string)"Trn_LocationDynamicForm",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0074"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S152( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV77ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV77ColumnsSelector,  "WWPFormTitle",  "",  "Title",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV77ColumnsSelector,  "WWPFormReferenceName",  "",  "Reference Name",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV77ColumnsSelector,  "WWPFormDate",  "",  "Date",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV77ColumnsSelector,  "WWPFormVersionNumber",  "",  "Form Version #",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV77ColumnsSelector,  "WWPFormLatestVersionNumber",  "",  "Latest Version",  true,  "") ;
         GXt_char4 = AV76UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WP_LocationDynamicFormColumnsSelector", out  GXt_char4) ;
         AV76UserCustomValue = GXt_char4;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV76UserCustomValue)) ) )
         {
            AV78ColumnsSelectorAux.FromXml(AV76UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV78ColumnsSelectorAux, ref  AV77ColumnsSelector) ;
         }
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean2 = AV49IsAuthorized_UserActionEdit;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wp_locationdynamicform_edit", out  GXt_boolean2) ;
         AV49IsAuthorized_UserActionEdit = GXt_boolean2;
         AssignAttri("", false, "AV49IsAuthorized_UserActionEdit", AV49IsAuthorized_UserActionEdit);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONEDIT", GetSecureSignedToken( "", AV49IsAuthorized_UserActionEdit, context));
         GXt_boolean2 = AV51IsAuthorized_UserActionDisplay;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "ucreatedynamicform_Execute", out  GXt_boolean2) ;
         AV51IsAuthorized_UserActionDisplay = GXt_boolean2;
         AssignAttri("", false, "AV51IsAuthorized_UserActionDisplay", AV51IsAuthorized_UserActionDisplay);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONDISPLAY", GetSecureSignedToken( "", AV51IsAuthorized_UserActionDisplay, context));
         GXt_boolean2 = AV80IsAuthorized_UserActionCopy;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wp_locationdynamicform_copy", out  GXt_boolean2) ;
         AV80IsAuthorized_UserActionCopy = GXt_boolean2;
         AssignAttri("", false, "AV80IsAuthorized_UserActionCopy", AV80IsAuthorized_UserActionCopy);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONCOPY", GetSecureSignedToken( "", AV80IsAuthorized_UserActionCopy, context));
         GXt_boolean2 = AV81IsAuthorized_UserActionDelete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wp_locationdynamicform_delete", out  GXt_boolean2) ;
         AV81IsAuthorized_UserActionDelete = GXt_boolean2;
         AssignAttri("", false, "AV81IsAuthorized_UserActionDelete", AV81IsAuthorized_UserActionDelete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONDELETE", GetSecureSignedToken( "", AV81IsAuthorized_UserActionDelete, context));
         GXt_boolean2 = AV70IsAuthorized_UserActionFilledForms;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wp_locationdynamicform_filledforms", out  GXt_boolean2) ;
         AV70IsAuthorized_UserActionFilledForms = GXt_boolean2;
         AssignAttri("", false, "AV70IsAuthorized_UserActionFilledForms", AV70IsAuthorized_UserActionFilledForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONFILLEDFORMS", GetSecureSignedToken( "", AV70IsAuthorized_UserActionFilledForms, context));
         GXt_boolean2 = AV72IsAuthorized_UserActionFillOutForm;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wp_locationdynamicform_filloutform", out  GXt_boolean2) ;
         AV72IsAuthorized_UserActionFillOutForm = GXt_boolean2;
         AssignAttri("", false, "AV72IsAuthorized_UserActionFillOutForm", AV72IsAuthorized_UserActionFillOutForm);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONFILLOUTFORM", GetSecureSignedToken( "", AV72IsAuthorized_UserActionFillOutForm, context));
         GXt_boolean2 = AV73IsAuthorized_UserActionInsert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "wp_locationdynamicform_insert", out  GXt_boolean2) ;
         AV73IsAuthorized_UserActionInsert = GXt_boolean2;
         if ( ! ( AV73IsAuthorized_UserActionInsert ) )
         {
            bttBtnuseractioninsert_Visible = 0;
            AssignProp("", false, bttBtnuseractioninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuseractioninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_LocationDynamicForm",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV17ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WP_LocationDynamicFormFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV22TFWWPFormTitle = "";
         AssignAttri("", false, "AV22TFWWPFormTitle", AV22TFWWPFormTitle);
         AV23TFWWPFormTitle_Sel = "";
         AssignAttri("", false, "AV23TFWWPFormTitle_Sel", AV23TFWWPFormTitle_Sel);
         AV20TFWWPFormReferenceName = "";
         AssignAttri("", false, "AV20TFWWPFormReferenceName", AV20TFWWPFormReferenceName);
         AV21TFWWPFormReferenceName_Sel = "";
         AssignAttri("", false, "AV21TFWWPFormReferenceName_Sel", AV21TFWWPFormReferenceName_Sel);
         AV24TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV24TFWWPFormDate", context.localUtil.TToC( AV24TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV25TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV25TFWWPFormDate_To", context.localUtil.TToC( AV25TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV29TFWWPFormVersionNumber = 0;
         AssignAttri("", false, "AV29TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV29TFWWPFormVersionNumber), 4, 0));
         AV30TFWWPFormVersionNumber_To = 0;
         AssignAttri("", false, "AV30TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV30TFWWPFormVersionNumber_To), 4, 0));
         AV31TFWWPFormLatestVersionNumber = 0;
         AssignAttri("", false, "AV31TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV31TFWWPFormLatestVersionNumber), 4, 0));
         AV32TFWWPFormLatestVersionNumber_To = 0;
         AssignAttri("", false, "AV32TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV32TFWWPFormLatestVersionNumber_To), 4, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
      {
         /* 'DO USERACTIONEDIT' Routine */
         returnInSub = false;
         if ( AV49IsAuthorized_UserActionEdit )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "ucreatedynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(A240WWPFormType,1,0));
            CallWebObject(formatLink("ucreatedynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S222( )
      {
         /* 'DO USERACTIONDISPLAY' Routine */
         returnInSub = false;
         if ( AV51IsAuthorized_UserActionDisplay )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "ucreatedynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(A240WWPFormType,1,0));
            CallWebObject(formatLink("ucreatedynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S232( )
      {
         /* 'DO USERACTIONCOPY' Routine */
         returnInSub = false;
         AV52WWPForm.Load(A206WWPFormId, A207WWPFormVersionNumber);
         AV53CopyNumber = 1;
         AV54WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV53CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         while ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  0,  AV54WWPFormReferenceName) )
         {
            AV53CopyNumber = (short)(AV53CopyNumber+1);
            AV54WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV53CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         }
         AV55NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         /* Using cursor H006B6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A206WWPFormId = H006B6_A206WWPFormId[0];
            AV55NewWWPForm.gxTpr_Wwpformid = A206WWPFormId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV55NewWWPForm.gxTpr_Wwpformid = (short)(AV55NewWWPForm.gxTpr_Wwpformid+1);
         AV55NewWWPForm.gxTpr_Wwpformversionnumber = 1;
         AV55NewWWPForm.gxTpr_Wwpformreferencename = AV54WWPFormReferenceName;
         AV55NewWWPForm.gxTpr_Wwpformtitle = AV52WWPForm.gxTpr_Wwpformtitle;
         AV55NewWWPForm.gxTpr_Wwpformiswizard = AV52WWPForm.gxTpr_Wwpformiswizard;
         AV55NewWWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
         AV55NewWWPForm.gxTpr_Wwpformvalidations = AV52WWPForm.gxTpr_Wwpformvalidations;
         AV55NewWWPForm.gxTpr_Wwpformresume = AV52WWPForm.gxTpr_Wwpformresume;
         AV55NewWWPForm.gxTpr_Wwpformresumemessage = AV52WWPForm.gxTpr_Wwpformresumemessage;
         AV100GXV1 = 1;
         while ( AV100GXV1 <= AV52WWPForm.gxTpr_Element.Count )
         {
            AV56Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV52WWPForm.gxTpr_Element.Item(AV100GXV1));
            if ( AV56Element.gxTpr_Wwpformelementparentid >= 0 )
            {
               AV55NewWWPForm.gxTpr_Element.Add(AV56Element, 0);
            }
            AV100GXV1 = (int)(AV100GXV1+1);
         }
         if ( AV55NewWWPForm.Insert() )
         {
            context.CommitDataStores("wp_locationdynamicform",pr_default);
            if ( ! (Guid.Empty==AV61LocationId) )
            {
               AV62Trn_LocationDynamicForm = new SdtTrn_LocationDynamicForm(context);
               AV62Trn_LocationDynamicForm.gxTpr_Locationdynamicformid = Guid.NewGuid( );
               AV62Trn_LocationDynamicForm.gxTpr_Locationid = AV61LocationId;
               AV62Trn_LocationDynamicForm.gxTpr_Organisationid = AV60OrganisationId;
               AV62Trn_LocationDynamicForm.gxTpr_Wwpformid = AV55NewWWPForm.gxTpr_Wwpformid;
               AV62Trn_LocationDynamicForm.gxTpr_Wwpformversionnumber = AV55NewWWPForm.gxTpr_Wwpformversionnumber;
               if ( AV62Trn_LocationDynamicForm.Insert() )
               {
                  context.CommitDataStores("wp_locationdynamicform",pr_default);
               }
               else
               {
                  AV102GXV3 = 1;
                  AV101GXV2 = AV62Trn_LocationDynamicForm.GetMessages();
                  while ( AV102GXV3 <= AV101GXV2.Count )
                  {
                     AV57Message = ((GeneXus.Utils.SdtMessages_Message)AV101GXV2.Item(AV102GXV3));
                     GX_msglist.addItem(AV57Message.gxTpr_Description);
                     AV102GXV3 = (int)(AV102GXV3+1);
                  }
               }
            }
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_Copy_SuccessTitle", ""),  context.GetMessage( "WWP_DF_Copy_Success", ""),  "success",  "",  "na",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV6WWPContext, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV86Pgmname, AV47WWPFormType, AV15FilterFullText, AV22TFWWPFormTitle, AV23TFWWPFormTitle_Sel, AV20TFWWPFormReferenceName, AV21TFWWPFormReferenceName_Sel, AV24TFWWPFormDate, AV25TFWWPFormDate_To, AV29TFWWPFormVersionNumber, AV30TFWWPFormVersionNumber_To, AV31TFWWPFormLatestVersionNumber, AV32TFWWPFormLatestVersionNumber_To, AV84WWPFormIsForDynamicValidations, AV49IsAuthorized_UserActionEdit, AV51IsAuthorized_UserActionDisplay, AV80IsAuthorized_UserActionCopy, AV81IsAuthorized_UserActionDelete, AV70IsAuthorized_UserActionFilledForms, AV72IsAuthorized_UserActionFillOutForm, AV85IsAuthorized_WWPFormTitle, AV82OrganisationIdFilter, A366LocationDynamicFormId) ;
         }
         else
         {
            AV104GXV5 = 1;
            AV103GXV4 = AV55NewWWPForm.GetMessages();
            while ( AV104GXV5 <= AV103GXV4.Count )
            {
               AV57Message = ((GeneXus.Utils.SdtMessages_Message)AV103GXV4.Item(AV104GXV5));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ResultMsg)) )
               {
                  AV58ResultMsg += StringUtil.NewLine( );
                  AssignAttri("", false, "AV58ResultMsg", AV58ResultMsg);
               }
               AV58ResultMsg += AV57Message.gxTpr_Description;
               AssignAttri("", false, "AV58ResultMsg", AV58ResultMsg);
               AV104GXV5 = (int)(AV104GXV5+1);
            }
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_ErrorCloning", ""),  AV58ResultMsg,  "error",  "",  "false",  ""));
         }
      }

      protected void S242( )
      {
         /* 'DO USERACTIONDELETE' Routine */
         returnInSub = false;
         if ( AV81IsAuthorized_UserActionDelete )
         {
            AV64LocationDynamicFormId_Selected = A366LocationDynamicFormId;
            AV65OrganisationId_Selected = A11OrganisationId;
            AV66LocationId_Selected = A29LocationId;
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S272( )
      {
         /* 'DO ACTION USERACTIONDELETE' Routine */
         returnInSub = false;
         new prc_deletelocationform(context ).execute(  A206WWPFormId,  A207WWPFormVersionNumber,  A366LocationDynamicFormId,  A11OrganisationId,  A29LocationId, out  AV79Messages) ;
         if ( AV79Messages.Count > 0 )
         {
            AV105GXV6 = 1;
            while ( AV105GXV6 <= AV79Messages.Count )
            {
               AV57Message = ((GeneXus.Utils.SdtMessages_Message)AV79Messages.Item(AV105GXV6));
               GX_msglist.addItem(AV57Message.gxTpr_Description);
               AV105GXV6 = (int)(AV105GXV6+1);
            }
         }
         else
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV6WWPContext, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV86Pgmname, AV47WWPFormType, AV15FilterFullText, AV22TFWWPFormTitle, AV23TFWWPFormTitle_Sel, AV20TFWWPFormReferenceName, AV21TFWWPFormReferenceName_Sel, AV24TFWWPFormDate, AV25TFWWPFormDate_To, AV29TFWWPFormVersionNumber, AV30TFWWPFormVersionNumber_To, AV31TFWWPFormLatestVersionNumber, AV32TFWWPFormLatestVersionNumber_To, AV84WWPFormIsForDynamicValidations, AV49IsAuthorized_UserActionEdit, AV51IsAuthorized_UserActionDisplay, AV80IsAuthorized_UserActionCopy, AV81IsAuthorized_UserActionDelete, AV70IsAuthorized_UserActionFilledForms, AV72IsAuthorized_UserActionFillOutForm, AV85IsAuthorized_WWPFormTitle, AV82OrganisationIdFilter, A366LocationDynamicFormId) ;
         }
      }

      protected void S252( )
      {
         /* 'DO USERACTIONFILLEDFORMS' Routine */
         returnInSub = false;
         if ( AV70IsAuthorized_UserActionFilledForms )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "ufilledoutforms.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(A209WWPFormTitle));
            CallWebObject(formatLink("ufilledoutforms.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S262( )
      {
         /* 'DO USERACTIONFILLOUTFORM' Routine */
         returnInSub = false;
         if ( AV72IsAuthorized_UserActionFillOutForm )
         {
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(A208WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim("INS"))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","isLinkingDiscussion"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S142( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV86Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV86Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV86Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV106GXV7 = 1;
         while ( AV106GXV7 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV106GXV7));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV22TFWWPFormTitle = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22TFWWPFormTitle", AV22TFWWPFormTitle);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV23TFWWPFormTitle_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23TFWWPFormTitle_Sel", AV23TFWWPFormTitle_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV20TFWWPFormReferenceName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20TFWWPFormReferenceName", AV20TFWWPFormReferenceName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV21TFWWPFormReferenceName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV21TFWWPFormReferenceName_Sel", AV21TFWWPFormReferenceName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV24TFWWPFormDate = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV24TFWWPFormDate", context.localUtil.TToC( AV24TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV25TFWWPFormDate_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV25TFWWPFormDate_To", context.localUtil.TToC( AV25TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV26DDO_WWPFormDateAuxDate = DateTimeUtil.ResetTime(AV24TFWWPFormDate);
               AssignAttri("", false, "AV26DDO_WWPFormDateAuxDate", context.localUtil.Format(AV26DDO_WWPFormDateAuxDate, "99/99/99"));
               AV27DDO_WWPFormDateAuxDateTo = DateTimeUtil.ResetTime(AV25TFWWPFormDate_To);
               AssignAttri("", false, "AV27DDO_WWPFormDateAuxDateTo", context.localUtil.Format(AV27DDO_WWPFormDateAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWWPFORMVERSIONNUMBER") == 0 )
            {
               AV29TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29TFWWPFormVersionNumber", StringUtil.LTrimStr( (decimal)(AV29TFWWPFormVersionNumber), 4, 0));
               AV30TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30TFWWPFormVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV30TFWWPFormVersionNumber_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFWWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               AV31TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31TFWWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(AV31TFWWPFormLatestVersionNumber), 4, 0));
               AV32TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV32TFWWPFormLatestVersionNumber_To", StringUtil.LTrimStr( (decimal)(AV32TFWWPFormLatestVersionNumber_To), 4, 0));
            }
            AV106GXV7 = (int)(AV106GXV7+1);
         }
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFWWPFormTitle_Sel)),  AV23TFWWPFormTitle_Sel, out  GXt_char4) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFWWPFormReferenceName_Sel)),  AV21TFWWPFormReferenceName_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char4+"|"+GXt_char6+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFWWPFormTitle)),  AV22TFWWPFormTitle, out  GXt_char6) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFWWPFormReferenceName)),  AV20TFWWPFormReferenceName, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char4+"|"+((DateTime.MinValue==AV24TFWWPFormDate) ? "" : context.localUtil.DToC( AV26DDO_WWPFormDateAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((0==AV29TFWWPFormVersionNumber) ? "" : StringUtil.Str( (decimal)(AV29TFWWPFormVersionNumber), 4, 0))+"|"+((0==AV31TFWWPFormLatestVersionNumber) ? "" : StringUtil.Str( (decimal)(AV31TFWWPFormLatestVersionNumber), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV25TFWWPFormDate_To) ? "" : context.localUtil.DToC( AV27DDO_WWPFormDateAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+((0==AV30TFWWPFormVersionNumber_To) ? "" : StringUtil.Str( (decimal)(AV30TFWWPFormVersionNumber_To), 4, 0))+"|"+((0==AV32TFWWPFormLatestVersionNumber_To) ? "" : StringUtil.Str( (decimal)(AV32TFWWPFormLatestVersionNumber_To), 4, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV86Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFWWPFORMTITLE",  context.GetMessage( "Title", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFWWPFormTitle)),  0,  AV22TFWWPFormTitle,  AV22TFWWPFormTitle,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFWWPFormTitle_Sel)),  AV23TFWWPFormTitle_Sel,  AV23TFWWPFormTitle_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFWWPFORMREFERENCENAME",  context.GetMessage( "Reference Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFWWPFormReferenceName)),  0,  AV20TFWWPFormReferenceName,  AV20TFWWPFormReferenceName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFWWPFormReferenceName_Sel)),  AV21TFWWPFormReferenceName_Sel,  AV21TFWWPFormReferenceName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFWWPFORMDATE",  context.GetMessage( "Date", ""),  !((DateTime.MinValue==AV24TFWWPFormDate)&&(DateTime.MinValue==AV25TFWWPFormDate_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV24TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV24TFWWPFormDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV24TFWWPFormDate, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV25TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV25TFWWPFormDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV25TFWWPFormDate_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFWWPFORMVERSIONNUMBER",  context.GetMessage( "Form Version #", ""),  !((0==AV29TFWWPFormVersionNumber)&&(0==AV30TFWWPFormVersionNumber_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV29TFWWPFormVersionNumber), 4, 0)),  ((0==AV29TFWWPFormVersionNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV29TFWWPFormVersionNumber), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV30TFWWPFormVersionNumber_To), 4, 0)),  ((0==AV30TFWWPFormVersionNumber_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV30TFWWPFormVersionNumber_To), "ZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFWWPFORMLATESTVERSIONNUMBER",  context.GetMessage( "Latest Version", ""),  !((0==AV31TFWWPFormLatestVersionNumber)&&(0==AV32TFWWPFormLatestVersionNumber_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFWWPFormLatestVersionNumber), 4, 0)),  ((0==AV31TFWWPFormLatestVersionNumber) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV31TFWWPFormLatestVersionNumber), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFWWPFormLatestVersionNumber_To), 4, 0)),  ((0==AV32TFWWPFormLatestVersionNumber_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV32TFWWPFormLatestVersionNumber_To), "ZZZ9")))) ;
         if ( ! (0==AV47WWPFormType) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMTYPE";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV47WWPFormType), 1, 0);
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         if ( ! (false==AV84WWPFormIsForDynamicValidations) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMISFORDYNAMICVALIDATIONS";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.BoolToStr( AV84WWPFormIsForDynamicValidations);
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV86Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S132( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV86Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_LocationDynamicForm";
         AV10TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV10TrnContextAtt.gxTpr_Attributename = "WWPFormType";
         AV10TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV47WWPFormType), 1, 0);
         AV9TrnContext.gxTpr_Attributes.Add(AV10TrnContextAtt, 0);
         AV16Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( (Guid.Empty==AV6WWPContext.gxTpr_Organisationid) ) )
         {
            dynavOrganisationidfilter.Visible = 0;
            AssignProp("", false, dynavOrganisationidfilter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavOrganisationidfilter.Visible), 5, 0), true);
            divOrganisationidfilter_cell_Class = "Invisible";
            AssignProp("", false, divOrganisationidfilter_cell_Internalname, "Class", divOrganisationidfilter_cell_Class, true);
         }
         else
         {
            dynavOrganisationidfilter.Visible = 1;
            AssignProp("", false, dynavOrganisationidfilter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavOrganisationidfilter.Visible), 5, 0), true);
            divOrganisationidfilter_cell_Class = "";
            AssignProp("", false, divOrganisationidfilter_cell_Internalname, "Class", divOrganisationidfilter_cell_Class, true);
         }
         if ( ! ( (Guid.Empty==AV6WWPContext.gxTpr_Locationid) ) )
         {
            dynavLocationidfilter.Visible = 0;
            AssignProp("", false, dynavLocationidfilter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationidfilter.Visible), 5, 0), true);
            divLocationidfilter_cell_Class = "Invisible";
            AssignProp("", false, divLocationidfilter_cell_Internalname, "Class", divLocationidfilter_cell_Class, true);
         }
         else
         {
            dynavLocationidfilter.Visible = 1;
            AssignProp("", false, dynavLocationidfilter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavLocationidfilter.Visible), 5, 0), true);
            divLocationidfilter_cell_Class = "";
            AssignProp("", false, divLocationidfilter_cell_Internalname, "Class", divLocationidfilter_cell_Class, true);
         }
      }

      protected void E196B2( )
      {
         /* Locationidfilter_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! (Guid.Empty==AV6WWPContext.gxTpr_Locationid) )
         {
            AV61LocationId = AV83LocationIdFilter;
            AssignAttri("", false, "AV61LocationId", AV61LocationId.ToString());
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV6WWPContext, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV86Pgmname, AV47WWPFormType, AV15FilterFullText, AV22TFWWPFormTitle, AV23TFWWPFormTitle_Sel, AV20TFWWPFormReferenceName, AV21TFWWPFormReferenceName_Sel, AV24TFWWPFormDate, AV25TFWWPFormDate_To, AV29TFWWPFormVersionNumber, AV30TFWWPFormVersionNumber_To, AV31TFWWPFormLatestVersionNumber, AV32TFWWPFormLatestVersionNumber_To, AV84WWPFormIsForDynamicValidations, AV49IsAuthorized_UserActionEdit, AV51IsAuthorized_UserActionDisplay, AV80IsAuthorized_UserActionCopy, AV81IsAuthorized_UserActionDelete, AV70IsAuthorized_UserActionFilledForms, AV72IsAuthorized_UserActionFillOutForm, AV85IsAuthorized_WWPFormTitle, AV82OrganisationIdFilter, A366LocationDynamicFormId) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void wb_table1_67_6B2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useractiondelete_Internalname, tblTabledvelop_confirmpanel_useractiondelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useractiondelete.SetProperty("Title", Dvelop_confirmpanel_useractiondelete_Title);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_useractiondelete_Confirmationtext);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useractiondelete_Nobuttoncaption);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useractiondelete_Yesbuttonposition);
            ucDvelop_confirmpanel_useractiondelete.SetProperty("ConfirmType", Dvelop_confirmpanel_useractiondelete_Confirmtype);
            ucDvelop_confirmpanel_useractiondelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useractiondelete_Internalname, "DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_USERACTIONDELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_67_6B2e( true) ;
         }
         else
         {
            wb_table1_67_6B2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV47WWPFormType = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV47WWPFormType", StringUtil.Str( (decimal)(AV47WWPFormType), 1, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV47WWPFormType), "9"), context));
         AV84WWPFormIsForDynamicValidations = (bool)getParm(obj,1);
         AssignAttri("", false, "AV84WWPFormIsForDynamicValidations", AV84WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV84WWPFormIsForDynamicValidations, context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA6B2( ) ;
         WS6B2( ) ;
         WE6B2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20254111595080", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wp_locationdynamicform.js", "?20254111595084", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_472( )
      {
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_47_idx;
         edtLocationId_Internalname = "LOCATIONID_"+sGXsfl_47_idx;
         edtWWPFormId_Internalname = "WWPFORMID_"+sGXsfl_47_idx;
         edtWWPFormTitle_Internalname = "WWPFORMTITLE_"+sGXsfl_47_idx;
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME_"+sGXsfl_47_idx;
         edtWWPFormDate_Internalname = "WWPFORMDATE_"+sGXsfl_47_idx;
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER_"+sGXsfl_47_idx;
         edtWWPFormLatestVersionNumber_Internalname = "WWPFORMLATESTVERSIONNUMBER_"+sGXsfl_47_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_47_idx;
      }

      protected void SubsflControlProps_fel_472( )
      {
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_47_fel_idx;
         edtLocationId_Internalname = "LOCATIONID_"+sGXsfl_47_fel_idx;
         edtWWPFormId_Internalname = "WWPFORMID_"+sGXsfl_47_fel_idx;
         edtWWPFormTitle_Internalname = "WWPFORMTITLE_"+sGXsfl_47_fel_idx;
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME_"+sGXsfl_47_fel_idx;
         edtWWPFormDate_Internalname = "WWPFORMDATE_"+sGXsfl_47_fel_idx;
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER_"+sGXsfl_47_fel_idx;
         edtWWPFormLatestVersionNumber_Internalname = "WWPFORMLATESTVERSIONNUMBER_"+sGXsfl_47_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_47_fel_idx;
      }

      protected void sendrow_472( )
      {
         sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
         SubsflControlProps_472( ) ;
         WB6B0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_47_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_47_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_47_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)47,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLocationId_Internalname,A29LocationId.ToString(),A29LocationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLocationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)47,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPFormTitle_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormTitle_Internalname,(string)A209WWPFormTitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWWPFormTitle_Link,(string)"",(string)"",(string)"",(string)edtWWPFormTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormTitle_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPFormReferenceName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormReferenceName_Internalname,(string)A208WWPFormReferenceName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormReferenceName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormReferenceName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWWPFormDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormDate_Internalname,context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A231WWPFormDate, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWWPFormVersionNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormVersionNumber_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormVersionNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormVersionNumber_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWWPFormLatestVersionNumber_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormLatestVersionNumber_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A219WWPFormLatestVersionNumber), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormLatestVersionNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormLatestVersionNumber_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)47,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_47_idx + "',47)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_47_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV71ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV71ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV71ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV71ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_47_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV71ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_47_Refreshing);
            send_integrity_lvl_hashes6B2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_47_idx = ((subGrid_Islastpage==1)&&(nGXsfl_47_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_47_idx+1);
            sGXsfl_47_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_47_idx), 4, 0), 4, "0");
            SubsflControlProps_472( ) ;
         }
         /* End function sendrow_472 */
      }

      protected void init_web_controls( )
      {
         dynavOrganisationidfilter.Name = "vORGANISATIONIDFILTER";
         dynavOrganisationidfilter.WebTags = "";
         dynavLocationidfilter.Name = "vLOCATIONIDFILTER";
         dynavLocationidfilter.WebTags = "";
         GXCCtl = "vACTIONGROUP_" + sGXsfl_47_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            AV71ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV71ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV71ActionGroup), 4, 0));
         }
         cmbWWPFormType.Name = "WWPFORMTYPE";
         cmbWWPFormType.WebTags = "";
         cmbWWPFormType.addItem("0", context.GetMessage( "WWP_DF_Type_DynamicForm", ""), 0);
         cmbWWPFormType.addItem("1", context.GetMessage( "WWP_DF_Type_DynamicSection", ""), 0);
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl47( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"47\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormTitle_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Title", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormReferenceName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Reference Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Date", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormVersionNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Form Version #", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormLatestVersionNumber_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Latest Version", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavActiongroup_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A29LocationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A209WWPFormTitle));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtWWPFormTitle_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormTitle_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A208WWPFormReferenceName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormReferenceName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormVersionNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormLatestVersionNumber_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71ActionGroup), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavActiongroup_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnuseractioninsert_Internalname = "BTNUSERACTIONINSERT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         dynavOrganisationidfilter_Internalname = "vORGANISATIONIDFILTER";
         divOrganisationidfilter_cell_Internalname = "ORGANISATIONIDFILTER_CELL";
         dynavLocationidfilter_Internalname = "vLOCATIONIDFILTER";
         divLocationidfilter_cell_Internalname = "LOCATIONIDFILTER_CELL";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtLocationId_Internalname = "LOCATIONID";
         edtWWPFormId_Internalname = "WWPFORMID";
         edtWWPFormTitle_Internalname = "WWPFORMTITLE";
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME";
         edtWWPFormDate_Internalname = "WWPFORMDATE";
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER";
         edtWWPFormLatestVersionNumber_Internalname = "WWPFORMLATESTVERSIONNUMBER";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         cmbWWPFormType_Internalname = "WWPFORMTYPE";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_useractiondelete_Internalname = "DVELOP_CONFIRMPANEL_USERACTIONDELETE";
         tblTabledvelop_confirmpanel_useractiondelete_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERACTIONDELETE";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_wwpformdateauxdatetext_Internalname = "vDDO_WWPFORMDATEAUXDATETEXT";
         Tfwwpformdate_rangepicker_Internalname = "TFWWPFORMDATE_RANGEPICKER";
         divDdo_wwpformdateauxdates_Internalname = "DDO_WWPFORMDATEAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowhovering = -1;
         subGrid_Allowselection = 1;
         subGrid_Header = "";
         cmbavActiongroup_Jsonclick = "";
         cmbavActiongroup_Class = "ConvertToDDO";
         edtWWPFormLatestVersionNumber_Jsonclick = "";
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormDate_Jsonclick = "";
         edtWWPFormReferenceName_Jsonclick = "";
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormTitle_Link = "";
         edtWWPFormId_Jsonclick = "";
         edtLocationId_Jsonclick = "";
         edtOrganisationId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtWWPFormLatestVersionNumber_Visible = -1;
         edtWWPFormVersionNumber_Visible = -1;
         edtWWPFormDate_Visible = -1;
         edtWWPFormReferenceName_Visible = -1;
         edtWWPFormTitle_Visible = -1;
         cmbWWPFormType.Enabled = 0;
         edtWWPFormLatestVersionNumber_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormDate_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_wwpformdateauxdatetext_Jsonclick = "";
         cmbWWPFormType_Jsonclick = "";
         cmbWWPFormType.Visible = 1;
         dynavLocationidfilter_Jsonclick = "";
         dynavLocationidfilter.Enabled = 1;
         dynavLocationidfilter.Visible = 1;
         divLocationidfilter_cell_Class = "";
         dynavOrganisationidfilter_Jsonclick = "";
         dynavOrganisationidfilter.Enabled = 1;
         dynavOrganisationidfilter.Visible = 1;
         divOrganisationidfilter_cell_Class = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtnuseractioninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_useractiondelete_Confirmtype = "1";
         Dvelop_confirmpanel_useractiondelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractiondelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractiondelete_Confirmationtext = "Are you sure you want to delete form";
         Dvelop_confirmpanel_useractiondelete_Title = context.GetMessage( "Delete form", "");
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "|||4.0|4.0";
         Ddo_grid_Datalistproc = "WP_LocationDynamicFormGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|||";
         Ddo_grid_Includedatalist = "T|T|||";
         Ddo_grid_Filterisrange = "||P|T|T";
         Ddo_grid_Filtertype = "Character|Character|Date|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|";
         Ddo_grid_Columnssortvalues = "1|2|3|4|";
         Ddo_grid_Columnids = "3:WWPFormTitle|4:WWPFormReferenceName|5:WWPFormDate|6:WWPFormVersionNumber|7:WWPFormLatestVersionNumber";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Location Dynamic Form", "");
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Validv_Organisationidfilter( )
      {
         AV82OrganisationIdFilter = StringUtil.StrToGuid( dynavOrganisationidfilter.CurrentValue);
         AV83LocationIdFilter = StringUtil.StrToGuid( dynavLocationidfilter.CurrentValue);
         GXVvLOCATIONIDFILTER_html6B2( AV82OrganisationIdFilter) ;
         dynload_actions( ) ;
         if ( dynavLocationidfilter.ItemCount > 0 )
         {
            AV83LocationIdFilter = StringUtil.StrToGuid( dynavLocationidfilter.getValidValue(AV83LocationIdFilter.ToString()));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLocationidfilter.CurrentValue = AV83LocationIdFilter.ToString();
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV83LocationIdFilter", AV83LocationIdFilter.ToString());
         dynavLocationidfilter.CurrentValue = AV83LocationIdFilter.ToString();
         AssignProp("", false, dynavLocationidfilter_Internalname, "Values", dynavLocationidfilter.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV86Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV84WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV85IsAuthorized_WWPFormTitle","fld":"vISAUTHORIZED_WWPFORMTITLE","hsh":true},{"av":"dynavOrganisationidfilter"},{"av":"AV82OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV61LocationId","fld":"vLOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV37GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV38GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV39GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E126B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV86Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV84WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV85IsAuthorized_WWPFormTitle","fld":"vISAUTHORIZED_WWPFORMTITLE","hsh":true},{"av":"dynavOrganisationidfilter"},{"av":"AV82OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E136B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV86Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV84WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV85IsAuthorized_WWPFormTitle","fld":"vISAUTHORIZED_WWPFORMTITLE","hsh":true},{"av":"dynavOrganisationidfilter"},{"av":"AV82OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E156B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV86Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV84WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV85IsAuthorized_WWPFormTitle","fld":"vISAUTHORIZED_WWPFORMTITLE","hsh":true},{"av":"dynavOrganisationidfilter"},{"av":"AV82OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E226B2","iparms":[{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV85IsAuthorized_WWPFormTitle","fld":"vISAUTHORIZED_WWPFORMTITLE","hsh":true},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV71ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtWWPFormTitle_Link","ctrl":"WWPFORMTITLE","prop":"Link"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E166B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV86Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV84WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV85IsAuthorized_WWPFormTitle","fld":"vISAUTHORIZED_WWPFORMTITLE","hsh":true},{"av":"dynavOrganisationidfilter"},{"av":"AV82OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV61LocationId","fld":"vLOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV37GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV38GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV39GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E116B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV86Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV84WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV85IsAuthorized_WWPFormTitle","fld":"vISAUTHORIZED_WWPFORMTITLE","hsh":true},{"av":"dynavOrganisationidfilter"},{"av":"AV82OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV26DDO_WWPFormDateAuxDate","fld":"vDDO_WWPFORMDATEAUXDATE"},{"av":"AV27DDO_WWPFormDateAuxDateTo","fld":"vDDO_WWPFORMDATEAUXDATETO"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV26DDO_WWPFormDateAuxDate","fld":"vDDO_WWPFORMDATEAUXDATE"},{"av":"AV27DDO_WWPFormDateAuxDateTo","fld":"vDDO_WWPFORMDATEAUXDATETO"},{"av":"AV61LocationId","fld":"vLOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV37GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV38GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV39GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E236B2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV71ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV86Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV84WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV85IsAuthorized_WWPFormTitle","fld":"vISAUTHORIZED_WWPFORMTITLE","hsh":true},{"av":"dynavOrganisationidfilter"},{"av":"AV82OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID","hsh":true},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME"},{"av":"AV61LocationId","fld":"vLOCATIONID"},{"av":"AV60OrganisationId","fld":"vORGANISATIONID"},{"av":"AV58ResultMsg","fld":"vRESULTMSG"},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE"}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV71ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV58ResultMsg","fld":"vRESULTMSG"},{"av":"AV61LocationId","fld":"vLOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV37GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV38GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV39GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE","""{"handler":"E176B2","iparms":[{"av":"Dvelop_confirmpanel_useractiondelete_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONDELETE","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV86Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV84WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV85IsAuthorized_WWPFormTitle","fld":"vISAUTHORIZED_WWPFORMTITLE","hsh":true},{"av":"dynavOrganisationidfilter"},{"av":"AV82OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID","hsh":true},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONDELETE.CLOSE",""","oparms":[{"av":"AV61LocationId","fld":"vLOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV37GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV38GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV39GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOUSERACTIONINSERT'","""{"handler":"E186B2","iparms":[{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E146B2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VLOCATIONIDFILTER.CONTROLVALUECHANGED","""{"handler":"E196B2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV86Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV47WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV23TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV20TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV21TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV24TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV25TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV29TFWWPFormVersionNumber","fld":"vTFWWPFORMVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV30TFWWPFormVersionNumber_To","fld":"vTFWWPFORMVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV31TFWWPFormLatestVersionNumber","fld":"vTFWWPFORMLATESTVERSIONNUMBER","pic":"ZZZ9"},{"av":"AV32TFWWPFormLatestVersionNumber_To","fld":"vTFWWPFORMLATESTVERSIONNUMBER_TO","pic":"ZZZ9"},{"av":"AV84WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"av":"AV85IsAuthorized_WWPFormTitle","fld":"vISAUTHORIZED_WWPFORMTITLE","hsh":true},{"av":"dynavOrganisationidfilter"},{"av":"AV82OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"A366LocationDynamicFormId","fld":"LOCATIONDYNAMICFORMID","hsh":true},{"av":"dynavLocationidfilter"},{"av":"AV83LocationIdFilter","fld":"vLOCATIONIDFILTER"}]""");
         setEventMetadata("VLOCATIONIDFILTER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV61LocationId","fld":"vLOCATIONID"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtWWPFormVersionNumber_Visible","ctrl":"WWPFORMVERSIONNUMBER","prop":"Visible"},{"av":"edtWWPFormLatestVersionNumber_Visible","ctrl":"WWPFORMLATESTVERSIONNUMBER","prop":"Visible"},{"av":"AV37GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV38GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV39GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV49IsAuthorized_UserActionEdit","fld":"vISAUTHORIZED_USERACTIONEDIT","hsh":true},{"av":"AV51IsAuthorized_UserActionDisplay","fld":"vISAUTHORIZED_USERACTIONDISPLAY","hsh":true},{"av":"AV80IsAuthorized_UserActionCopy","fld":"vISAUTHORIZED_USERACTIONCOPY","hsh":true},{"av":"AV81IsAuthorized_UserActionDelete","fld":"vISAUTHORIZED_USERACTIONDELETE","hsh":true},{"av":"AV70IsAuthorized_UserActionFilledForms","fld":"vISAUTHORIZED_USERACTIONFILLEDFORMS","hsh":true},{"av":"AV72IsAuthorized_UserActionFillOutForm","fld":"vISAUTHORIZED_USERACTIONFILLOUTFORM","hsh":true},{"ctrl":"BTNUSERACTIONINSERT","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("VALIDV_ORGANISATIONIDFILTER","""{"handler":"Validv_Organisationidfilter","iparms":[{"av":"dynavOrganisationidfilter"},{"av":"AV82OrganisationIdFilter","fld":"vORGANISATIONIDFILTER"},{"av":"dynavLocationidfilter"},{"av":"AV83LocationIdFilter","fld":"vLOCATIONIDFILTER"}]""");
         setEventMetadata("VALIDV_ORGANISATIONIDFILTER",""","oparms":[{"av":"dynavLocationidfilter"},{"av":"AV83LocationIdFilter","fld":"vLOCATIONIDFILTER"}]}""");
         setEventMetadata("VALIDV_LOCATIONIDFILTER","""{"handler":"Validv_Locationidfilter","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMTITLE","""{"handler":"Valid_Wwpformtitle","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMREFERENCENAME","""{"handler":"Valid_Wwpformreferencename","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMLATESTVERSIONNUMBER","""{"handler":"Valid_Wwpformlatestversionnumber","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Actiongroup","iparms":[]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_useractiondelete_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV82OrganisationIdFilter = Guid.Empty;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV77ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV86Pgmname = "";
         AV15FilterFullText = "";
         AV22TFWWPFormTitle = "";
         AV23TFWWPFormTitle_Sel = "";
         AV20TFWWPFormReferenceName = "";
         AV21TFWWPFormReferenceName_Sel = "";
         AV24TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV25TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         A366LocationDynamicFormId = Guid.Empty;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV39GridAppliedFilters = "";
         AV33DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV26DDO_WWPFormDateAuxDate = DateTime.MinValue;
         AV27DDO_WWPFormDateAuxDateTo = DateTime.MinValue;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV61LocationId = Guid.Empty;
         AV60OrganisationId = Guid.Empty;
         AV58ResultMsg = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnuseractioninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         AV83LocationIdFilter = Guid.Empty;
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV28DDO_WWPFormDateAuxDateText = "";
         ucTfwwpformdate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A209WWPFormTitle = "";
         A208WWPFormReferenceName = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H006B2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006B2_A13OrganisationName = new string[] {""} ;
         H006B3_A29LocationId = new Guid[] {Guid.Empty} ;
         H006B3_A31LocationName = new string[] {""} ;
         H006B3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         AV88Wp_locationdynamicformds_2_filterfulltext = "";
         AV89Wp_locationdynamicformds_3_tfwwpformtitle = "";
         AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel = "";
         AV91Wp_locationdynamicformds_5_tfwwpformreferencename = "";
         AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel = "";
         AV93Wp_locationdynamicformds_7_tfwwpformdate = (DateTime)(DateTime.MinValue);
         AV94Wp_locationdynamicformds_8_tfwwpformdate_to = (DateTime)(DateTime.MinValue);
         lV89Wp_locationdynamicformds_3_tfwwpformtitle = "";
         lV91Wp_locationdynamicformds_5_tfwwpformreferencename = "";
         H006B4_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         H006B4_A240WWPFormType = new short[1] ;
         H006B4_A207WWPFormVersionNumber = new short[1] ;
         H006B4_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         H006B4_A208WWPFormReferenceName = new string[] {""} ;
         H006B4_A209WWPFormTitle = new string[] {""} ;
         H006B4_A29LocationId = new Guid[] {Guid.Empty} ;
         H006B4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006B4_A206WWPFormId = new short[1] ;
         H006B5_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         H006B5_A240WWPFormType = new short[1] ;
         H006B5_A207WWPFormVersionNumber = new short[1] ;
         H006B5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         H006B5_A208WWPFormReferenceName = new string[] {""} ;
         H006B5_A209WWPFormTitle = new string[] {""} ;
         H006B5_A29LocationId = new Guid[] {Guid.Empty} ;
         H006B5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006B5_A206WWPFormId = new short[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV34GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV35GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16Session = context.GetSession();
         AV75ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         AV76UserCustomValue = "";
         AV78ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV52WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV54WWPFormReferenceName = "";
         AV55NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         H006B6_A207WWPFormVersionNumber = new short[1] ;
         H006B6_A206WWPFormId = new short[1] ;
         AV56Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV62Trn_LocationDynamicForm = new SdtTrn_LocationDynamicForm(context);
         AV101GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV57Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV103GXV4 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV64LocationDynamicFormId_Selected = Guid.Empty;
         AV65OrganisationId_Selected = Guid.Empty;
         AV66LocationId_Selected = Guid.Empty;
         AV79Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char4 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         ucDvelop_confirmpanel_useractiondelete = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         ZV83LocationIdFilter = Guid.Empty;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_locationdynamicform__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_locationdynamicform__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_locationdynamicform__default(),
            new Object[][] {
                new Object[] {
               H006B2_A11OrganisationId, H006B2_A13OrganisationName
               }
               , new Object[] {
               H006B3_A29LocationId, H006B3_A31LocationName, H006B3_A11OrganisationId
               }
               , new Object[] {
               H006B4_A366LocationDynamicFormId, H006B4_A240WWPFormType, H006B4_A207WWPFormVersionNumber, H006B4_A231WWPFormDate, H006B4_A208WWPFormReferenceName, H006B4_A209WWPFormTitle, H006B4_A29LocationId, H006B4_A11OrganisationId, H006B4_A206WWPFormId
               }
               , new Object[] {
               H006B5_A366LocationDynamicFormId, H006B5_A240WWPFormType, H006B5_A207WWPFormVersionNumber, H006B5_A231WWPFormDate, H006B5_A208WWPFormReferenceName, H006B5_A209WWPFormTitle, H006B5_A29LocationId, H006B5_A11OrganisationId, H006B5_A206WWPFormId
               }
               , new Object[] {
               H006B6_A207WWPFormVersionNumber, H006B6_A206WWPFormId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV86Pgmname = "WP_LocationDynamicForm";
         /* GeneXus formulas. */
         AV86Pgmname = "WP_LocationDynamicForm";
      }

      private short AV47WWPFormType ;
      private short wcpOAV47WWPFormType ;
      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV19ManageFiltersExecutionStep ;
      private short AV29TFWWPFormVersionNumber ;
      private short AV30TFWWPFormVersionNumber_To ;
      private short AV31TFWWPFormLatestVersionNumber ;
      private short AV32TFWWPFormLatestVersionNumber_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A240WWPFormType ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short AV71ActionGroup ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV87Wp_locationdynamicformds_1_wwpformtype ;
      private short AV95Wp_locationdynamicformds_9_tfwwpformversionnumber ;
      private short AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to ;
      private short AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber ;
      private short AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short GXt_int1 ;
      private short AV53CopyNumber ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_47 ;
      private int nGXsfl_47_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnuseractioninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int edtOrganisationId_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormDate_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormLatestVersionNumber_Enabled ;
      private int edtWWPFormTitle_Visible ;
      private int edtWWPFormReferenceName_Visible ;
      private int edtWWPFormDate_Visible ;
      private int edtWWPFormVersionNumber_Visible ;
      private int edtWWPFormLatestVersionNumber_Visible ;
      private int AV36PageToGo ;
      private int AV100GXV1 ;
      private int AV102GXV3 ;
      private int AV104GXV5 ;
      private int AV105GXV6 ;
      private int AV106GXV7 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV37GridCurrentPage ;
      private long AV38GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_useractiondelete_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_47_idx="0001" ;
      private string AV86Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Dvelop_confirmpanel_useractiondelete_Title ;
      private string Dvelop_confirmpanel_useractiondelete_Confirmationtext ;
      private string Dvelop_confirmpanel_useractiondelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractiondelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractiondelete_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnuseractioninsert_Internalname ;
      private string bttBtnuseractioninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divOrganisationidfilter_cell_Internalname ;
      private string divOrganisationidfilter_cell_Class ;
      private string dynavOrganisationidfilter_Internalname ;
      private string dynavOrganisationidfilter_Jsonclick ;
      private string divLocationidfilter_cell_Internalname ;
      private string divLocationidfilter_cell_Class ;
      private string dynavLocationidfilter_Internalname ;
      private string dynavLocationidfilter_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string cmbWWPFormType_Internalname ;
      private string cmbWWPFormType_Jsonclick ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_wwpformdateauxdates_Internalname ;
      private string edtavDdo_wwpformdateauxdatetext_Internalname ;
      private string edtavDdo_wwpformdateauxdatetext_Jsonclick ;
      private string Tfwwpformdate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtOrganisationId_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormReferenceName_Internalname ;
      private string edtWWPFormDate_Internalname ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormLatestVersionNumber_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string GXDecQS ;
      private string gxwrpcisep ;
      private string cmbavActiongroup_Class ;
      private string edtWWPFormTitle_Link ;
      private string GXt_char6 ;
      private string GXt_char4 ;
      private string tblTabledvelop_confirmpanel_useractiondelete_Internalname ;
      private string Dvelop_confirmpanel_useractiondelete_Internalname ;
      private string sGXsfl_47_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtOrganisationId_Jsonclick ;
      private string edtLocationId_Jsonclick ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormTitle_Jsonclick ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPFormDate_Jsonclick ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormLatestVersionNumber_Jsonclick ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV24TFWWPFormDate ;
      private DateTime AV25TFWWPFormDate_To ;
      private DateTime A231WWPFormDate ;
      private DateTime AV93Wp_locationdynamicformds_7_tfwwpformdate ;
      private DateTime AV94Wp_locationdynamicformds_8_tfwwpformdate_to ;
      private DateTime AV26DDO_WWPFormDateAuxDate ;
      private DateTime AV27DDO_WWPFormDateAuxDateTo ;
      private bool AV84WWPFormIsForDynamicValidations ;
      private bool wcpOAV84WWPFormIsForDynamicValidations ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV49IsAuthorized_UserActionEdit ;
      private bool AV51IsAuthorized_UserActionDisplay ;
      private bool AV80IsAuthorized_UserActionCopy ;
      private bool AV81IsAuthorized_UserActionDelete ;
      private bool AV70IsAuthorized_UserActionFilledForms ;
      private bool AV72IsAuthorized_UserActionFillOutForm ;
      private bool AV85IsAuthorized_WWPFormTitle ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_47_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV73IsAuthorized_UserActionInsert ;
      private bool GXt_boolean2 ;
      private string AV75ColumnsSelectorXML ;
      private string AV18ManageFiltersXml ;
      private string AV76UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV22TFWWPFormTitle ;
      private string AV23TFWWPFormTitle_Sel ;
      private string AV20TFWWPFormReferenceName ;
      private string AV21TFWWPFormReferenceName_Sel ;
      private string AV39GridAppliedFilters ;
      private string AV58ResultMsg ;
      private string AV28DDO_WWPFormDateAuxDateText ;
      private string A209WWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string AV88Wp_locationdynamicformds_2_filterfulltext ;
      private string AV89Wp_locationdynamicformds_3_tfwwpformtitle ;
      private string AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel ;
      private string AV91Wp_locationdynamicformds_5_tfwwpformreferencename ;
      private string AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel ;
      private string lV89Wp_locationdynamicformds_3_tfwwpformtitle ;
      private string lV91Wp_locationdynamicformds_5_tfwwpformreferencename ;
      private string AV54WWPFormReferenceName ;
      private Guid AV82OrganisationIdFilter ;
      private Guid A366LocationDynamicFormId ;
      private Guid AV61LocationId ;
      private Guid AV60OrganisationId ;
      private Guid AV83LocationIdFilter ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid AV64LocationDynamicFormId_Selected ;
      private Guid AV65OrganisationId_Selected ;
      private Guid AV66LocationId_Selected ;
      private Guid ZV83LocationIdFilter ;
      private IGxSession AV16Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfwwpformdate_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_useractiondelete ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavOrganisationidfilter ;
      private GXCombobox dynavLocationidfilter ;
      private GXCombobox cmbavActiongroup ;
      private GXCombobox cmbWWPFormType ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV77ColumnsSelector ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV33DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private Guid[] H006B2_A11OrganisationId ;
      private string[] H006B2_A13OrganisationName ;
      private Guid[] H006B3_A29LocationId ;
      private string[] H006B3_A31LocationName ;
      private Guid[] H006B3_A11OrganisationId ;
      private Guid[] H006B4_A366LocationDynamicFormId ;
      private short[] H006B4_A240WWPFormType ;
      private short[] H006B4_A207WWPFormVersionNumber ;
      private DateTime[] H006B4_A231WWPFormDate ;
      private string[] H006B4_A208WWPFormReferenceName ;
      private string[] H006B4_A209WWPFormTitle ;
      private Guid[] H006B4_A29LocationId ;
      private Guid[] H006B4_A11OrganisationId ;
      private short[] H006B4_A206WWPFormId ;
      private Guid[] H006B5_A366LocationDynamicFormId ;
      private short[] H006B5_A240WWPFormType ;
      private short[] H006B5_A207WWPFormVersionNumber ;
      private DateTime[] H006B5_A231WWPFormDate ;
      private string[] H006B5_A208WWPFormReferenceName ;
      private string[] H006B5_A209WWPFormTitle ;
      private Guid[] H006B5_A29LocationId ;
      private Guid[] H006B5_A11OrganisationId ;
      private short[] H006B5_A206WWPFormId ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV34GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV35GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV78ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV52WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV55NewWWPForm ;
      private short[] H006B6_A207WWPFormVersionNumber ;
      private short[] H006B6_A206WWPFormId ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV56Element ;
      private SdtTrn_LocationDynamicForm AV62Trn_LocationDynamicForm ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV101GXV2 ;
      private GeneXus.Utils.SdtMessages_Message AV57Message ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV103GXV4 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV79Messages ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV10TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_locationdynamicform__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_locationdynamicform__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_locationdynamicform__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_H006B4( IGxContext context ,
                                          string AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel ,
                                          string AV89Wp_locationdynamicformds_3_tfwwpformtitle ,
                                          string AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel ,
                                          string AV91Wp_locationdynamicformds_5_tfwwpformreferencename ,
                                          DateTime AV93Wp_locationdynamicformds_7_tfwwpformdate ,
                                          DateTime AV94Wp_locationdynamicformds_8_tfwwpformdate_to ,
                                          short AV95Wp_locationdynamicformds_9_tfwwpformversionnumber ,
                                          short AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to ,
                                          string A209WWPFormTitle ,
                                          string A208WWPFormReferenceName ,
                                          DateTime A231WWPFormDate ,
                                          short A207WWPFormVersionNumber ,
                                          short AV13OrderedBy ,
                                          bool AV14OrderedDsc ,
                                          string AV88Wp_locationdynamicformds_2_filterfulltext ,
                                          short A219WWPFormLatestVersionNumber ,
                                          short AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber ,
                                          short AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to ,
                                          short A240WWPFormType ,
                                          short AV87Wp_locationdynamicformds_1_wwpformtype ,
                                          Guid A29LocationId ,
                                          Guid AV61LocationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int7 = new short[10];
      Object[] GXv_Object8 = new Object[2];
      scmdbuf = "SELECT T1.LocationDynamicFormId, T2.WWPFormType, T1.WWPFormVersionNumber, T2.WWPFormDate, T2.WWPFormReferenceName, T2.WWPFormTitle, T1.LocationId, T1.OrganisationId, T1.WWPFormId FROM (Trn_LocationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
      AddWhere(sWhereString, "(T2.WWPFormType = :AV87Wp_locationdynamicformds_1_wwpformtype)");
      AddWhere(sWhereString, "(T1.LocationId = :AV61LocationId)");
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wp_locationdynamicformds_3_tfwwpformtitle)) ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormTitle like :lV89Wp_locationdynamicformds_3_tfwwpformtitle)");
      }
      else
      {
         GXv_int7[2] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormTitle = ( :AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel))");
      }
      else
      {
         GXv_int7[3] = 1;
      }
      if ( StringUtil.StrCmp(AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormTitle))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wp_locationdynamicformds_5_tfwwpformreferencename)) ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormReferenceName like :lV91Wp_locationdynamicformds_5_tfwwpformreferencename)");
      }
      else
      {
         GXv_int7[4] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormReferenceName = ( :AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel))");
      }
      else
      {
         GXv_int7[5] = 1;
      }
      if ( StringUtil.StrCmp(AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormReferenceName))=0))");
      }
      if ( ! (DateTime.MinValue==AV93Wp_locationdynamicformds_7_tfwwpformdate) )
      {
         AddWhere(sWhereString, "(T2.WWPFormDate >= :AV93Wp_locationdynamicformds_7_tfwwpformdate)");
      }
      else
      {
         GXv_int7[6] = 1;
      }
      if ( ! (DateTime.MinValue==AV94Wp_locationdynamicformds_8_tfwwpformdate_to) )
      {
         AddWhere(sWhereString, "(T2.WWPFormDate <= :AV94Wp_locationdynamicformds_8_tfwwpformdate_to)");
      }
      else
      {
         GXv_int7[7] = 1;
      }
      if ( ! (0==AV95Wp_locationdynamicformds_9_tfwwpformversionnumber) )
      {
         AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV95Wp_locationdynamicformds_9_tfwwpformversionnumber)");
      }
      else
      {
         GXv_int7[8] = 1;
      }
      if ( ! (0==AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to) )
      {
         AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to)");
      }
      else
      {
         GXv_int7[9] = 1;
      }
      scmdbuf += sWhereString;
      if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormTitle, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T2.WWPFormTitle DESC, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormReferenceName, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T2.WWPFormReferenceName DESC, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormDate, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T2.WWPFormDate DESC, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T1.WWPFormVersionNumber, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T1.WWPFormVersionNumber DESC, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      GXv_Object8[0] = scmdbuf;
      GXv_Object8[1] = GXv_int7;
      return GXv_Object8 ;
   }

   protected Object[] conditional_H006B5( IGxContext context ,
                                          string AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel ,
                                          string AV89Wp_locationdynamicformds_3_tfwwpformtitle ,
                                          string AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel ,
                                          string AV91Wp_locationdynamicformds_5_tfwwpformreferencename ,
                                          DateTime AV93Wp_locationdynamicformds_7_tfwwpformdate ,
                                          DateTime AV94Wp_locationdynamicformds_8_tfwwpformdate_to ,
                                          short AV95Wp_locationdynamicformds_9_tfwwpformversionnumber ,
                                          short AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to ,
                                          string A209WWPFormTitle ,
                                          string A208WWPFormReferenceName ,
                                          DateTime A231WWPFormDate ,
                                          short A207WWPFormVersionNumber ,
                                          short AV13OrderedBy ,
                                          bool AV14OrderedDsc ,
                                          string AV88Wp_locationdynamicformds_2_filterfulltext ,
                                          short A219WWPFormLatestVersionNumber ,
                                          short AV97Wp_locationdynamicformds_11_tfwwpformlatestversionnumber ,
                                          short AV98Wp_locationdynamicformds_12_tfwwpformlatestversionnumber_to ,
                                          short A240WWPFormType ,
                                          short AV87Wp_locationdynamicformds_1_wwpformtype ,
                                          Guid A29LocationId ,
                                          Guid AV61LocationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int9 = new short[10];
      Object[] GXv_Object10 = new Object[2];
      scmdbuf = "SELECT T1.LocationDynamicFormId, T2.WWPFormType, T1.WWPFormVersionNumber, T2.WWPFormDate, T2.WWPFormReferenceName, T2.WWPFormTitle, T1.LocationId, T1.OrganisationId, T1.WWPFormId FROM (Trn_LocationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
      AddWhere(sWhereString, "(T2.WWPFormType = :AV87Wp_locationdynamicformds_1_wwpformtype)");
      AddWhere(sWhereString, "(T1.LocationId = :AV61LocationId)");
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wp_locationdynamicformds_3_tfwwpformtitle)) ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormTitle like :lV89Wp_locationdynamicformds_3_tfwwpformtitle)");
      }
      else
      {
         GXv_int9[2] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormTitle = ( :AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel))");
      }
      else
      {
         GXv_int9[3] = 1;
      }
      if ( StringUtil.StrCmp(AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormTitle))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Wp_locationdynamicformds_5_tfwwpformreferencename)) ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormReferenceName like :lV91Wp_locationdynamicformds_5_tfwwpformreferencename)");
      }
      else
      {
         GXv_int9[4] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T2.WWPFormReferenceName = ( :AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel))");
      }
      else
      {
         GXv_int9[5] = 1;
      }
      if ( StringUtil.StrCmp(AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormReferenceName))=0))");
      }
      if ( ! (DateTime.MinValue==AV93Wp_locationdynamicformds_7_tfwwpformdate) )
      {
         AddWhere(sWhereString, "(T2.WWPFormDate >= :AV93Wp_locationdynamicformds_7_tfwwpformdate)");
      }
      else
      {
         GXv_int9[6] = 1;
      }
      if ( ! (DateTime.MinValue==AV94Wp_locationdynamicformds_8_tfwwpformdate_to) )
      {
         AddWhere(sWhereString, "(T2.WWPFormDate <= :AV94Wp_locationdynamicformds_8_tfwwpformdate_to)");
      }
      else
      {
         GXv_int9[7] = 1;
      }
      if ( ! (0==AV95Wp_locationdynamicformds_9_tfwwpformversionnumber) )
      {
         AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV95Wp_locationdynamicformds_9_tfwwpformversionnumber)");
      }
      else
      {
         GXv_int9[8] = 1;
      }
      if ( ! (0==AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to) )
      {
         AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to)");
      }
      else
      {
         GXv_int9[9] = 1;
      }
      scmdbuf += sWhereString;
      if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormTitle, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T2.WWPFormTitle DESC, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormReferenceName, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T2.WWPFormReferenceName DESC, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormDate, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T2.WWPFormDate DESC, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY T2.WWPFormType, T1.WWPFormVersionNumber, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T2.WWPFormType DESC, T1.WWPFormVersionNumber DESC, T1.LocationDynamicFormId, T1.OrganisationId, T1.LocationId";
      }
      GXv_Object10[0] = scmdbuf;
      GXv_Object10[1] = GXv_int9;
      return GXv_Object10 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 2 :
                  return conditional_H006B4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (Guid)dynConstraints[20] , (Guid)dynConstraints[21] );
            case 3 :
                  return conditional_H006B5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (Guid)dynConstraints[20] , (Guid)dynConstraints[21] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH006B2;
       prmH006B2 = new Object[] {
       };
       Object[] prmH006B3;
       prmH006B3 = new Object[] {
       new ParDef("AV82OrganisationIdFilter",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH006B6;
       prmH006B6 = new Object[] {
       };
       Object[] prmH006B4;
       prmH006B4 = new Object[] {
       new ParDef("AV87Wp_locationdynamicformds_1_wwpformtype",GXType.Int16,1,0) ,
       new ParDef("AV61LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("lV89Wp_locationdynamicformds_3_tfwwpformtitle",GXType.VarChar,100,0) ,
       new ParDef("AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
       new ParDef("lV91Wp_locationdynamicformds_5_tfwwpformreferencename",GXType.VarChar,100,0) ,
       new ParDef("AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
       new ParDef("AV93Wp_locationdynamicformds_7_tfwwpformdate",GXType.DateTime,8,5) ,
       new ParDef("AV94Wp_locationdynamicformds_8_tfwwpformdate_to",GXType.DateTime,8,5) ,
       new ParDef("AV95Wp_locationdynamicformds_9_tfwwpformversionnumber",GXType.Int16,4,0) ,
       new ParDef("AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to",GXType.Int16,4,0)
       };
       Object[] prmH006B5;
       prmH006B5 = new Object[] {
       new ParDef("AV87Wp_locationdynamicformds_1_wwpformtype",GXType.Int16,1,0) ,
       new ParDef("AV61LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("lV89Wp_locationdynamicformds_3_tfwwpformtitle",GXType.VarChar,100,0) ,
       new ParDef("AV90Wp_locationdynamicformds_4_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
       new ParDef("lV91Wp_locationdynamicformds_5_tfwwpformreferencename",GXType.VarChar,100,0) ,
       new ParDef("AV92Wp_locationdynamicformds_6_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
       new ParDef("AV93Wp_locationdynamicformds_7_tfwwpformdate",GXType.DateTime,8,5) ,
       new ParDef("AV94Wp_locationdynamicformds_8_tfwwpformdate_to",GXType.DateTime,8,5) ,
       new ParDef("AV95Wp_locationdynamicformds_9_tfwwpformversionnumber",GXType.Int16,4,0) ,
       new ParDef("AV96Wp_locationdynamicformds_10_tfwwpformversionnumber_to",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("H006B2", "SELECT OrganisationId, OrganisationName FROM Trn_Organisation ORDER BY OrganisationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006B2,0, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H006B3", "SELECT LocationId, LocationName, OrganisationId FROM Trn_Location WHERE OrganisationId = :AV82OrganisationIdFilter ORDER BY LocationName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006B3,0, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H006B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006B4,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H006B5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006B5,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H006B6", "SELECT WWPFormVersionNumber, WWPFormId FROM WWP_Form ORDER BY WWPFormId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006B6,1, GxCacheFrequency.OFF ,true,true )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((Guid[]) buf[7])[0] = rslt.getGuid(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((Guid[]) buf[6])[0] = rslt.getGuid(7);
             ((Guid[]) buf[7])[0] = rslt.getGuid(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             return;
          case 4 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
    }
 }

}

}
