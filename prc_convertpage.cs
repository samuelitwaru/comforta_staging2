using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class prc_convertpage : GXProcedure
   {
      public prc_convertpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_convertpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtTrn_Page aP0_BC_Trn_Page ,
                           Guid aP1_ReceptionPageId ,
                           Guid aP2_LocationPageId ,
                           Guid aP3_CarePageId ,
                           Guid aP4_LivingPageId ,
                           Guid aP5_ServicesPageId ,
                           Guid aP6_MyActivityId ,
                           Guid aP7_CalendarId ,
                           Guid aP8_MapsPageId ,
                           Guid aP9_WebLinkPageId ,
                           Guid aP10_DynamicFormPageId ,
                           out SdtTrn_AppVersion_Page aP11_BC_Page )
      {
         this.AV9BC_Trn_Page = aP0_BC_Trn_Page;
         this.AV24ReceptionPageId = aP1_ReceptionPageId;
         this.AV25LocationPageId = aP2_LocationPageId;
         this.AV26CarePageId = aP3_CarePageId;
         this.AV27LivingPageId = aP4_LivingPageId;
         this.AV28ServicesPageId = aP5_ServicesPageId;
         this.AV29MyActivityId = aP6_MyActivityId;
         this.AV30CalendarId = aP7_CalendarId;
         this.AV31MapsPageId = aP8_MapsPageId;
         this.AV35WebLinkPageId = aP9_WebLinkPageId;
         this.AV34DynamicFormPageId = aP10_DynamicFormPageId;
         this.AV8BC_Page = new SdtTrn_AppVersion_Page(context) ;
         initialize();
         ExecuteImpl();
         aP11_BC_Page=this.AV8BC_Page;
      }

      public SdtTrn_AppVersion_Page executeUdp( SdtTrn_Page aP0_BC_Trn_Page ,
                                                Guid aP1_ReceptionPageId ,
                                                Guid aP2_LocationPageId ,
                                                Guid aP3_CarePageId ,
                                                Guid aP4_LivingPageId ,
                                                Guid aP5_ServicesPageId ,
                                                Guid aP6_MyActivityId ,
                                                Guid aP7_CalendarId ,
                                                Guid aP8_MapsPageId ,
                                                Guid aP9_WebLinkPageId ,
                                                Guid aP10_DynamicFormPageId )
      {
         execute(aP0_BC_Trn_Page, aP1_ReceptionPageId, aP2_LocationPageId, aP3_CarePageId, aP4_LivingPageId, aP5_ServicesPageId, aP6_MyActivityId, aP7_CalendarId, aP8_MapsPageId, aP9_WebLinkPageId, aP10_DynamicFormPageId, out aP11_BC_Page);
         return AV8BC_Page ;
      }

      public void executeSubmit( SdtTrn_Page aP0_BC_Trn_Page ,
                                 Guid aP1_ReceptionPageId ,
                                 Guid aP2_LocationPageId ,
                                 Guid aP3_CarePageId ,
                                 Guid aP4_LivingPageId ,
                                 Guid aP5_ServicesPageId ,
                                 Guid aP6_MyActivityId ,
                                 Guid aP7_CalendarId ,
                                 Guid aP8_MapsPageId ,
                                 Guid aP9_WebLinkPageId ,
                                 Guid aP10_DynamicFormPageId ,
                                 out SdtTrn_AppVersion_Page aP11_BC_Page )
      {
         this.AV9BC_Trn_Page = aP0_BC_Trn_Page;
         this.AV24ReceptionPageId = aP1_ReceptionPageId;
         this.AV25LocationPageId = aP2_LocationPageId;
         this.AV26CarePageId = aP3_CarePageId;
         this.AV27LivingPageId = aP4_LivingPageId;
         this.AV28ServicesPageId = aP5_ServicesPageId;
         this.AV29MyActivityId = aP6_MyActivityId;
         this.AV30CalendarId = aP7_CalendarId;
         this.AV31MapsPageId = aP8_MapsPageId;
         this.AV35WebLinkPageId = aP9_WebLinkPageId;
         this.AV34DynamicFormPageId = aP10_DynamicFormPageId;
         this.AV8BC_Page = new SdtTrn_AppVersion_Page(context) ;
         SubmitImpl();
         aP11_BC_Page=this.AV8BC_Page;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8BC_Page.gxTpr_Pageid = AV9BC_Trn_Page.gxTpr_Trn_pageid;
         AV8BC_Page.gxTpr_Pagename = AV9BC_Trn_Page.gxTpr_Trn_pagename;
         AV8BC_Page.gxTpr_Pagestructure = "";
         AV8BC_Page.gxTpr_Pagepublishedstructure = "";
         if ( ( StringUtil.StrCmp(AV9BC_Trn_Page.gxTpr_Trn_pagename, context.GetMessage( "My Activity", "")) == 0 ) || ( StringUtil.StrCmp(AV9BC_Trn_Page.gxTpr_Trn_pagename, context.GetMessage( "Mailbox", "")) == 0 ) )
         {
            AV8BC_Page.gxTpr_Pagetype = "MyActivity";
         }
         else if ( StringUtil.StrCmp(AV9BC_Trn_Page.gxTpr_Trn_pagename, context.GetMessage( "Calendar", "")) == 0 )
         {
            AV8BC_Page.gxTpr_Pagetype = "Calendar";
         }
         else if ( StringUtil.StrCmp(AV9BC_Trn_Page.gxTpr_Trn_pagename, context.GetMessage( "Reception", "")) == 0 )
         {
            AV8BC_Page.gxTpr_Pagetype = "Reception";
         }
         else if ( StringUtil.StrCmp(AV9BC_Trn_Page.gxTpr_Trn_pagename, context.GetMessage( "Location", "")) == 0 )
         {
            AV8BC_Page.gxTpr_Pagetype = "Location";
         }
         else if ( AV9BC_Trn_Page.gxTpr_Pageisweblinkpage )
         {
            AV8BC_Page.gxTpr_Pagetype = "WebLink";
         }
         else if ( AV9BC_Trn_Page.gxTpr_Pageisdynamicform )
         {
            AV8BC_Page.gxTpr_Pagetype = "DynamicForm";
         }
         else if ( ! (Guid.Empty==AV9BC_Trn_Page.gxTpr_Productserviceid) )
         {
            AV8BC_Page.gxTpr_Pagetype = "Content";
         }
         else
         {
            AV8BC_Page.gxTpr_Pagetype = "Menu";
         }
         if ( AV9BC_Trn_Page.gxTpr_Pageiscontentpage )
         {
            AV18SDT_ContentPage = new SdtSDT_ContentPage(context);
            AV19SDT_ContentPageV1.FromJSonString(AV9BC_Trn_Page.gxTpr_Pagejsoncontent, null);
            AV36GXV1 = 1;
            while ( AV36GXV1 <= AV19SDT_ContentPageV1.gxTpr_Content.Count )
            {
               AV20ContentItem = ((SdtSDT_ContentPageV1_ContentItem)AV19SDT_ContentPageV1.gxTpr_Content.Item(AV36GXV1));
               AV21NewContentItem = new SdtSDT_ContentPage_ContentItem(context);
               AV21NewContentItem.gxTpr_Contentid = Guid.NewGuid( ).ToString();
               AV21NewContentItem.gxTpr_Contenttype = AV20ContentItem.gxTpr_Contenttype;
               AV21NewContentItem.gxTpr_Contentvalue = AV20ContentItem.gxTpr_Contentvalue;
               AV18SDT_ContentPage.gxTpr_Content.Add(AV21NewContentItem, 0);
               AV36GXV1 = (int)(AV36GXV1+1);
            }
            AV37GXV2 = 1;
            while ( AV37GXV2 <= AV19SDT_ContentPageV1.gxTpr_Cta.Count )
            {
               AV22CtaItem = ((SdtSDT_ContentPageV1_CtaItem)AV19SDT_ContentPageV1.gxTpr_Cta.Item(AV37GXV2));
               AV23NewCtaItem = new SdtSDT_ContentPage_CtaItem(context);
               AV23NewCtaItem.gxTpr_Ctaid = AV22CtaItem.gxTpr_Ctaid.ToString();
               AV23NewCtaItem.gxTpr_Ctalabel = AV22CtaItem.gxTpr_Ctalabel;
               AV23NewCtaItem.gxTpr_Ctatype = AV22CtaItem.gxTpr_Ctatype;
               AV23NewCtaItem.gxTpr_Ctaaction = AV22CtaItem.gxTpr_Ctaaction;
               AV23NewCtaItem.gxTpr_Ctabuttonimgurl = "";
               if ( AV22CtaItem.gxTpr_Isfullwidth )
               {
                  AV23NewCtaItem.gxTpr_Ctabuttontype = "FullWidth";
               }
               else if ( AV22CtaItem.gxTpr_Isimagebutton )
               {
                  AV23NewCtaItem.gxTpr_Ctabuttontype = "Icon";
               }
               else
               {
                  AV23NewCtaItem.gxTpr_Ctabuttontype = "Round";
               }
               AV18SDT_ContentPage.gxTpr_Cta.Add(AV23NewCtaItem, 0);
               AV37GXV2 = (int)(AV37GXV2+1);
            }
            AV17PageStructure = AV18SDT_ContentPage.ToJSonString(false, true);
         }
         else
         {
            AV12SDT_MenuPage = new SdtSDT_MenuPage(context);
            AV10SDT_MobilePage.FromJSonString(AV9BC_Trn_Page.gxTpr_Pagejsoncontent, null);
            AV38GXV3 = 1;
            while ( AV38GXV3 <= AV10SDT_MobilePage.gxTpr_Row.Count )
            {
               AV11SDT_Row = ((SdtSDT_Row)AV10SDT_MobilePage.gxTpr_Row.Item(AV38GXV3));
               AV13RowItem = new SdtSDT_MenuPage_RowsItem(context);
               AV13RowItem.gxTpr_Id = new SdtRandomStringGenerator(context).generate(15);
               AV39GXV4 = 1;
               while ( AV39GXV4 <= AV11SDT_Row.gxTpr_Col.Count )
               {
                  AV14SDT_Col = ((SdtSDT_Col)AV11SDT_Row.gxTpr_Col.Item(AV39GXV4));
                  AV15SDT_Tile = AV14SDT_Col.gxTpr_Tile;
                  AV16TileItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
                  AV16TileItem.gxTpr_Id = new SdtRandomStringGenerator(context).generate(15);
                  AV16TileItem.gxTpr_Name = AV15SDT_Tile.gxTpr_Tilename;
                  AV16TileItem.gxTpr_Text = AV15SDT_Tile.gxTpr_Tiletext;
                  AV16TileItem.gxTpr_Icon = AV15SDT_Tile.gxTpr_Tileicon;
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15SDT_Tile.gxTpr_Tilecolor)) )
                  {
                     AV16TileItem.gxTpr_Color = "#333333";
                  }
                  else
                  {
                     AV16TileItem.gxTpr_Color = AV15SDT_Tile.gxTpr_Tilecolor;
                  }
                  AV16TileItem.gxTpr_Bgcolor = AV15SDT_Tile.gxTpr_Tilebgcolor;
                  AV16TileItem.gxTpr_Bgimageurl = AV15SDT_Tile.gxTpr_Tilebgimageurl;
                  AV16TileItem.gxTpr_Align = AV15SDT_Tile.gxTpr_Tilealignment;
                  AV16TileItem.gxTpr_Opacity = AV15SDT_Tile.gxTpr_Tilebgimageopacity;
                  /* Execute user subroutine: 'TILEACTIONTYPE' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
                  AV13RowItem.gxTpr_Tiles.Add(AV16TileItem, 0);
                  AV39GXV4 = (int)(AV39GXV4+1);
               }
               if ( AV13RowItem.gxTpr_Tiles.Count > 0 )
               {
                  AV12SDT_MenuPage.gxTpr_Rows.Add(AV13RowItem, 0);
               }
               AV38GXV3 = (int)(AV38GXV3+1);
            }
            AV17PageStructure = AV12SDT_MenuPage.ToJSonString(false, true);
         }
         AV8BC_Page.gxTpr_Pagestructure = AV17PageStructure;
         AV8BC_Page.gxTpr_Pagepublishedstructure = AV17PageStructure;
         cleanup();
      }

      protected void S111( )
      {
         /* 'TILEACTIONTYPE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV8BC_Page.gxTpr_Pagename, context.GetMessage( "Home", "")) == 0 )
         {
            new prc_logtoserver(context ).execute(  "            "+AV15SDT_Tile.gxTpr_Tiletext+" : "+AV15SDT_Tile.gxTpr_Tilename+" : "+AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype) ;
         }
         AV16TileItem.gxTpr_Action.gxTpr_Objecturl = AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objecturl;
         if ( StringUtil.StrCmp(AV15SDT_Tile.gxTpr_Tilename, context.GetMessage( "My Care", "")) == 0 )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "MyCare";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV26CarePageId.ToString();
         }
         else if ( StringUtil.StrCmp(AV15SDT_Tile.gxTpr_Tiletext, context.GetMessage( "My Living", "")) == 0 )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "MyLiving";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV27LivingPageId.ToString();
         }
         else if ( StringUtil.StrCmp(AV15SDT_Tile.gxTpr_Tiletext, context.GetMessage( "My Services", "")) == 0 )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "MyService";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV28ServicesPageId.ToString();
         }
         else if ( StringUtil.StrCmp(AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype, context.GetMessage( "Predefined Page, Location", "")) == 0 )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "Location";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV25LocationPageId.ToString();
         }
         else if ( StringUtil.StrCmp(AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype, context.GetMessage( "Predefined Page, Reception", "")) == 0 )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "Reception";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV24ReceptionPageId.ToString();
         }
         else if ( StringUtil.StrCmp(AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype, context.GetMessage( "Predefined Page, Calendar", "")) == 0 )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "Calendar";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV30CalendarId.ToString();
         }
         else if ( StringUtil.StrCmp(AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype, context.GetMessage( "Predefined Page, My Activity", "")) == 0 )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "MyActivity";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV29MyActivityId.ToString();
         }
         else if ( StringUtil.StartsWith( AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype, context.GetMessage( "Service/Product Page", "")) )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "Content";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objectid;
         }
         else if ( StringUtil.StartsWith( AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype, context.GetMessage( "Page", "")) )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "Menu";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objectid;
         }
         else if ( StringUtil.Contains( AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype, context.GetMessage( "Link", "")) )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "WebLink";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV35WebLinkPageId.ToString();
         }
         else if ( StringUtil.Contains( AV15SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype, context.GetMessage( "Form", "")) )
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "DynamicForm";
            AV16TileItem.gxTpr_Action.gxTpr_Objectid = AV34DynamicFormPageId.ToString();
         }
         else
         {
            AV16TileItem.gxTpr_Action.gxTpr_Objecttype = "";
         }
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
         AV8BC_Page = new SdtTrn_AppVersion_Page(context);
         AV18SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV19SDT_ContentPageV1 = new SdtSDT_ContentPageV1(context);
         AV20ContentItem = new SdtSDT_ContentPageV1_ContentItem(context);
         AV21NewContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV22CtaItem = new SdtSDT_ContentPageV1_CtaItem(context);
         AV23NewCtaItem = new SdtSDT_ContentPage_CtaItem(context);
         AV17PageStructure = "";
         AV12SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV10SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV11SDT_Row = new SdtSDT_Row(context);
         AV13RowItem = new SdtSDT_MenuPage_RowsItem(context);
         AV14SDT_Col = new SdtSDT_Col(context);
         AV15SDT_Tile = new SdtSDT_Tile(context);
         AV16TileItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         /* GeneXus formulas. */
      }

      private int AV36GXV1 ;
      private int AV37GXV2 ;
      private int AV38GXV3 ;
      private int AV39GXV4 ;
      private bool returnInSub ;
      private string AV17PageStructure ;
      private Guid AV24ReceptionPageId ;
      private Guid AV25LocationPageId ;
      private Guid AV26CarePageId ;
      private Guid AV27LivingPageId ;
      private Guid AV28ServicesPageId ;
      private Guid AV29MyActivityId ;
      private Guid AV30CalendarId ;
      private Guid AV31MapsPageId ;
      private Guid AV35WebLinkPageId ;
      private Guid AV34DynamicFormPageId ;
      private SdtTrn_Page AV9BC_Trn_Page ;
      private SdtTrn_AppVersion_Page AV8BC_Page ;
      private SdtSDT_ContentPage AV18SDT_ContentPage ;
      private SdtSDT_ContentPageV1 AV19SDT_ContentPageV1 ;
      private SdtSDT_ContentPageV1_ContentItem AV20ContentItem ;
      private SdtSDT_ContentPage_ContentItem AV21NewContentItem ;
      private SdtSDT_ContentPageV1_CtaItem AV22CtaItem ;
      private SdtSDT_ContentPage_CtaItem AV23NewCtaItem ;
      private SdtSDT_MenuPage AV12SDT_MenuPage ;
      private SdtSDT_MobilePage AV10SDT_MobilePage ;
      private SdtSDT_Row AV11SDT_Row ;
      private SdtSDT_MenuPage_RowsItem AV13RowItem ;
      private SdtSDT_Col AV14SDT_Col ;
      private SdtSDT_Tile AV15SDT_Tile ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV16TileItem ;
      private SdtTrn_AppVersion_Page aP11_BC_Page ;
   }

}
