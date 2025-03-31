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
   public class wp_applicationdesignv1 : GXDataArea
   {
      public wp_applicationdesignv1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_applicationdesignv1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_Trn_PageId )
      {
         this.AV41Trn_PageId = aP0_Trn_PageId;
         ExecuteImpl();
         aP0_Trn_PageId=this.AV41Trn_PageId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Trn_PageId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
            return "wp_applicationdesign_Execute" ;
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
         PAAJ2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTAJ2( ) ;
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
         context.AddJavascriptSource("UserControls/UC_AppToolBoxRender.js", "", false, true);
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
         GXEncryptionTmp = "wp_applicationdesignv1.aspx"+UrlEncode(AV41Trn_PageId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_applicationdesignv1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_PAGES", AV34SDT_Pages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_PAGES", AV34SDT_Pages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_PRODUCTSERVICECOLLECTION", AV37SDT_ProductServiceCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_PRODUCTSERVICECOLLECTION", AV37SDT_ProductServiceCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_DYNAMICFORMSCOLLECTION", AV29SDT_DynamicFormsCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_DYNAMICFORMSCOLLECTION", AV29SDT_DynamicFormsCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_TEMPLATECOLLECTION", AV11BC_Trn_TemplateCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_TEMPLATECOLLECTION", AV11BC_Trn_TemplateCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_THEMECOLLECTION", AV13BC_Trn_ThemeCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_THEMECOLLECTION", AV13BC_Trn_ThemeCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_MEDIACOLLECTION", AV7BC_Trn_MediaCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_MEDIACOLLECTION", AV7BC_Trn_MediaCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_LOCATION", AV5BC_Trn_Location);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_LOCATION", AV5BC_Trn_Location);
         }
         GxWebStd.gx_hidden_field( context, "vTRN_PAGEID", AV41Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Current_language", StringUtil.RTrim( Apptoolbox1_Current_language));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Locationid", StringUtil.RTrim( Apptoolbox1_Locationid));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Organisationid", StringUtil.RTrim( Apptoolbox1_Organisationid));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Locationlogo", StringUtil.RTrim( Apptoolbox1_Locationlogo));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Locationprofileimage", StringUtil.RTrim( Apptoolbox1_Locationprofileimage));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Current_theme", StringUtil.RTrim( Apptoolbox1_Current_theme));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Organisationlogo", StringUtil.RTrim( Apptoolbox1_Organisationlogo));
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
            WEAJ2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTAJ2( ) ;
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
         GXEncryptionTmp = "wp_applicationdesignv1.aspx"+UrlEncode(AV41Trn_PageId.ToString());
         return formatLink("wp_applicationdesignv1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_ApplicationDesignV1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "App Builder V1", "") ;
      }

      protected void WBAJ0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucApptoolbox1.SetProperty("SDT_Pages", AV34SDT_Pages);
            ucApptoolbox1.SetProperty("LocationLogo", Apptoolbox1_Locationlogo);
            ucApptoolbox1.SetProperty("LocationProfileImage", Apptoolbox1_Locationprofileimage);
            ucApptoolbox1.SetProperty("SDT_ProductServiceCollection", AV37SDT_ProductServiceCollection);
            ucApptoolbox1.SetProperty("SDT_DynamicFormsCollection", AV29SDT_DynamicFormsCollection);
            ucApptoolbox1.SetProperty("BC_Trn_TemplateCollection", AV11BC_Trn_TemplateCollection);
            ucApptoolbox1.SetProperty("BC_Trn_ThemeCollection", AV13BC_Trn_ThemeCollection);
            ucApptoolbox1.SetProperty("BC_Trn_MediaCollection", AV7BC_Trn_MediaCollection);
            ucApptoolbox1.SetProperty("BC_Trn_Location", AV5BC_Trn_Location);
            ucApptoolbox1.SetProperty("OrganisationLogo", Apptoolbox1_Organisationlogo);
            ucApptoolbox1.Render(context, "uc_apptoolbox", Apptoolbox1_Internalname, "APPTOOLBOX1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTAJ2( )
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
         Form.Meta.addItem("description", context.GetMessage( "App Builder V1", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPAJ0( ) ;
      }

      protected void WSAJ2( )
      {
         STARTAJ2( ) ;
         EVTAJ2( ) ;
      }

      protected void EVTAJ2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "APPTOOLBOX1.ADDSERVICEBUTTONEVENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Apptoolbox1.Addservicebuttonevent */
                              E11AJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E12AJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13AJ2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEAJ2( )
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

      protected void PAAJ2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_applicationdesignv1.aspx")), "wp_applicationdesignv1.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_applicationdesignv1.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "Trn_PageId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV41Trn_PageId = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV41Trn_PageId", AV41Trn_PageId.ToString());
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFAJ2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFAJ2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13AJ2 ();
            WBAJ0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesAJ2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAJ0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12AJ2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_PAGES"), AV34SDT_Pages);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_PRODUCTSERVICECOLLECTION"), AV37SDT_ProductServiceCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_DYNAMICFORMSCOLLECTION"), AV29SDT_DynamicFormsCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_TEMPLATECOLLECTION"), AV11BC_Trn_TemplateCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_THEMECOLLECTION"), AV13BC_Trn_ThemeCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_MEDIACOLLECTION"), AV7BC_Trn_MediaCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_LOCATION"), AV5BC_Trn_Location);
            /* Read saved values. */
            Apptoolbox1_Current_language = cgiGet( "APPTOOLBOX1_Current_language");
            Apptoolbox1_Locationid = cgiGet( "APPTOOLBOX1_Locationid");
            Apptoolbox1_Organisationid = cgiGet( "APPTOOLBOX1_Organisationid");
            Apptoolbox1_Locationlogo = cgiGet( "APPTOOLBOX1_Locationlogo");
            Apptoolbox1_Locationprofileimage = cgiGet( "APPTOOLBOX1_Locationprofileimage");
            Apptoolbox1_Current_theme = cgiGet( "APPTOOLBOX1_Current_theme");
            Apptoolbox1_Organisationlogo = cgiGet( "APPTOOLBOX1_Organisationlogo");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12AJ2 ();
         if (returnInSub) return;
      }

      protected void E12AJ2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_char1 = AV42UserName;
         new prc_getloggedinusername(context ).execute( out  GXt_char1) ;
         AV42UserName = GXt_char1;
         GXt_guid2 = AV22LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid2) ;
         AV22LocationId = GXt_guid2;
         AssignAttri("", false, "AV22LocationId", AV22LocationId.ToString());
         GXt_guid2 = AV25OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid2) ;
         AV25OrganisationId = GXt_guid2;
         AssignAttri("", false, "AV25OrganisationId", AV25OrganisationId.ToString());
         new prc_initlocationpages(context ).execute(  AV22LocationId,  AV25OrganisationId) ;
         Apptoolbox1_Locationid = AV22LocationId.ToString();
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "LocationId", Apptoolbox1_Locationid);
         Apptoolbox1_Organisationid = AV25OrganisationId.ToString();
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "OrganisationId", Apptoolbox1_Organisationid);
         AV5BC_Trn_Location.Load(AV22LocationId, AV25OrganisationId);
         Apptoolbox1_Locationlogo = AV5BC_Trn_Location.gxTpr_Toolboxdefaultlogo;
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "LocationLogo", Apptoolbox1_Locationlogo);
         Apptoolbox1_Locationprofileimage = AV5BC_Trn_Location.gxTpr_Toolboxdefaultprofileimage;
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "LocationProfileImage", Apptoolbox1_Locationprofileimage);
         /* Using cursor H00AJ2 */
         pr_default.execute(0, new Object[] {AV25OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = H00AJ2_A11OrganisationId[0];
            A40000OrganisationLogo_GXI = H00AJ2_A40000OrganisationLogo_GXI[0];
            Apptoolbox1_Organisationlogo = A40000OrganisationLogo_GXI;
            ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "OrganisationLogo", Apptoolbox1_Organisationlogo);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor H00AJ3 */
         pr_default.execute(1, new Object[] {AV22LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = H00AJ3_A29LocationId[0];
            A273Trn_ThemeId = H00AJ3_A273Trn_ThemeId[0];
            n273Trn_ThemeId = H00AJ3_n273Trn_ThemeId[0];
            Apptoolbox1_Current_theme = A273Trn_ThemeId.ToString();
            ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "Current_Theme", Apptoolbox1_Current_theme);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor H00AJ4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A299Trn_TemplateId = H00AJ4_A299Trn_TemplateId[0];
            AV10BC_Trn_Template = new SdtTrn_Template(context);
            AV10BC_Trn_Template.Load(A299Trn_TemplateId);
            AV11BC_Trn_TemplateCollection.Add(AV10BC_Trn_Template, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV52Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         AV53Udparg2 = new prc_getuserorganisationid(context).executeUdp( );
         /* Using cursor H00AJ5 */
         pr_default.execute(3, new Object[] {AV52Udparg1, AV53Udparg2});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A11OrganisationId = H00AJ5_A11OrganisationId[0];
            A29LocationId = H00AJ5_A29LocationId[0];
            A40001ProductServiceImage_GXI = H00AJ5_A40001ProductServiceImage_GXI[0];
            A58ProductServiceId = H00AJ5_A58ProductServiceId[0];
            A59ProductServiceName = H00AJ5_A59ProductServiceName[0];
            A266ProductServiceTileName = H00AJ5_A266ProductServiceTileName[0];
            A61ProductServiceImage = H00AJ5_A61ProductServiceImage[0];
            AV36SDT_ProductService = new SdtSDT_ProductService(context);
            AV36SDT_ProductService.gxTpr_Productserviceid = A58ProductServiceId;
            AV36SDT_ProductService.gxTpr_Productservicename = A59ProductServiceName;
            AV36SDT_ProductService.gxTpr_Productserviceimage = A61ProductServiceImage;
            AV36SDT_ProductService.gxTpr_Productserviceimage_gxi = A40001ProductServiceImage_GXI;
            AV36SDT_ProductService.gxTpr_Productservicetilename = StringUtil.Trim( A266ProductServiceTileName);
            AV37SDT_ProductServiceCollection.Add(AV36SDT_ProductService, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV52Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         AV53Udparg2 = new prc_getuserorganisationid(context).executeUdp( );
         /* Using cursor H00AJ6 */
         pr_default.execute(4, new Object[] {AV52Udparg1, AV53Udparg2});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A207WWPFormVersionNumber = H00AJ6_A207WWPFormVersionNumber[0];
            A11OrganisationId = H00AJ6_A11OrganisationId[0];
            A29LocationId = H00AJ6_A29LocationId[0];
            A206WWPFormId = H00AJ6_A206WWPFormId[0];
            A208WWPFormReferenceName = H00AJ6_A208WWPFormReferenceName[0];
            A208WWPFormReferenceName = H00AJ6_A208WWPFormReferenceName[0];
            AV28SDT_DynamicForms = new SdtSDT_DynamicForms(context);
            AV28SDT_DynamicForms.gxTpr_Formid = A206WWPFormId;
            AV28SDT_DynamicForms.gxTpr_Referencename = A208WWPFormReferenceName;
            GXt_char1 = "";
            GXt_char3 = context.GetMessage( "Form", "");
            new prc_getcalltoactionformurl(context ).execute( ref  GXt_char3, ref  A208WWPFormReferenceName, out  GXt_char1) ;
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            AV28SDT_DynamicForms.gxTpr_Formurl = GXt_char1;
            AV29SDT_DynamicFormsCollection.Add(AV28SDT_DynamicForms, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV52Udparg1 = new prc_getuserlocationid(context).executeUdp( );
         /* Using cursor H00AJ7 */
         pr_default.execute(5, new Object[] {AV52Udparg1});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A29LocationId = H00AJ7_A29LocationId[0];
            A413MediaId = H00AJ7_A413MediaId[0];
            A414MediaName = H00AJ7_A414MediaName[0];
            AV6BC_Trn_Media = new SdtTrn_Media(context);
            AV6BC_Trn_Media.Load(A413MediaId);
            AV46MediaPath = context.GetMessage( "media/", "") + A414MediaName;
            AV45File = new GxFile(context.GetPhysicalPath());
            AV45File.Source = context.GetMessage( "media/", "")+A414MediaName;
            if ( AV45File.Exists() )
            {
               AV7BC_Trn_MediaCollection.Add(AV6BC_Trn_Media, 0);
            }
            else
            {
               AV6BC_Trn_Media.Delete();
               context.CommitDataStores("wp_applicationdesignv1",pr_default);
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
         GXt_objcol_SdtTrn_Theme4 = AV13BC_Trn_ThemeCollection;
         new prc_getorganisationtheme(context ).execute(  AV25OrganisationId,  AV22LocationId, out  GXt_objcol_SdtTrn_Theme4) ;
         AV13BC_Trn_ThemeCollection = GXt_objcol_SdtTrn_Theme4;
         /* Using cursor H00AJ8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A392Trn_PageId = H00AJ8_A392Trn_PageId[0];
            A397Trn_PageName = H00AJ8_A397Trn_PageName[0];
            A424PageChildren = H00AJ8_A424PageChildren[0];
            n424PageChildren = H00AJ8_n424PageChildren[0];
            AV35SDT_PageStructure = new SdtSDT_PageStructure(context);
            AV35SDT_PageStructure.gxTpr_Id = A392Trn_PageId;
            AV35SDT_PageStructure.gxTpr_Name = A397Trn_PageName;
            AV35SDT_PageStructure.gxTpr_Children.FromJSonString(A424PageChildren, null);
            AV34SDT_Pages.Add(AV35SDT_PageStructure, 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         AV19Current_Language = context.GetLanguage( );
         Apptoolbox1_Current_language = AV19Current_Language;
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "Current_Language", Apptoolbox1_Current_language);
      }

      protected void E11AJ2( )
      {
         /* Apptoolbox1_Addservicebuttonevent Routine */
         returnInSub = false;
         AV44NewProductServiceId = Guid.NewGuid( );
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_productservice.aspx"+UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.BoolToStr(false)) + "," + UrlEncode(StringUtil.BoolToStr(true)) + "," + UrlEncode(AV44NewProductServiceId.ToString());
         context.PopUp(formatLink("wp_productservice.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {"","AV44NewProductServiceId"});
         this.executeUsercontrolMethod("", false, "APPTOOLBOX1Container", "SetProductToTile", "", new Object[] {(Guid)AV44NewProductServiceId});
      }

      protected void nextLoad( )
      {
      }

      protected void E13AJ2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV41Trn_PageId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV41Trn_PageId", AV41Trn_PageId.ToString());
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
         PAAJ2( ) ;
         WSAJ2( ) ;
         WEAJ2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20253317412252", true, true);
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
         context.AddJavascriptSource("wp_applicationdesignv1.js", "?20253317412252", false, true);
         context.AddJavascriptSource("UserControls/UC_AppToolBoxRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTablecontent_Internalname = "TABLECONTENT";
         Apptoolbox1_Internalname = "APPTOOLBOX1";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Apptoolbox1_Organisationlogo = "&OrganisationLogo";
         Apptoolbox1_Current_theme = "";
         Apptoolbox1_Locationprofileimage = "&LocationProfileImage";
         Apptoolbox1_Locationlogo = "&LocationLogo";
         Apptoolbox1_Organisationid = "";
         Apptoolbox1_Locationid = "";
         Apptoolbox1_Current_language = "english";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "App Builder V1", "");
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("APPTOOLBOX1.ADDSERVICEBUTTONEVENT","""{"handler":"E11AJ2","iparms":[]}""");
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
         wcpOAV41Trn_PageId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV34SDT_Pages = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version20");
         AV37SDT_ProductServiceCollection = new GXBaseCollection<SdtSDT_ProductService>( context, "SDT_ProductService", "Comforta_version20");
         AV29SDT_DynamicFormsCollection = new GXBaseCollection<SdtSDT_DynamicForms>( context, "SDT_DynamicForms", "Comforta_version20");
         AV11BC_Trn_TemplateCollection = new GXBCCollection<SdtTrn_Template>( context, "Trn_Template", "Comforta_version20");
         AV13BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version20");
         AV7BC_Trn_MediaCollection = new GXBCCollection<SdtTrn_Media>( context, "Trn_Media", "Comforta_version20");
         AV5BC_Trn_Location = new SdtTrn_Location(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucApptoolbox1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV42UserName = "";
         AV22LocationId = Guid.Empty;
         AV25OrganisationId = Guid.Empty;
         GXt_guid2 = Guid.Empty;
         H00AJ2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00AJ2_A40000OrganisationLogo_GXI = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A40000OrganisationLogo_GXI = "";
         H00AJ3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00AJ3_A29LocationId = new Guid[] {Guid.Empty} ;
         H00AJ3_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         H00AJ3_n273Trn_ThemeId = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         H00AJ4_A299Trn_TemplateId = new Guid[] {Guid.Empty} ;
         A299Trn_TemplateId = Guid.Empty;
         AV10BC_Trn_Template = new SdtTrn_Template(context);
         AV52Udparg1 = Guid.Empty;
         AV53Udparg2 = Guid.Empty;
         H00AJ5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00AJ5_A29LocationId = new Guid[] {Guid.Empty} ;
         H00AJ5_A40001ProductServiceImage_GXI = new string[] {""} ;
         H00AJ5_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H00AJ5_A59ProductServiceName = new string[] {""} ;
         H00AJ5_A266ProductServiceTileName = new string[] {""} ;
         H00AJ5_A61ProductServiceImage = new string[] {""} ;
         A40001ProductServiceImage_GXI = "";
         A58ProductServiceId = Guid.Empty;
         A59ProductServiceName = "";
         A266ProductServiceTileName = "";
         A61ProductServiceImage = "";
         AV36SDT_ProductService = new SdtSDT_ProductService(context);
         H00AJ6_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         H00AJ6_A207WWPFormVersionNumber = new short[1] ;
         H00AJ6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00AJ6_A29LocationId = new Guid[] {Guid.Empty} ;
         H00AJ6_A206WWPFormId = new short[1] ;
         H00AJ6_A208WWPFormReferenceName = new string[] {""} ;
         A208WWPFormReferenceName = "";
         AV28SDT_DynamicForms = new SdtSDT_DynamicForms(context);
         GXt_char1 = "";
         GXt_char3 = "";
         H00AJ7_A29LocationId = new Guid[] {Guid.Empty} ;
         H00AJ7_A413MediaId = new Guid[] {Guid.Empty} ;
         H00AJ7_A414MediaName = new string[] {""} ;
         A413MediaId = Guid.Empty;
         A414MediaName = "";
         AV6BC_Trn_Media = new SdtTrn_Media(context);
         AV46MediaPath = "";
         AV45File = new GxFile(context.GetPhysicalPath());
         GXt_objcol_SdtTrn_Theme4 = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version20");
         H00AJ8_A29LocationId = new Guid[] {Guid.Empty} ;
         H00AJ8_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         H00AJ8_A397Trn_PageName = new string[] {""} ;
         H00AJ8_A424PageChildren = new string[] {""} ;
         H00AJ8_n424PageChildren = new bool[] {false} ;
         A392Trn_PageId = Guid.Empty;
         A397Trn_PageName = "";
         A424PageChildren = "";
         AV35SDT_PageStructure = new SdtSDT_PageStructure(context);
         AV19Current_Language = "";
         AV44NewProductServiceId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_applicationdesignv1__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_applicationdesignv1__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_applicationdesignv1__default(),
            new Object[][] {
                new Object[] {
               H00AJ2_A11OrganisationId, H00AJ2_A40000OrganisationLogo_GXI
               }
               , new Object[] {
               H00AJ3_A11OrganisationId, H00AJ3_A29LocationId, H00AJ3_A273Trn_ThemeId, H00AJ3_n273Trn_ThemeId
               }
               , new Object[] {
               H00AJ4_A299Trn_TemplateId
               }
               , new Object[] {
               H00AJ5_A11OrganisationId, H00AJ5_A29LocationId, H00AJ5_A40001ProductServiceImage_GXI, H00AJ5_A58ProductServiceId, H00AJ5_A59ProductServiceName, H00AJ5_A266ProductServiceTileName, H00AJ5_A61ProductServiceImage
               }
               , new Object[] {
               H00AJ6_A366LocationDynamicFormId, H00AJ6_A207WWPFormVersionNumber, H00AJ6_A11OrganisationId, H00AJ6_A29LocationId, H00AJ6_A206WWPFormId, H00AJ6_A208WWPFormReferenceName
               }
               , new Object[] {
               H00AJ7_A29LocationId, H00AJ7_A413MediaId, H00AJ7_A414MediaName
               }
               , new Object[] {
               H00AJ8_A29LocationId, H00AJ8_A392Trn_PageId, H00AJ8_A397Trn_PageName, H00AJ8_A424PageChildren, H00AJ8_n424PageChildren
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private short nGXWrapped ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Apptoolbox1_Current_language ;
      private string Apptoolbox1_Locationid ;
      private string Apptoolbox1_Organisationid ;
      private string Apptoolbox1_Locationlogo ;
      private string Apptoolbox1_Locationprofileimage ;
      private string Apptoolbox1_Current_theme ;
      private string Apptoolbox1_Organisationlogo ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Apptoolbox1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string A266ProductServiceTileName ;
      private string GXt_char1 ;
      private string GXt_char3 ;
      private string AV19Current_Language ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n273Trn_ThemeId ;
      private bool n424PageChildren ;
      private string A424PageChildren ;
      private string AV42UserName ;
      private string A40000OrganisationLogo_GXI ;
      private string A40001ProductServiceImage_GXI ;
      private string A59ProductServiceName ;
      private string A208WWPFormReferenceName ;
      private string A414MediaName ;
      private string AV46MediaPath ;
      private string A397Trn_PageName ;
      private string A61ProductServiceImage ;
      private Guid AV41Trn_PageId ;
      private Guid wcpOAV41Trn_PageId ;
      private Guid AV22LocationId ;
      private Guid AV25OrganisationId ;
      private Guid GXt_guid2 ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A273Trn_ThemeId ;
      private Guid A299Trn_TemplateId ;
      private Guid AV52Udparg1 ;
      private Guid AV53Udparg2 ;
      private Guid A58ProductServiceId ;
      private Guid A413MediaId ;
      private Guid A392Trn_PageId ;
      private Guid AV44NewProductServiceId ;
      private GXUserControl ucApptoolbox1 ;
      private GxFile AV45File ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_Trn_PageId ;
      private GXBaseCollection<SdtSDT_PageStructure> AV34SDT_Pages ;
      private GXBaseCollection<SdtSDT_ProductService> AV37SDT_ProductServiceCollection ;
      private GXBaseCollection<SdtSDT_DynamicForms> AV29SDT_DynamicFormsCollection ;
      private GXBCCollection<SdtTrn_Template> AV11BC_Trn_TemplateCollection ;
      private GXBCCollection<SdtTrn_Theme> AV13BC_Trn_ThemeCollection ;
      private GXBCCollection<SdtTrn_Media> AV7BC_Trn_MediaCollection ;
      private SdtTrn_Location AV5BC_Trn_Location ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00AJ2_A11OrganisationId ;
      private string[] H00AJ2_A40000OrganisationLogo_GXI ;
      private Guid[] H00AJ3_A11OrganisationId ;
      private Guid[] H00AJ3_A29LocationId ;
      private Guid[] H00AJ3_A273Trn_ThemeId ;
      private bool[] H00AJ3_n273Trn_ThemeId ;
      private Guid[] H00AJ4_A299Trn_TemplateId ;
      private SdtTrn_Template AV10BC_Trn_Template ;
      private Guid[] H00AJ5_A11OrganisationId ;
      private Guid[] H00AJ5_A29LocationId ;
      private string[] H00AJ5_A40001ProductServiceImage_GXI ;
      private Guid[] H00AJ5_A58ProductServiceId ;
      private string[] H00AJ5_A59ProductServiceName ;
      private string[] H00AJ5_A266ProductServiceTileName ;
      private string[] H00AJ5_A61ProductServiceImage ;
      private SdtSDT_ProductService AV36SDT_ProductService ;
      private Guid[] H00AJ6_A366LocationDynamicFormId ;
      private short[] H00AJ6_A207WWPFormVersionNumber ;
      private Guid[] H00AJ6_A11OrganisationId ;
      private Guid[] H00AJ6_A29LocationId ;
      private short[] H00AJ6_A206WWPFormId ;
      private string[] H00AJ6_A208WWPFormReferenceName ;
      private SdtSDT_DynamicForms AV28SDT_DynamicForms ;
      private Guid[] H00AJ7_A29LocationId ;
      private Guid[] H00AJ7_A413MediaId ;
      private string[] H00AJ7_A414MediaName ;
      private SdtTrn_Media AV6BC_Trn_Media ;
      private GXBCCollection<SdtTrn_Theme> GXt_objcol_SdtTrn_Theme4 ;
      private Guid[] H00AJ8_A29LocationId ;
      private Guid[] H00AJ8_A392Trn_PageId ;
      private string[] H00AJ8_A397Trn_PageName ;
      private string[] H00AJ8_A424PageChildren ;
      private bool[] H00AJ8_n424PageChildren ;
      private SdtSDT_PageStructure AV35SDT_PageStructure ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_applicationdesignv1__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_applicationdesignv1__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_applicationdesignv1__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH00AJ2;
       prmH00AJ2 = new Object[] {
       new ParDef("AV25OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00AJ3;
       prmH00AJ3 = new Object[] {
       new ParDef("AV22LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00AJ4;
       prmH00AJ4 = new Object[] {
       };
       Object[] prmH00AJ5;
       prmH00AJ5 = new Object[] {
       new ParDef("AV52Udparg1",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV53Udparg2",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00AJ6;
       prmH00AJ6 = new Object[] {
       new ParDef("AV52Udparg1",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV53Udparg2",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00AJ7;
       prmH00AJ7 = new Object[] {
       new ParDef("AV52Udparg1",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH00AJ8;
       prmH00AJ8 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("H00AJ2", "SELECT OrganisationId, OrganisationLogo_GXI FROM Trn_Organisation WHERE OrganisationId = :AV25OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AJ2,1, GxCacheFrequency.OFF ,false,true )
          ,new CursorDef("H00AJ3", "SELECT OrganisationId, LocationId, Trn_ThemeId FROM Trn_Location WHERE LocationId = :AV22LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AJ3,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("H00AJ4", "SELECT Trn_TemplateId FROM Trn_Template ORDER BY Trn_TemplateId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AJ4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00AJ5", "SELECT OrganisationId, LocationId, ProductServiceImage_GXI, ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceImage FROM Trn_ProductService WHERE LocationId = :AV52Udparg1 and OrganisationId = :AV53Udparg2 ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AJ5,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("H00AJ6", "SELECT T1.LocationDynamicFormId, T1.WWPFormVersionNumber, T1.OrganisationId, T1.LocationId, T1.WWPFormId, T2.WWPFormReferenceName FROM (Trn_LocationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber) WHERE T1.LocationId = :AV52Udparg1 and T1.OrganisationId = :AV53Udparg2 ORDER BY T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AJ6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00AJ7", "SELECT LocationId, MediaId, MediaName FROM Trn_Media WHERE LocationId = :AV52Udparg1 ORDER BY MediaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AJ7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H00AJ8", "SELECT LocationId, Trn_PageId, Trn_PageName, PageChildren FROM Trn_Page ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00AJ8,100, GxCacheFrequency.OFF ,false,false )
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
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             return;
    }
 }

}

}
