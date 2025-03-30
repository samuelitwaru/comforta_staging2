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
   public class trn_appversion : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A29LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
            n29LocationId = false;
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A29LocationId, A11OrganisationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
            n11OrganisationId = false;
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A11OrganisationId) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridtrn_appversion_page") == 0 )
         {
            gxnrGridtrn_appversion_page_newrow_invoke( ) ;
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
         GXKey = Crypto.GetSiteKey( );
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Trn_App Version", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridtrn_appversion_page_newrow_invoke( )
      {
         nRC_GXsfl_63 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_63"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_63_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_63_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_63_idx = GetPar( "sGXsfl_63_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridtrn_appversion_page_newrow( ) ;
         /* End function gxnrGridtrn_appversion_page_newrow_invoke */
      }

      public trn_appversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkIsActive = new GXCheckbox();
         chkIsPredefined = new GXCheckbox();
         cmbPageType = new GXCombobox();
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
            return "trn_appversion_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         A535IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A535IsActive));
         AssignAttri("", false, "A535IsActive", A535IsActive);
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Trn_App Version", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Trn_AppVersion.htm");
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
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppVersionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppVersionId_Internalname, context.GetMessage( "Version Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppVersionId_Internalname, A523AppVersionId.ToString(), A523AppVersionId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppVersionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppVersionId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAppVersionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAppVersionName_Internalname, context.GetMessage( "Version Name", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAppVersionName_Internalname, A524AppVersionName, StringUtil.RTrim( context.localUtil.Format( A524AppVersionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAppVersionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAppVersionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocationId_Internalname, context.GetMessage( "Location Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOrganisationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrganisationId_Internalname, context.GetMessage( "Organisation Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrganisationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkIsActive_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkIsActive_Internalname, context.GetMessage( "Active", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkIsActive_Internalname, StringUtil.BoolToStr( A535IsActive), "", context.GetMessage( "Active", ""), 1, chkIsActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(54, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,54);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divPagetable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlepage_Internalname, context.GetMessage( "Page", ""), "", "", lblTitlepage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridtrn_appversion_page( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AppVersion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridtrn_appversion_page( )
      {
         /*  Grid Control  */
         StartGridControl63( ) ;
         nGXsfl_63_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount95 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_95 = 1;
               ScanStart1L95( ) ;
               while ( RcdFound95 != 0 )
               {
                  init_level_properties95( ) ;
                  getByPrimaryKey1L95( ) ;
                  AddRow1L95( ) ;
                  ScanNext1L95( ) ;
               }
               ScanEnd1L95( ) ;
               nBlankRcdCount95 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1L95( ) ;
            standaloneModal1L95( ) ;
            sMode95 = Gx_mode;
            while ( nGXsfl_63_idx < nRC_GXsfl_63 )
            {
               bGXsfl_63_Refreshing = true;
               ReadRow1L95( ) ;
               edtPageId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGEID_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtPageName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGENAME_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtPageStructure_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGESTRUCTURE_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPageStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageStructure_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtPagePublishedStructure_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPagePublishedStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagePublishedStructure_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               chkIsPredefined.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ISPREDEFINED_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkIsPredefined_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkIsPredefined.Enabled), 5, 0), !bGXsfl_63_Refreshing);
               cmbPageType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGETYPE_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbPageType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPageType.Enabled), 5, 0), !bGXsfl_63_Refreshing);
               if ( ( nRcdExists_95 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1L95( ) ;
               }
               SendRow1L95( ) ;
               bGXsfl_63_Refreshing = false;
            }
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount95 = 5;
            nRcdExists_95 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1L95( ) ;
               while ( RcdFound95 != 0 )
               {
                  sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6395( ) ;
                  init_level_properties95( ) ;
                  standaloneNotModal1L95( ) ;
                  getByPrimaryKey1L95( ) ;
                  standaloneModal1L95( ) ;
                  AddRow1L95( ) ;
                  ScanNext1L95( ) ;
               }
               ScanEnd1L95( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode95 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
         SubsflControlProps_6395( ) ;
         InitAll1L95( ) ;
         init_level_properties95( ) ;
         nRcdExists_95 = 0;
         nIsMod_95 = 0;
         nRcdDeleted_95 = 0;
         nBlankRcdCount95 = (short)(nBlankRcdUsr95+nBlankRcdCount95);
         fRowAdded = 0;
         while ( nBlankRcdCount95 > 0 )
         {
            A516PageId = Guid.Empty;
            standaloneNotModal1L95( ) ;
            standaloneModal1L95( ) ;
            AddRow1L95( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtPageId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount95 = (short)(nBlankRcdCount95-1);
         }
         Gx_mode = sMode95;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridtrn_appversion_pageContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridtrn_appversion_page", Gridtrn_appversion_pageContainer, subGridtrn_appversion_page_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtrn_appversion_pageContainerData", Gridtrn_appversion_pageContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtrn_appversion_pageContainerData"+"V", Gridtrn_appversion_pageContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridtrn_appversion_pageContainerData"+"V"+"\" value='"+Gridtrn_appversion_pageContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z523AppVersionId = StringUtil.StrToGuid( cgiGet( "Z523AppVersionId"));
            Z524AppVersionName = cgiGet( "Z524AppVersionName");
            Z535IsActive = StringUtil.StrToBool( cgiGet( "Z535IsActive"));
            Z29LocationId = StringUtil.StrToGuid( cgiGet( "Z29LocationId"));
            n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
            Z11OrganisationId = StringUtil.StrToGuid( cgiGet( "Z11OrganisationId"));
            n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_63 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_63"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtAppVersionId_Internalname), "") == 0 )
            {
               A523AppVersionId = Guid.Empty;
               AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
            }
            else
            {
               try
               {
                  A523AppVersionId = StringUtil.StrToGuid( cgiGet( edtAppVersionId_Internalname));
                  AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "APPVERSIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A524AppVersionName = cgiGet( edtAppVersionName_Internalname);
            AssignAttri("", false, "A524AppVersionName", A524AppVersionName);
            if ( StringUtil.StrCmp(cgiGet( edtLocationId_Internalname), "") == 0 )
            {
               A29LocationId = Guid.Empty;
               n29LocationId = false;
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            }
            else
            {
               try
               {
                  A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
                  n29LocationId = false;
                  AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "LOCATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtLocationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
            if ( StringUtil.StrCmp(cgiGet( edtOrganisationId_Internalname), "") == 0 )
            {
               A11OrganisationId = Guid.Empty;
               n11OrganisationId = false;
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            }
            else
            {
               try
               {
                  A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                  n11OrganisationId = false;
                  AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ORGANISATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtOrganisationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
            A535IsActive = StringUtil.StrToBool( cgiGet( chkIsActive_Internalname));
            AssignAttri("", false, "A535IsActive", A535IsActive);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A523AppVersionId = StringUtil.StrToGuid( GetPar( "AppVersionId"));
               AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A523AppVersionId) && ( Gx_BScreen == 0 ) )
               {
                  A523AppVersionId = Guid.NewGuid( );
                  AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
               }
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               getEqualNoModal( ) ;
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1L94( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1L94( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_1L95( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow1L95( ) ;
            if ( ( nRcdExists_95 != 0 ) || ( nIsMod_95 != 0 ) )
            {
               GetKey1L95( ) ;
               if ( ( nRcdExists_95 == 0 ) && ( nRcdDeleted_95 == 0 ) )
               {
                  if ( RcdFound95 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1L95( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1L95( ) ;
                        CloseExtendedTableCursors1L95( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PAGEID_" + sGXsfl_63_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound95 != 0 )
                  {
                     if ( nRcdDeleted_95 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1L95( ) ;
                        Load1L95( ) ;
                        BeforeValidate1L95( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1L95( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_95 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1L95( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1L95( ) ;
                              CloseExtendedTableCursors1L95( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_95 == 0 )
                     {
                        GXCCtl = "PAGEID_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPageId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPageId_Internalname, A516PageId.ToString()) ;
            ChangePostValue( edtPageName_Internalname, A517PageName) ;
            ChangePostValue( edtPageStructure_Internalname, A518PageStructure) ;
            ChangePostValue( edtPagePublishedStructure_Internalname, A536PagePublishedStructure) ;
            ChangePostValue( chkIsPredefined_Internalname, StringUtil.BoolToStr( A541IsPredefined)) ;
            ChangePostValue( cmbPageType_Internalname, A525PageType) ;
            ChangePostValue( "ZT_"+"Z516PageId_"+sGXsfl_63_idx, Z516PageId.ToString()) ;
            ChangePostValue( "ZT_"+"Z541IsPredefined_"+sGXsfl_63_idx, StringUtil.BoolToStr( Z541IsPredefined)) ;
            ChangePostValue( "ZT_"+"Z517PageName_"+sGXsfl_63_idx, Z517PageName) ;
            ChangePostValue( "ZT_"+"Z525PageType_"+sGXsfl_63_idx, Z525PageType) ;
            ChangePostValue( "nRcdDeleted_95_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_95_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_95_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_95 != 0 )
            {
               ChangePostValue( "PAGEID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGENAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGESTRUCTURE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPagePublishedStructure_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ISPREDEFINED_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkIsPredefined.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGETYPE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1L0( )
      {
      }

      protected void ZM1L94( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z524AppVersionName = T001L5_A524AppVersionName[0];
               Z535IsActive = T001L5_A535IsActive[0];
               Z29LocationId = T001L5_A29LocationId[0];
               Z11OrganisationId = T001L5_A11OrganisationId[0];
            }
            else
            {
               Z524AppVersionName = A524AppVersionName;
               Z535IsActive = A535IsActive;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z523AppVersionId = A523AppVersionId;
            Z524AppVersionName = A524AppVersionName;
            Z535IsActive = A535IsActive;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A523AppVersionId) && ( Gx_BScreen == 0 ) )
         {
            A523AppVersionId = Guid.NewGuid( );
            AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1L94( )
      {
         /* Using cursor T001L8 */
         pr_default.execute(6, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound94 = 1;
            A524AppVersionName = T001L8_A524AppVersionName[0];
            AssignAttri("", false, "A524AppVersionName", A524AppVersionName);
            A535IsActive = T001L8_A535IsActive[0];
            AssignAttri("", false, "A535IsActive", A535IsActive);
            A29LocationId = T001L8_A29LocationId[0];
            n29LocationId = T001L8_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T001L8_A11OrganisationId[0];
            n11OrganisationId = T001L8_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            ZM1L94( -9) ;
         }
         pr_default.close(6);
         OnLoadActions1L94( ) ;
      }

      protected void OnLoadActions1L94( )
      {
      }

      protected void CheckExtendedTable1L94( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T001L9 */
         pr_default.execute(7, new Object[] {A524AppVersionName, n29LocationId, A29LocationId, A523AppVersionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "App Version Name", "")+","+context.GetMessage( "Location Id", "")}), 1, "APPVERSIONNAME");
            AnyError = 1;
            GX_FocusControl = edtAppVersionName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(7);
         /* Using cursor T001L7 */
         pr_default.execute(5, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtLocationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T001L6 */
         pr_default.execute(4, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtOrganisationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1L94( )
      {
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( Guid A29LocationId ,
                                Guid A11OrganisationId )
      {
         /* Using cursor T001L10 */
         pr_default.execute(8, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtLocationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_11( Guid A11OrganisationId )
      {
         /* Using cursor T001L11 */
         pr_default.execute(9, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtOrganisationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey1L94( )
      {
         /* Using cursor T001L12 */
         pr_default.execute(10, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound94 = 1;
         }
         else
         {
            RcdFound94 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001L5 */
         pr_default.execute(3, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1L94( 9) ;
            RcdFound94 = 1;
            A523AppVersionId = T001L5_A523AppVersionId[0];
            AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
            A524AppVersionName = T001L5_A524AppVersionName[0];
            AssignAttri("", false, "A524AppVersionName", A524AppVersionName);
            A535IsActive = T001L5_A535IsActive[0];
            AssignAttri("", false, "A535IsActive", A535IsActive);
            A29LocationId = T001L5_A29LocationId[0];
            n29LocationId = T001L5_n29LocationId[0];
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            A11OrganisationId = T001L5_A11OrganisationId[0];
            n11OrganisationId = T001L5_n11OrganisationId[0];
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            Z523AppVersionId = A523AppVersionId;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1L94( ) ;
            if ( AnyError == 1 )
            {
               RcdFound94 = 0;
               InitializeNonKey1L94( ) ;
            }
            Gx_mode = sMode94;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound94 = 0;
            InitializeNonKey1L94( ) ;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode94;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1L94( ) ;
         if ( RcdFound94 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound94 = 0;
         /* Using cursor T001L13 */
         pr_default.execute(11, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T001L13_A523AppVersionId[0], A523AppVersionId, 0) < 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T001L13_A523AppVersionId[0], A523AppVersionId, 0) > 0 ) ) )
            {
               A523AppVersionId = T001L13_A523AppVersionId[0];
               AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
               RcdFound94 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound94 = 0;
         /* Using cursor T001L14 */
         pr_default.execute(12, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T001L14_A523AppVersionId[0], A523AppVersionId, 0) > 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( GuidUtil.Compare(T001L14_A523AppVersionId[0], A523AppVersionId, 0) < 0 ) ) )
            {
               A523AppVersionId = T001L14_A523AppVersionId[0];
               AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
               RcdFound94 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1L94( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1L94( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound94 == 1 )
            {
               if ( A523AppVersionId != Z523AppVersionId )
               {
                  A523AppVersionId = Z523AppVersionId;
                  AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "APPVERSIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1L94( ) ;
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A523AppVersionId != Z523AppVersionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAppVersionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1L94( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "APPVERSIONID");
                     AnyError = 1;
                     GX_FocusControl = edtAppVersionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAppVersionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1L94( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A523AppVersionId != Z523AppVersionId )
         {
            A523AppVersionId = Z523AppVersionId;
            AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "APPVERSIONID");
            AnyError = 1;
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound94 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "APPVERSIONID");
            AnyError = 1;
            GX_FocusControl = edtAppVersionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAppVersionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1L94( ) ;
         if ( RcdFound94 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppVersionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1L94( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound94 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppVersionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound94 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppVersionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1L94( ) ;
         if ( RcdFound94 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound94 != 0 )
            {
               ScanNext1L94( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAppVersionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1L94( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1L94( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001L4 */
            pr_default.execute(2, new Object[] {A523AppVersionId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z524AppVersionName, T001L4_A524AppVersionName[0]) != 0 ) || ( Z535IsActive != T001L4_A535IsActive[0] ) || ( Z29LocationId != T001L4_A29LocationId[0] ) || ( Z11OrganisationId != T001L4_A11OrganisationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z524AppVersionName, T001L4_A524AppVersionName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"AppVersionName");
                  GXUtil.WriteLogRaw("Old: ",Z524AppVersionName);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A524AppVersionName[0]);
               }
               if ( Z535IsActive != T001L4_A535IsActive[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"IsActive");
                  GXUtil.WriteLogRaw("Old: ",Z535IsActive);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A535IsActive[0]);
               }
               if ( Z29LocationId != T001L4_A29LocationId[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"LocationId");
                  GXUtil.WriteLogRaw("Old: ",Z29LocationId);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A29LocationId[0]);
               }
               if ( Z11OrganisationId != T001L4_A11OrganisationId[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"OrganisationId");
                  GXUtil.WriteLogRaw("Old: ",Z11OrganisationId);
                  GXUtil.WriteLogRaw("Current: ",T001L4_A11OrganisationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppVersion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1L94( )
      {
         if ( ! IsAuthorized("trn_appversion_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1L94( 0) ;
            CheckOptimisticConcurrency1L94( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L94( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1L94( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L15 */
                     pr_default.execute(13, new Object[] {A523AppVersionId, A524AppVersionName, A535IsActive, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( (pr_default.getStatus(13) == 1) )
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
                           ProcessLevel1L94( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1L0( ) ;
                           }
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
               Load1L94( ) ;
            }
            EndLevel1L94( ) ;
         }
         CloseExtendedTableCursors1L94( ) ;
      }

      protected void Update1L94( )
      {
         if ( ! IsAuthorized("trn_appversion_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L94( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L94( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1L94( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L16 */
                     pr_default.execute(14, new Object[] {A524AppVersionName, A535IsActive, n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId, A523AppVersionId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1L94( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1L94( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption1L0( ) ;
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
            }
            EndLevel1L94( ) ;
         }
         CloseExtendedTableCursors1L94( ) ;
      }

      protected void DeferredUpdate1L94( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_appversion_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1L94( ) ;
            AfterConfirm1L94( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1L94( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1L95( ) ;
                  while ( RcdFound95 != 0 )
                  {
                     getByPrimaryKey1L95( ) ;
                     Delete1L95( ) ;
                     ScanNext1L95( ) ;
                  }
                  ScanEnd1L95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L17 */
                     pr_default.execute(15, new Object[] {A523AppVersionId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound94 == 0 )
                           {
                              InitAll1L94( ) ;
                              Gx_mode = "INS";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           else
                           {
                              getByPrimaryKey( ) ;
                              Gx_mode = "UPD";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                           ResetCaption1L0( ) ;
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
         }
         sMode94 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1L94( ) ;
         Gx_mode = sMode94;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1L94( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel1L95( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow1L95( ) ;
            if ( ( nRcdExists_95 != 0 ) || ( nIsMod_95 != 0 ) )
            {
               standaloneNotModal1L95( ) ;
               GetKey1L95( ) ;
               if ( ( nRcdExists_95 == 0 ) && ( nRcdDeleted_95 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1L95( ) ;
               }
               else
               {
                  if ( RcdFound95 != 0 )
                  {
                     if ( ( nRcdDeleted_95 != 0 ) && ( nRcdExists_95 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1L95( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_95 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1L95( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_95 == 0 )
                     {
                        GXCCtl = "PAGEID_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPageId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPageId_Internalname, A516PageId.ToString()) ;
            ChangePostValue( edtPageName_Internalname, A517PageName) ;
            ChangePostValue( edtPageStructure_Internalname, A518PageStructure) ;
            ChangePostValue( edtPagePublishedStructure_Internalname, A536PagePublishedStructure) ;
            ChangePostValue( chkIsPredefined_Internalname, StringUtil.BoolToStr( A541IsPredefined)) ;
            ChangePostValue( cmbPageType_Internalname, A525PageType) ;
            ChangePostValue( "ZT_"+"Z516PageId_"+sGXsfl_63_idx, Z516PageId.ToString()) ;
            ChangePostValue( "ZT_"+"Z541IsPredefined_"+sGXsfl_63_idx, StringUtil.BoolToStr( Z541IsPredefined)) ;
            ChangePostValue( "ZT_"+"Z517PageName_"+sGXsfl_63_idx, Z517PageName) ;
            ChangePostValue( "ZT_"+"Z525PageType_"+sGXsfl_63_idx, Z525PageType) ;
            ChangePostValue( "nRcdDeleted_95_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_95_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_95_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_95), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_95 != 0 )
            {
               ChangePostValue( "PAGEID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGENAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGESTRUCTURE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPagePublishedStructure_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ISPREDEFINED_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkIsPredefined.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAGETYPE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1L95( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_95 = 0;
         nIsMod_95 = 0;
         nRcdDeleted_95 = 0;
      }

      protected void ProcessLevel1L94( )
      {
         /* Save parent mode. */
         sMode94 = Gx_mode;
         ProcessNestedLevel1L95( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode94;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1L94( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_appversion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_appversion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1L94( )
      {
         /* Using cursor T001L18 */
         pr_default.execute(16);
         RcdFound94 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound94 = 1;
            A523AppVersionId = T001L18_A523AppVersionId[0];
            AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1L94( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound94 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound94 = 1;
            A523AppVersionId = T001L18_A523AppVersionId[0];
            AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
         }
      }

      protected void ScanEnd1L94( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm1L94( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1L94( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1L94( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1L94( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1L94( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1L94( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1L94( )
      {
         edtAppVersionId_Enabled = 0;
         AssignProp("", false, edtAppVersionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppVersionId_Enabled), 5, 0), true);
         edtAppVersionName_Enabled = 0;
         AssignProp("", false, edtAppVersionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAppVersionName_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         chkIsActive.Enabled = 0;
         AssignProp("", false, chkIsActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkIsActive.Enabled), 5, 0), true);
      }

      protected void ZM1L95( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z541IsPredefined = T001L3_A541IsPredefined[0];
               Z517PageName = T001L3_A517PageName[0];
               Z525PageType = T001L3_A525PageType[0];
            }
            else
            {
               Z541IsPredefined = A541IsPredefined;
               Z517PageName = A517PageName;
               Z525PageType = A525PageType;
            }
         }
         if ( GX_JID == -13 )
         {
            Z523AppVersionId = A523AppVersionId;
            Z516PageId = A516PageId;
            Z541IsPredefined = A541IsPredefined;
            Z517PageName = A517PageName;
            Z518PageStructure = A518PageStructure;
            Z536PagePublishedStructure = A536PagePublishedStructure;
            Z525PageType = A525PageType;
         }
      }

      protected void standaloneNotModal1L95( )
      {
      }

      protected void standaloneModal1L95( )
      {
         if ( IsIns( )  && (Guid.Empty==A516PageId) && ( Gx_BScreen == 0 ) )
         {
            A516PageId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A541IsPredefined) && ( Gx_BScreen == 0 ) )
         {
            A541IsPredefined = false;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPageId_Enabled = 0;
            AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
         else
         {
            edtPageId_Enabled = 1;
            AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1L95( )
      {
         /* Using cursor T001L19 */
         pr_default.execute(17, new Object[] {A523AppVersionId, A516PageId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound95 = 1;
            A541IsPredefined = T001L19_A541IsPredefined[0];
            A517PageName = T001L19_A517PageName[0];
            A518PageStructure = T001L19_A518PageStructure[0];
            A536PagePublishedStructure = T001L19_A536PagePublishedStructure[0];
            A525PageType = T001L19_A525PageType[0];
            ZM1L95( -13) ;
         }
         pr_default.close(17);
         OnLoadActions1L95( ) ;
      }

      protected void OnLoadActions1L95( )
      {
      }

      protected void CheckExtendedTable1L95( )
      {
         nIsDirty_95 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1L95( ) ;
         if ( ! ( ( StringUtil.StrCmp(A525PageType, "Menu") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Content") == 0 ) || ( StringUtil.StrCmp(A525PageType, "WebLink") == 0 ) || ( StringUtil.StrCmp(A525PageType, "DynamicForm") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Calendar") == 0 ) || ( StringUtil.StrCmp(A525PageType, "MyActivity") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Maps") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Reception") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Location") == 0 ) || ( StringUtil.StrCmp(A525PageType, "My Care") == 0 ) || ( StringUtil.StrCmp(A525PageType, "My Living") == 0 ) || ( StringUtil.StrCmp(A525PageType, "MyService") == 0 ) ) )
         {
            GXCCtl = "PAGETYPE_" + sGXsfl_63_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Page Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbPageType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1L95( )
      {
      }

      protected void enableDisable1L95( )
      {
      }

      protected void GetKey1L95( )
      {
         /* Using cursor T001L20 */
         pr_default.execute(18, new Object[] {A523AppVersionId, A516PageId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound95 = 1;
         }
         else
         {
            RcdFound95 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey1L95( )
      {
         /* Using cursor T001L3 */
         pr_default.execute(1, new Object[] {A523AppVersionId, A516PageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1L95( 13) ;
            RcdFound95 = 1;
            InitializeNonKey1L95( ) ;
            A516PageId = T001L3_A516PageId[0];
            A541IsPredefined = T001L3_A541IsPredefined[0];
            A517PageName = T001L3_A517PageName[0];
            A518PageStructure = T001L3_A518PageStructure[0];
            A536PagePublishedStructure = T001L3_A536PagePublishedStructure[0];
            A525PageType = T001L3_A525PageType[0];
            Z523AppVersionId = A523AppVersionId;
            Z516PageId = A516PageId;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1L95( ) ;
            Load1L95( ) ;
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound95 = 0;
            InitializeNonKey1L95( ) ;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1L95( ) ;
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1L95( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1L95( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001L2 */
            pr_default.execute(0, new Object[] {A523AppVersionId, A516PageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersionPage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z541IsPredefined != T001L2_A541IsPredefined[0] ) || ( StringUtil.StrCmp(Z517PageName, T001L2_A517PageName[0]) != 0 ) || ( StringUtil.StrCmp(Z525PageType, T001L2_A525PageType[0]) != 0 ) )
            {
               if ( Z541IsPredefined != T001L2_A541IsPredefined[0] )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"IsPredefined");
                  GXUtil.WriteLogRaw("Old: ",Z541IsPredefined);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A541IsPredefined[0]);
               }
               if ( StringUtil.StrCmp(Z517PageName, T001L2_A517PageName[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"PageName");
                  GXUtil.WriteLogRaw("Old: ",Z517PageName);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A517PageName[0]);
               }
               if ( StringUtil.StrCmp(Z525PageType, T001L2_A525PageType[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_appversion:[seudo value changed for attri]"+"PageType");
                  GXUtil.WriteLogRaw("Old: ",Z525PageType);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A525PageType[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppVersionPage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1L95( )
      {
         if ( ! IsAuthorized("trn_appversion_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L95( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1L95( 0) ;
            CheckOptimisticConcurrency1L95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1L95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L21 */
                     pr_default.execute(19, new Object[] {A523AppVersionId, A516PageId, A541IsPredefined, A517PageName, A518PageStructure, A536PagePublishedStructure, A525PageType});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                     if ( (pr_default.getStatus(19) == 1) )
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
               Load1L95( ) ;
            }
            EndLevel1L95( ) ;
         }
         CloseExtendedTableCursors1L95( ) ;
      }

      protected void Update1L95( )
      {
         if ( ! IsAuthorized("trn_appversion_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1L95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L95( ) ;
         }
         if ( ( nIsMod_95 != 0 ) || ( nIsDirty_95 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1L95( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1L95( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1L95( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001L22 */
                        pr_default.execute(20, new Object[] {A541IsPredefined, A517PageName, A518PageStructure, A536PagePublishedStructure, A525PageType, A523AppVersionId, A516PageId});
                        pr_default.close(20);
                        pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                        if ( (pr_default.getStatus(20) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersionPage"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1L95( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1L95( ) ;
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
               EndLevel1L95( ) ;
            }
         }
         CloseExtendedTableCursors1L95( ) ;
      }

      protected void DeferredUpdate1L95( )
      {
      }

      protected void Delete1L95( )
      {
         if ( ! IsAuthorized("trn_appversion_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1L95( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L95( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1L95( ) ;
            AfterConfirm1L95( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1L95( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001L23 */
                  pr_default.execute(21, new Object[] {A523AppVersionId, A516PageId});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode95 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1L95( ) ;
         Gx_mode = sMode95;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1L95( )
      {
         standaloneModal1L95( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1L95( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1L95( )
      {
         /* Scan By routine */
         /* Using cursor T001L24 */
         pr_default.execute(22, new Object[] {A523AppVersionId});
         RcdFound95 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound95 = 1;
            A516PageId = T001L24_A516PageId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1L95( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound95 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound95 = 1;
            A516PageId = T001L24_A516PageId[0];
         }
      }

      protected void ScanEnd1L95( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm1L95( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1L95( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1L95( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1L95( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1L95( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1L95( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1L95( )
      {
         edtPageId_Enabled = 0;
         AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtPageName_Enabled = 0;
         AssignProp("", false, edtPageName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageName_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtPageStructure_Enabled = 0;
         AssignProp("", false, edtPageStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageStructure_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtPagePublishedStructure_Enabled = 0;
         AssignProp("", false, edtPagePublishedStructure_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagePublishedStructure_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         chkIsPredefined.Enabled = 0;
         AssignProp("", false, chkIsPredefined_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkIsPredefined.Enabled), 5, 0), !bGXsfl_63_Refreshing);
         cmbPageType.Enabled = 0;
         AssignProp("", false, cmbPageType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPageType.Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void send_integrity_lvl_hashes1L95( )
      {
      }

      protected void send_integrity_lvl_hashes1L94( )
      {
      }

      protected void SubsflControlProps_6395( )
      {
         edtPageId_Internalname = "PAGEID_"+sGXsfl_63_idx;
         edtPageName_Internalname = "PAGENAME_"+sGXsfl_63_idx;
         edtPageStructure_Internalname = "PAGESTRUCTURE_"+sGXsfl_63_idx;
         edtPagePublishedStructure_Internalname = "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_63_idx;
         chkIsPredefined_Internalname = "ISPREDEFINED_"+sGXsfl_63_idx;
         cmbPageType_Internalname = "PAGETYPE_"+sGXsfl_63_idx;
      }

      protected void SubsflControlProps_fel_6395( )
      {
         edtPageId_Internalname = "PAGEID_"+sGXsfl_63_fel_idx;
         edtPageName_Internalname = "PAGENAME_"+sGXsfl_63_fel_idx;
         edtPageStructure_Internalname = "PAGESTRUCTURE_"+sGXsfl_63_fel_idx;
         edtPagePublishedStructure_Internalname = "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_63_fel_idx;
         chkIsPredefined_Internalname = "ISPREDEFINED_"+sGXsfl_63_fel_idx;
         cmbPageType_Internalname = "PAGETYPE_"+sGXsfl_63_fel_idx;
      }

      protected void AddRow1L95( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6395( ) ;
         SendRow1L95( ) ;
      }

      protected void SendRow1L95( )
      {
         Gridtrn_appversion_pageRow = GXWebRow.GetNew(context);
         if ( subGridtrn_appversion_page_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridtrn_appversion_page_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridtrn_appversion_page_Class, "") != 0 )
            {
               subGridtrn_appversion_page_Linesclass = subGridtrn_appversion_page_Class+"Odd";
            }
         }
         else if ( subGridtrn_appversion_page_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridtrn_appversion_page_Backstyle = 0;
            subGridtrn_appversion_page_Backcolor = subGridtrn_appversion_page_Allbackcolor;
            if ( StringUtil.StrCmp(subGridtrn_appversion_page_Class, "") != 0 )
            {
               subGridtrn_appversion_page_Linesclass = subGridtrn_appversion_page_Class+"Uniform";
            }
         }
         else if ( subGridtrn_appversion_page_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridtrn_appversion_page_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridtrn_appversion_page_Class, "") != 0 )
            {
               subGridtrn_appversion_page_Linesclass = subGridtrn_appversion_page_Class+"Odd";
            }
            subGridtrn_appversion_page_Backcolor = (int)(0x0);
         }
         else if ( subGridtrn_appversion_page_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridtrn_appversion_page_Backstyle = 1;
            if ( ((int)((nGXsfl_63_idx) % (2))) == 0 )
            {
               subGridtrn_appversion_page_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtrn_appversion_page_Class, "") != 0 )
               {
                  subGridtrn_appversion_page_Linesclass = subGridtrn_appversion_page_Class+"Even";
               }
            }
            else
            {
               subGridtrn_appversion_page_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtrn_appversion_page_Class, "") != 0 )
               {
                  subGridtrn_appversion_page_Linesclass = subGridtrn_appversion_page_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridtrn_appversion_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageId_Internalname,A516PageId.ToString(),A516PageId.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPageId_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)63,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridtrn_appversion_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageName_Internalname,(string)A517PageName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPageName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridtrn_appversion_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPageStructure_Internalname,(string)A518PageStructure,(string)A518PageStructure,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPageStructure_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPageStructure_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)63,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridtrn_appversion_pageRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPagePublishedStructure_Internalname,(string)A536PagePublishedStructure,(string)A536PagePublishedStructure,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPagePublishedStructure_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPagePublishedStructure_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)63,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "ISPREDEFINED_" + sGXsfl_63_idx;
         chkIsPredefined.Name = GXCCtl;
         chkIsPredefined.WebTags = "";
         chkIsPredefined.Caption = "";
         AssignProp("", false, chkIsPredefined_Internalname, "TitleCaption", chkIsPredefined.Caption, !bGXsfl_63_Refreshing);
         chkIsPredefined.CheckedValue = "false";
         if ( IsIns( ) && (false==A541IsPredefined) )
         {
            A541IsPredefined = false;
         }
         Gridtrn_appversion_pageRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkIsPredefined_Internalname,StringUtil.BoolToStr( A541IsPredefined),(string)"",(string)"",(short)-1,chkIsPredefined.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(68, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,68);\""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_95_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_63_idx + "',63)\"";
         if ( ( cmbPageType.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "PAGETYPE_" + sGXsfl_63_idx;
            cmbPageType.Name = GXCCtl;
            cmbPageType.WebTags = "";
            cmbPageType.addItem("Menu", context.GetMessage( "Menu", ""), 0);
            cmbPageType.addItem("Content", context.GetMessage( "Content", ""), 0);
            cmbPageType.addItem("WebLink", context.GetMessage( "Web Link", ""), 0);
            cmbPageType.addItem("DynamicForm", context.GetMessage( "Dynamic Form", ""), 0);
            cmbPageType.addItem("Calendar", context.GetMessage( "Calendar", ""), 0);
            cmbPageType.addItem("MyActivity", context.GetMessage( "My Activity", ""), 0);
            cmbPageType.addItem("Maps", context.GetMessage( "Maps", ""), 0);
            cmbPageType.addItem("Reception", context.GetMessage( "Reception", ""), 0);
            cmbPageType.addItem("Location", context.GetMessage( "Location", ""), 0);
            cmbPageType.addItem("My Care", context.GetMessage( "My Care", ""), 0);
            cmbPageType.addItem("My Living", context.GetMessage( "My Living", ""), 0);
            cmbPageType.addItem("MyService", context.GetMessage( "My Service", ""), 0);
            if ( cmbPageType.ItemCount > 0 )
            {
               A525PageType = cmbPageType.getValidValue(A525PageType);
            }
         }
         /* ComboBox */
         Gridtrn_appversion_pageRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPageType,(string)cmbPageType_Internalname,StringUtil.RTrim( A525PageType),(short)1,(string)cmbPageType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbPageType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"",(string)"",(bool)true,(short)0});
         cmbPageType.CurrentValue = StringUtil.RTrim( A525PageType);
         AssignProp("", false, cmbPageType_Internalname, "Values", (string)(cmbPageType.ToJavascriptSource()), !bGXsfl_63_Refreshing);
         ajax_sending_grid_row(Gridtrn_appversion_pageRow);
         send_integrity_lvl_hashes1L95( ) ;
         GXCCtl = "Z516PageId_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z516PageId.ToString());
         GXCCtl = "Z541IsPredefined_" + sGXsfl_63_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z541IsPredefined);
         GXCCtl = "Z517PageName_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z517PageName);
         GXCCtl = "Z525PageType_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z525PageType);
         GXCCtl = "nRcdDeleted_95_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_95), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_95_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_95), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_95_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_95), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PAGEID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGENAME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGESTRUCTURE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPagePublishedStructure_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ISPREDEFINED_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkIsPredefined.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAGETYPE_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridtrn_appversion_pageContainer.AddRow(Gridtrn_appversion_pageRow);
      }

      protected void ReadRow1L95( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6395( ) ;
         edtPageId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGEID_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPageName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGENAME_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPageStructure_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGESTRUCTURE_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPagePublishedStructure_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGEPUBLISHEDSTRUCTURE_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         chkIsPredefined.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ISPREDEFINED_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbPageType.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAGETYPE_"+sGXsfl_63_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtPageId_Internalname), "") == 0 )
         {
            A516PageId = Guid.Empty;
         }
         else
         {
            try
            {
               A516PageId = StringUtil.StrToGuid( cgiGet( edtPageId_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "PAGEID_" + sGXsfl_63_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtPageId_Internalname;
               wbErr = true;
            }
         }
         A517PageName = cgiGet( edtPageName_Internalname);
         A518PageStructure = cgiGet( edtPageStructure_Internalname);
         A536PagePublishedStructure = cgiGet( edtPagePublishedStructure_Internalname);
         A541IsPredefined = StringUtil.StrToBool( cgiGet( chkIsPredefined_Internalname));
         cmbPageType.Name = cmbPageType_Internalname;
         cmbPageType.CurrentValue = cgiGet( cmbPageType_Internalname);
         A525PageType = cgiGet( cmbPageType_Internalname);
         GXCCtl = "Z516PageId_" + sGXsfl_63_idx;
         Z516PageId = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z541IsPredefined_" + sGXsfl_63_idx;
         Z541IsPredefined = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "Z517PageName_" + sGXsfl_63_idx;
         Z517PageName = cgiGet( GXCCtl);
         GXCCtl = "Z525PageType_" + sGXsfl_63_idx;
         Z525PageType = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_95_" + sGXsfl_63_idx;
         nRcdDeleted_95 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_95_" + sGXsfl_63_idx;
         nRcdExists_95 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_95_" + sGXsfl_63_idx;
         nIsMod_95 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtPageId_Enabled = edtPageId_Enabled;
      }

      protected void ConfirmValues1L0( )
      {
         nGXsfl_63_idx = 0;
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_6395( ) ;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_6395( ) ;
            ChangePostValue( "Z516PageId_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z516PageId_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z516PageId_"+sGXsfl_63_idx) ;
            ChangePostValue( "Z541IsPredefined_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z541IsPredefined_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z541IsPredefined_"+sGXsfl_63_idx) ;
            ChangePostValue( "Z517PageName_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z517PageName_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z517PageName_"+sGXsfl_63_idx) ;
            ChangePostValue( "Z525PageType_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z525PageType_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z525PageType_"+sGXsfl_63_idx) ;
         }
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
         MasterPageObj.master_styles();
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_appversion.aspx") +"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z523AppVersionId", Z523AppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "Z524AppVersionName", Z524AppVersionName);
         GxWebStd.gx_boolean_hidden_field( context, "Z535IsActive", Z535IsActive);
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_63", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_63_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("trn_appversion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_AppVersion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_App Version", "") ;
      }

      protected void InitializeNonKey1L94( )
      {
         A524AppVersionName = "";
         AssignAttri("", false, "A524AppVersionName", A524AppVersionName);
         A29LocationId = Guid.Empty;
         n29LocationId = false;
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         n29LocationId = ((Guid.Empty==A29LocationId) ? true : false);
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         n11OrganisationId = ((Guid.Empty==A11OrganisationId) ? true : false);
         A535IsActive = false;
         AssignAttri("", false, "A535IsActive", A535IsActive);
         Z524AppVersionName = "";
         Z535IsActive = false;
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll1L94( )
      {
         A523AppVersionId = Guid.NewGuid( );
         AssignAttri("", false, "A523AppVersionId", A523AppVersionId.ToString());
         InitializeNonKey1L94( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1L95( )
      {
         A517PageName = "";
         A518PageStructure = "";
         A536PagePublishedStructure = "";
         A525PageType = "";
         A541IsPredefined = false;
         Z541IsPredefined = false;
         Z517PageName = "";
         Z525PageType = "";
      }

      protected void InitAll1L95( )
      {
         A516PageId = Guid.NewGuid( );
         InitializeNonKey1L95( ) ;
      }

      protected void StandaloneModalInsert1L95( )
      {
         A541IsPredefined = i541IsPredefined;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20253281854760", true, true);
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
         context.AddJavascriptSource("trn_appversion.js", "?20253281854760", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties95( )
      {
         edtPageId_Enabled = defedtPageId_Enabled;
         AssignProp("", false, edtPageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPageId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void StartGridControl63( )
      {
         Gridtrn_appversion_pageContainer.AddObjectProperty("GridName", "Gridtrn_appversion_page");
         Gridtrn_appversion_pageContainer.AddObjectProperty("Header", subGridtrn_appversion_page_Header);
         Gridtrn_appversion_pageContainer.AddObjectProperty("Class", "Grid");
         Gridtrn_appversion_pageContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Backcolorstyle), 1, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("CmpContext", "");
         Gridtrn_appversion_pageContainer.AddObjectProperty("InMasterPage", "false");
         Gridtrn_appversion_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A516PageId.ToString()));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageId_Enabled), 5, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddColumnProperties(Gridtrn_appversion_pageColumn);
         Gridtrn_appversion_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A517PageName));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageName_Enabled), 5, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddColumnProperties(Gridtrn_appversion_pageColumn);
         Gridtrn_appversion_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A518PageStructure));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPageStructure_Enabled), 5, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddColumnProperties(Gridtrn_appversion_pageColumn);
         Gridtrn_appversion_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A536PagePublishedStructure));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPagePublishedStructure_Enabled), 5, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddColumnProperties(Gridtrn_appversion_pageColumn);
         Gridtrn_appversion_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A541IsPredefined)));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkIsPredefined.Enabled), 5, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddColumnProperties(Gridtrn_appversion_pageColumn);
         Gridtrn_appversion_pageColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A525PageType));
         Gridtrn_appversion_pageColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbPageType.Enabled), 5, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddColumnProperties(Gridtrn_appversion_pageColumn);
         Gridtrn_appversion_pageContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Selectedindex), 4, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Allowselection), 1, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Selectioncolor), 9, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Allowhovering), 1, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Hoveringcolor), 9, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Allowcollapsing), 1, 0, ".", "")));
         Gridtrn_appversion_pageContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrn_appversion_page_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtAppVersionId_Internalname = "APPVERSIONID";
         edtAppVersionName_Internalname = "APPVERSIONNAME";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         chkIsActive_Internalname = "ISACTIVE";
         lblTitlepage_Internalname = "TITLEPAGE";
         edtPageId_Internalname = "PAGEID";
         edtPageName_Internalname = "PAGENAME";
         edtPageStructure_Internalname = "PAGESTRUCTURE";
         edtPagePublishedStructure_Internalname = "PAGEPUBLISHEDSTRUCTURE";
         chkIsPredefined_Internalname = "ISPREDEFINED";
         cmbPageType_Internalname = "PAGETYPE";
         divPagetable_Internalname = "PAGETABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridtrn_appversion_page_Internalname = "GRIDTRN_APPVERSION_PAGE";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridtrn_appversion_page_Allowcollapsing = 0;
         subGridtrn_appversion_page_Allowselection = 0;
         subGridtrn_appversion_page_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_App Version", "");
         cmbPageType_Jsonclick = "";
         chkIsPredefined.Caption = "";
         edtPagePublishedStructure_Jsonclick = "";
         edtPageStructure_Jsonclick = "";
         edtPageName_Jsonclick = "";
         edtPageId_Jsonclick = "";
         subGridtrn_appversion_page_Class = "Grid";
         subGridtrn_appversion_page_Backcolorstyle = 0;
         cmbPageType.Enabled = 1;
         chkIsPredefined.Enabled = 1;
         edtPagePublishedStructure_Enabled = 1;
         edtPageStructure_Enabled = 1;
         edtPageName_Enabled = 1;
         edtPageId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkIsActive.Enabled = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Enabled = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Enabled = 1;
         edtAppVersionName_Jsonclick = "";
         edtAppVersionName_Enabled = 1;
         edtAppVersionId_Jsonclick = "";
         edtAppVersionId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridtrn_appversion_page_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6395( ) ;
         while ( nGXsfl_63_idx <= nRC_GXsfl_63 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1L95( ) ;
            standaloneModal1L95( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1L95( ) ;
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_6395( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridtrn_appversion_pageContainer)) ;
         /* End function gxnrGridtrn_appversion_page_newrow */
      }

      protected void init_web_controls( )
      {
         chkIsActive.Name = "ISACTIVE";
         chkIsActive.WebTags = "";
         chkIsActive.Caption = context.GetMessage( "Active", "");
         AssignProp("", false, chkIsActive_Internalname, "TitleCaption", chkIsActive.Caption, true);
         chkIsActive.CheckedValue = "false";
         A535IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A535IsActive));
         AssignAttri("", false, "A535IsActive", A535IsActive);
         GXCCtl = "ISPREDEFINED_" + sGXsfl_63_idx;
         chkIsPredefined.Name = GXCCtl;
         chkIsPredefined.WebTags = "";
         chkIsPredefined.Caption = "";
         AssignProp("", false, chkIsPredefined_Internalname, "TitleCaption", chkIsPredefined.Caption, !bGXsfl_63_Refreshing);
         chkIsPredefined.CheckedValue = "false";
         if ( IsIns( ) && (false==A541IsPredefined) )
         {
            A541IsPredefined = false;
         }
         GXCCtl = "PAGETYPE_" + sGXsfl_63_idx;
         cmbPageType.Name = GXCCtl;
         cmbPageType.WebTags = "";
         cmbPageType.addItem("Menu", context.GetMessage( "Menu", ""), 0);
         cmbPageType.addItem("Content", context.GetMessage( "Content", ""), 0);
         cmbPageType.addItem("WebLink", context.GetMessage( "Web Link", ""), 0);
         cmbPageType.addItem("DynamicForm", context.GetMessage( "Dynamic Form", ""), 0);
         cmbPageType.addItem("Calendar", context.GetMessage( "Calendar", ""), 0);
         cmbPageType.addItem("MyActivity", context.GetMessage( "My Activity", ""), 0);
         cmbPageType.addItem("Maps", context.GetMessage( "Maps", ""), 0);
         cmbPageType.addItem("Reception", context.GetMessage( "Reception", ""), 0);
         cmbPageType.addItem("Location", context.GetMessage( "Location", ""), 0);
         cmbPageType.addItem("My Care", context.GetMessage( "My Care", ""), 0);
         cmbPageType.addItem("My Living", context.GetMessage( "My Living", ""), 0);
         cmbPageType.addItem("MyService", context.GetMessage( "My Service", ""), 0);
         if ( cmbPageType.ItemCount > 0 )
         {
            A525PageType = cmbPageType.getValidValue(A525PageType);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAppVersionName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Appversionid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A535IsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A535IsActive));
         /*  Sending validation outputs */
         AssignAttri("", false, "A524AppVersionName", A524AppVersionName);
         AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
         AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
         AssignAttri("", false, "A535IsActive", A535IsActive);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z523AppVersionId", Z523AppVersionId.ToString());
         GxWebStd.gx_hidden_field( context, "Z524AppVersionName", Z524AppVersionName);
         GxWebStd.gx_hidden_field( context, "Z29LocationId", Z29LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z11OrganisationId", Z11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z535IsActive", StringUtil.BoolToStr( Z535IsActive));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Locationid( )
      {
         n29LocationId = false;
         /* Using cursor T001L25 */
         pr_default.execute(23, new Object[] {A524AppVersionName, n29LocationId, A29LocationId, A523AppVersionId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "App Version Name", "")+","+context.GetMessage( "Location Id", "")}), 1, "APPVERSIONNAME");
            AnyError = 1;
            GX_FocusControl = edtAppVersionName_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Organisationid( )
      {
         n11OrganisationId = false;
         n29LocationId = false;
         /* Using cursor T001L26 */
         pr_default.execute(24, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Organisation", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtOrganisationId_Internalname;
            }
         }
         pr_default.close(24);
         /* Using cursor T001L27 */
         pr_default.execute(25, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
               GX_FocusControl = edtLocationId_Internalname;
            }
         }
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_APPVERSIONID","""{"handler":"Valid_Appversionid","iparms":[{"av":"A523AppVersionId","fld":"APPVERSIONID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_APPVERSIONID",""","oparms":[{"av":"A524AppVersionName","fld":"APPVERSIONNAME"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z523AppVersionId"},{"av":"Z524AppVersionName"},{"av":"Z29LocationId"},{"av":"Z11OrganisationId"},{"av":"Z535IsActive"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_APPVERSIONNAME","""{"handler":"Valid_Appversionname","iparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_APPVERSIONNAME",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_LOCATIONID","""{"handler":"Valid_Locationid","iparms":[{"av":"A524AppVersionName","fld":"APPVERSIONNAME"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A523AppVersionId","fld":"APPVERSIONID"},{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_LOCATIONID",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_ORGANISATIONID","""{"handler":"Valid_Organisationid","iparms":[{"av":"A11OrganisationId","fld":"ORGANISATIONID"},{"av":"A29LocationId","fld":"LOCATIONID"},{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_ORGANISATIONID",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_PAGEID","""{"handler":"Valid_Pageid","iparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_PAGEID",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
         setEventMetadata("VALID_PAGETYPE","""{"handler":"Valid_Pagetype","iparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]""");
         setEventMetadata("VALID_PAGETYPE",""","oparms":[{"av":"A535IsActive","fld":"ISACTIVE"}]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(3);
         pr_default.close(25);
         pr_default.close(24);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z523AppVersionId = Guid.Empty;
         Z524AppVersionName = "";
         Z29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         Z516PageId = Guid.Empty;
         Z517PageName = "";
         Z525PageType = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A523AppVersionId = Guid.Empty;
         A524AppVersionName = "";
         lblTitlepage_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridtrn_appversion_pageContainer = new GXWebGrid( context);
         sMode95 = "";
         A516PageId = Guid.Empty;
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A517PageName = "";
         A518PageStructure = "";
         A536PagePublishedStructure = "";
         A525PageType = "";
         T001L8_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L8_A524AppVersionName = new string[] {""} ;
         T001L8_A535IsActive = new bool[] {false} ;
         T001L8_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L8_n29LocationId = new bool[] {false} ;
         T001L8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L8_n11OrganisationId = new bool[] {false} ;
         T001L9_A524AppVersionName = new string[] {""} ;
         T001L7_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L7_n29LocationId = new bool[] {false} ;
         T001L6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L6_n11OrganisationId = new bool[] {false} ;
         T001L10_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L10_n29LocationId = new bool[] {false} ;
         T001L11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L11_n11OrganisationId = new bool[] {false} ;
         T001L12_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L5_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L5_A524AppVersionName = new string[] {""} ;
         T001L5_A535IsActive = new bool[] {false} ;
         T001L5_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L5_n29LocationId = new bool[] {false} ;
         T001L5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L5_n11OrganisationId = new bool[] {false} ;
         sMode94 = "";
         T001L13_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L14_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L4_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L4_A524AppVersionName = new string[] {""} ;
         T001L4_A535IsActive = new bool[] {false} ;
         T001L4_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L4_n29LocationId = new bool[] {false} ;
         T001L4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L4_n11OrganisationId = new bool[] {false} ;
         T001L18_A523AppVersionId = new Guid[] {Guid.Empty} ;
         Z518PageStructure = "";
         Z536PagePublishedStructure = "";
         T001L19_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L19_A516PageId = new Guid[] {Guid.Empty} ;
         T001L19_A541IsPredefined = new bool[] {false} ;
         T001L19_A517PageName = new string[] {""} ;
         T001L19_A518PageStructure = new string[] {""} ;
         T001L19_A536PagePublishedStructure = new string[] {""} ;
         T001L19_A525PageType = new string[] {""} ;
         T001L20_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L20_A516PageId = new Guid[] {Guid.Empty} ;
         T001L3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L3_A516PageId = new Guid[] {Guid.Empty} ;
         T001L3_A541IsPredefined = new bool[] {false} ;
         T001L3_A517PageName = new string[] {""} ;
         T001L3_A518PageStructure = new string[] {""} ;
         T001L3_A536PagePublishedStructure = new string[] {""} ;
         T001L3_A525PageType = new string[] {""} ;
         T001L2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L2_A516PageId = new Guid[] {Guid.Empty} ;
         T001L2_A541IsPredefined = new bool[] {false} ;
         T001L2_A517PageName = new string[] {""} ;
         T001L2_A518PageStructure = new string[] {""} ;
         T001L2_A536PagePublishedStructure = new string[] {""} ;
         T001L2_A525PageType = new string[] {""} ;
         T001L24_A523AppVersionId = new Guid[] {Guid.Empty} ;
         T001L24_A516PageId = new Guid[] {Guid.Empty} ;
         Gridtrn_appversion_pageRow = new GXWebRow();
         subGridtrn_appversion_page_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridtrn_appversion_pageColumn = new GXWebColumn();
         ZZ523AppVersionId = Guid.Empty;
         ZZ524AppVersionName = "";
         ZZ29LocationId = Guid.Empty;
         ZZ11OrganisationId = Guid.Empty;
         T001L25_A524AppVersionName = new string[] {""} ;
         T001L26_A11OrganisationId = new Guid[] {Guid.Empty} ;
         T001L26_n11OrganisationId = new bool[] {false} ;
         T001L27_A29LocationId = new Guid[] {Guid.Empty} ;
         T001L27_n29LocationId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion__default(),
            new Object[][] {
                new Object[] {
               T001L2_A523AppVersionId, T001L2_A516PageId, T001L2_A541IsPredefined, T001L2_A517PageName, T001L2_A518PageStructure, T001L2_A536PagePublishedStructure, T001L2_A525PageType
               }
               , new Object[] {
               T001L3_A523AppVersionId, T001L3_A516PageId, T001L3_A541IsPredefined, T001L3_A517PageName, T001L3_A518PageStructure, T001L3_A536PagePublishedStructure, T001L3_A525PageType
               }
               , new Object[] {
               T001L4_A523AppVersionId, T001L4_A524AppVersionName, T001L4_A535IsActive, T001L4_A29LocationId, T001L4_n29LocationId, T001L4_A11OrganisationId, T001L4_n11OrganisationId
               }
               , new Object[] {
               T001L5_A523AppVersionId, T001L5_A524AppVersionName, T001L5_A535IsActive, T001L5_A29LocationId, T001L5_n29LocationId, T001L5_A11OrganisationId, T001L5_n11OrganisationId
               }
               , new Object[] {
               T001L6_A11OrganisationId
               }
               , new Object[] {
               T001L7_A29LocationId
               }
               , new Object[] {
               T001L8_A523AppVersionId, T001L8_A524AppVersionName, T001L8_A535IsActive, T001L8_A29LocationId, T001L8_n29LocationId, T001L8_A11OrganisationId, T001L8_n11OrganisationId
               }
               , new Object[] {
               T001L9_A524AppVersionName
               }
               , new Object[] {
               T001L10_A29LocationId
               }
               , new Object[] {
               T001L11_A11OrganisationId
               }
               , new Object[] {
               T001L12_A523AppVersionId
               }
               , new Object[] {
               T001L13_A523AppVersionId
               }
               , new Object[] {
               T001L14_A523AppVersionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001L18_A523AppVersionId
               }
               , new Object[] {
               T001L19_A523AppVersionId, T001L19_A516PageId, T001L19_A541IsPredefined, T001L19_A517PageName, T001L19_A518PageStructure, T001L19_A536PagePublishedStructure, T001L19_A525PageType
               }
               , new Object[] {
               T001L20_A523AppVersionId, T001L20_A516PageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001L24_A523AppVersionId, T001L24_A516PageId
               }
               , new Object[] {
               T001L25_A524AppVersionName
               }
               , new Object[] {
               T001L26_A11OrganisationId
               }
               , new Object[] {
               T001L27_A29LocationId
               }
            }
         );
         Z516PageId = Guid.NewGuid( );
         A516PageId = Guid.NewGuid( );
         Z523AppVersionId = Guid.NewGuid( );
         A523AppVersionId = Guid.NewGuid( );
         Z541IsPredefined = false;
         A541IsPredefined = false;
         i541IsPredefined = false;
      }

      private short nRcdDeleted_95 ;
      private short nRcdExists_95 ;
      private short nIsMod_95 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount95 ;
      private short RcdFound95 ;
      private short nBlankRcdUsr95 ;
      private short RcdFound94 ;
      private short nIsDirty_95 ;
      private short subGridtrn_appversion_page_Backcolorstyle ;
      private short subGridtrn_appversion_page_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridtrn_appversion_page_Allowselection ;
      private short subGridtrn_appversion_page_Allowhovering ;
      private short subGridtrn_appversion_page_Allowcollapsing ;
      private short subGridtrn_appversion_page_Collapsed ;
      private int nRC_GXsfl_63 ;
      private int nGXsfl_63_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAppVersionId_Enabled ;
      private int edtAppVersionName_Enabled ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtPageId_Enabled ;
      private int edtPageName_Enabled ;
      private int edtPageStructure_Enabled ;
      private int edtPagePublishedStructure_Enabled ;
      private int fRowAdded ;
      private int subGridtrn_appversion_page_Backcolor ;
      private int subGridtrn_appversion_page_Allbackcolor ;
      private int defedtPageId_Enabled ;
      private int idxLst ;
      private int subGridtrn_appversion_page_Selectedindex ;
      private int subGridtrn_appversion_page_Selectioncolor ;
      private int subGridtrn_appversion_page_Hoveringcolor ;
      private long GRIDTRN_APPVERSION_PAGE_nFirstRecordOnPage ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAppVersionId_Internalname ;
      private string sGXsfl_63_idx="0001" ;
      private string Gx_mode ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtAppVersionId_Jsonclick ;
      private string edtAppVersionName_Internalname ;
      private string edtAppVersionName_Jsonclick ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string chkIsActive_Internalname ;
      private string divPagetable_Internalname ;
      private string lblTitlepage_Internalname ;
      private string lblTitlepage_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode95 ;
      private string edtPageId_Internalname ;
      private string edtPageName_Internalname ;
      private string edtPageStructure_Internalname ;
      private string edtPagePublishedStructure_Internalname ;
      private string chkIsPredefined_Internalname ;
      private string cmbPageType_Internalname ;
      private string sStyleString ;
      private string subGridtrn_appversion_page_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode94 ;
      private string sGXsfl_63_fel_idx="0001" ;
      private string subGridtrn_appversion_page_Class ;
      private string subGridtrn_appversion_page_Linesclass ;
      private string ROClassString ;
      private string edtPageId_Jsonclick ;
      private string edtPageName_Jsonclick ;
      private string edtPageStructure_Jsonclick ;
      private string edtPagePublishedStructure_Jsonclick ;
      private string cmbPageType_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridtrn_appversion_page_Header ;
      private bool Z535IsActive ;
      private bool Z541IsPredefined ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private bool wbErr ;
      private bool A535IsActive ;
      private bool bGXsfl_63_Refreshing=false ;
      private bool A541IsPredefined ;
      private bool i541IsPredefined ;
      private bool ZZ535IsActive ;
      private string A518PageStructure ;
      private string A536PagePublishedStructure ;
      private string Z518PageStructure ;
      private string Z536PagePublishedStructure ;
      private string Z524AppVersionName ;
      private string Z517PageName ;
      private string Z525PageType ;
      private string A524AppVersionName ;
      private string A517PageName ;
      private string A525PageType ;
      private string ZZ524AppVersionName ;
      private Guid Z523AppVersionId ;
      private Guid Z29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid Z516PageId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private Guid ZZ523AppVersionId ;
      private Guid ZZ29LocationId ;
      private Guid ZZ11OrganisationId ;
      private GXWebGrid Gridtrn_appversion_pageContainer ;
      private GXWebRow Gridtrn_appversion_pageRow ;
      private GXWebColumn Gridtrn_appversion_pageColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkIsActive ;
      private GXCheckbox chkIsPredefined ;
      private GXCombobox cmbPageType ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001L8_A523AppVersionId ;
      private string[] T001L8_A524AppVersionName ;
      private bool[] T001L8_A535IsActive ;
      private Guid[] T001L8_A29LocationId ;
      private bool[] T001L8_n29LocationId ;
      private Guid[] T001L8_A11OrganisationId ;
      private bool[] T001L8_n11OrganisationId ;
      private string[] T001L9_A524AppVersionName ;
      private Guid[] T001L7_A29LocationId ;
      private bool[] T001L7_n29LocationId ;
      private Guid[] T001L6_A11OrganisationId ;
      private bool[] T001L6_n11OrganisationId ;
      private Guid[] T001L10_A29LocationId ;
      private bool[] T001L10_n29LocationId ;
      private Guid[] T001L11_A11OrganisationId ;
      private bool[] T001L11_n11OrganisationId ;
      private Guid[] T001L12_A523AppVersionId ;
      private Guid[] T001L5_A523AppVersionId ;
      private string[] T001L5_A524AppVersionName ;
      private bool[] T001L5_A535IsActive ;
      private Guid[] T001L5_A29LocationId ;
      private bool[] T001L5_n29LocationId ;
      private Guid[] T001L5_A11OrganisationId ;
      private bool[] T001L5_n11OrganisationId ;
      private Guid[] T001L13_A523AppVersionId ;
      private Guid[] T001L14_A523AppVersionId ;
      private Guid[] T001L4_A523AppVersionId ;
      private string[] T001L4_A524AppVersionName ;
      private bool[] T001L4_A535IsActive ;
      private Guid[] T001L4_A29LocationId ;
      private bool[] T001L4_n29LocationId ;
      private Guid[] T001L4_A11OrganisationId ;
      private bool[] T001L4_n11OrganisationId ;
      private Guid[] T001L18_A523AppVersionId ;
      private Guid[] T001L19_A523AppVersionId ;
      private Guid[] T001L19_A516PageId ;
      private bool[] T001L19_A541IsPredefined ;
      private string[] T001L19_A517PageName ;
      private string[] T001L19_A518PageStructure ;
      private string[] T001L19_A536PagePublishedStructure ;
      private string[] T001L19_A525PageType ;
      private Guid[] T001L20_A523AppVersionId ;
      private Guid[] T001L20_A516PageId ;
      private Guid[] T001L3_A523AppVersionId ;
      private Guid[] T001L3_A516PageId ;
      private bool[] T001L3_A541IsPredefined ;
      private string[] T001L3_A517PageName ;
      private string[] T001L3_A518PageStructure ;
      private string[] T001L3_A536PagePublishedStructure ;
      private string[] T001L3_A525PageType ;
      private Guid[] T001L2_A523AppVersionId ;
      private Guid[] T001L2_A516PageId ;
      private bool[] T001L2_A541IsPredefined ;
      private string[] T001L2_A517PageName ;
      private string[] T001L2_A518PageStructure ;
      private string[] T001L2_A536PagePublishedStructure ;
      private string[] T001L2_A525PageType ;
      private Guid[] T001L24_A523AppVersionId ;
      private Guid[] T001L24_A516PageId ;
      private string[] T001L25_A524AppVersionName ;
      private Guid[] T001L26_A11OrganisationId ;
      private bool[] T001L26_n11OrganisationId ;
      private Guid[] T001L27_A29LocationId ;
      private bool[] T001L27_n29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_appversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_appversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_appversion__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new UpdateCursor(def[13])
      ,new UpdateCursor(def[14])
      ,new UpdateCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new UpdateCursor(def[19])
      ,new UpdateCursor(def[20])
      ,new UpdateCursor(def[21])
      ,new ForEachCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT001L2;
       prmT001L2 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L3;
       prmT001L3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L4;
       prmT001L4 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L5;
       prmT001L5 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L6;
       prmT001L6 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001L7;
       prmT001L7 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001L8;
       prmT001L8 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L9;
       prmT001L9 = new Object[] {
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L10;
       prmT001L10 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001L11;
       prmT001L11 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001L12;
       prmT001L12 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L13;
       prmT001L13 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L14;
       prmT001L14 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L15;
       prmT001L15 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001L16;
       prmT001L16 = new Object[] {
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L17;
       prmT001L17 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L18;
       prmT001L18 = new Object[] {
       };
       Object[] prmT001L19;
       prmT001L19 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L20;
       prmT001L20 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L21;
       prmT001L21 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IsPredefined",GXType.Boolean,4,0) ,
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PagePublishedStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageType",GXType.VarChar,40,0)
       };
       Object[] prmT001L22;
       prmT001L22 = new Object[] {
       new ParDef("IsPredefined",GXType.Boolean,4,0) ,
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PagePublishedStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageType",GXType.VarChar,40,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L23;
       prmT001L23 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L24;
       prmT001L24 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L25;
       prmT001L25 = new Object[] {
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001L26;
       prmT001L26 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmT001L27;
       prmT001L27 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("T001L2", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageType FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId  FOR UPDATE OF Trn_AppVersionPage NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001L2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L3", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageType FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L4", "SELECT AppVersionId, AppVersionName, IsActive, LocationId, OrganisationId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId  FOR UPDATE OF Trn_AppVersion NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001L4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L5", "SELECT AppVersionId, AppVersionName, IsActive, LocationId, OrganisationId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L6", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L7", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L8", "SELECT TM1.AppVersionId, TM1.AppVersionName, TM1.IsActive, TM1.LocationId, TM1.OrganisationId FROM Trn_AppVersion TM1 WHERE TM1.AppVersionId = :AppVersionId ORDER BY TM1.AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L8,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L9", "SELECT AppVersionName FROM Trn_AppVersion WHERE (AppVersionName = :AppVersionName AND LocationId = :LocationId) AND (Not ( AppVersionId = :AppVersionId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L10", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L11", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L12", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L13", "SELECT AppVersionId FROM Trn_AppVersion WHERE ( AppVersionId > :AppVersionId) ORDER BY AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001L14", "SELECT AppVersionId FROM Trn_AppVersion WHERE ( AppVersionId < :AppVersionId) ORDER BY AppVersionId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001L15", "SAVEPOINT gxupdate;INSERT INTO Trn_AppVersion(AppVersionId, AppVersionName, IsActive, LocationId, OrganisationId) VALUES(:AppVersionId, :AppVersionName, :IsActive, :LocationId, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L15)
          ,new CursorDef("T001L16", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET AppVersionName=:AppVersionName, IsActive=:IsActive, LocationId=:LocationId, OrganisationId=:OrganisationId  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L16)
          ,new CursorDef("T001L17", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersion  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L17)
          ,new CursorDef("T001L18", "SELECT AppVersionId FROM Trn_AppVersion ORDER BY AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L18,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L19", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageType FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :PageId ORDER BY AppVersionId, PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L19,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L20", "SELECT AppVersionId, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L20,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L21", "SAVEPOINT gxupdate;INSERT INTO Trn_AppVersionPage(AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageType) VALUES(:AppVersionId, :PageId, :IsPredefined, :PageName, :PageStructure, :PagePublishedStructure, :PageType);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001L21)
          ,new CursorDef("T001L22", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET IsPredefined=:IsPredefined, PageName=:PageName, PageStructure=:PageStructure, PagePublishedStructure=:PagePublishedStructure, PageType=:PageType  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L22)
          ,new CursorDef("T001L23", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersionPage  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L23)
          ,new CursorDef("T001L24", "SELECT AppVersionId, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId, PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L24,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L25", "SELECT AppVersionName FROM Trn_AppVersion WHERE (AppVersionName = :AppVersionName AND LocationId = :LocationId) AND (Not ( AppVersionId = :AppVersionId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L25,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L26", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L26,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001L27", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L27,1, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((Guid[]) buf[5])[0] = rslt.getGuid(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((Guid[]) buf[5])[0] = rslt.getGuid(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((Guid[]) buf[5])[0] = rslt.getGuid(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 22 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 23 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 24 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 25 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
