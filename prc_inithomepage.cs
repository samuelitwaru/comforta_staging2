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
   public class prc_inithomepage : GXProcedure
   {
      public prc_inithomepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_inithomepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           Guid aP2_ReceptionPageId ,
                           Guid aP3_LocationPageId ,
                           Guid aP4_CarePageId ,
                           Guid aP5_LivingPageId ,
                           Guid aP6_ServicesPageId ,
                           Guid aP7_MyActivityId ,
                           Guid aP8_CalendarId ,
                           Guid aP9_MapsPageId ,
                           out SdtTrn_AppVersion_Page aP10_BC_HomePage )
      {
         this.AV21LocationId = aP0_LocationId;
         this.AV22OrganisationId = aP1_OrganisationId;
         this.AV8ReceptionPageId = aP2_ReceptionPageId;
         this.AV9LocationPageId = aP3_LocationPageId;
         this.AV10CarePageId = aP4_CarePageId;
         this.AV11LivingPageId = aP5_LivingPageId;
         this.AV12ServicesPageId = aP6_ServicesPageId;
         this.AV20MyActivityId = aP7_MyActivityId;
         this.AV19CalendarId = aP8_CalendarId;
         this.AV24MapsPageId = aP9_MapsPageId;
         this.AV13BC_HomePage = new SdtTrn_AppVersion_Page(context) ;
         initialize();
         ExecuteImpl();
         aP10_BC_HomePage=this.AV13BC_HomePage;
      }

      public SdtTrn_AppVersion_Page executeUdp( Guid aP0_LocationId ,
                                                Guid aP1_OrganisationId ,
                                                Guid aP2_ReceptionPageId ,
                                                Guid aP3_LocationPageId ,
                                                Guid aP4_CarePageId ,
                                                Guid aP5_LivingPageId ,
                                                Guid aP6_ServicesPageId ,
                                                Guid aP7_MyActivityId ,
                                                Guid aP8_CalendarId ,
                                                Guid aP9_MapsPageId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, aP2_ReceptionPageId, aP3_LocationPageId, aP4_CarePageId, aP5_LivingPageId, aP6_ServicesPageId, aP7_MyActivityId, aP8_CalendarId, aP9_MapsPageId, out aP10_BC_HomePage);
         return AV13BC_HomePage ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 Guid aP2_ReceptionPageId ,
                                 Guid aP3_LocationPageId ,
                                 Guid aP4_CarePageId ,
                                 Guid aP5_LivingPageId ,
                                 Guid aP6_ServicesPageId ,
                                 Guid aP7_MyActivityId ,
                                 Guid aP8_CalendarId ,
                                 Guid aP9_MapsPageId ,
                                 out SdtTrn_AppVersion_Page aP10_BC_HomePage )
      {
         this.AV21LocationId = aP0_LocationId;
         this.AV22OrganisationId = aP1_OrganisationId;
         this.AV8ReceptionPageId = aP2_ReceptionPageId;
         this.AV9LocationPageId = aP3_LocationPageId;
         this.AV10CarePageId = aP4_CarePageId;
         this.AV11LivingPageId = aP5_LivingPageId;
         this.AV12ServicesPageId = aP6_ServicesPageId;
         this.AV20MyActivityId = aP7_MyActivityId;
         this.AV19CalendarId = aP8_CalendarId;
         this.AV24MapsPageId = aP9_MapsPageId;
         this.AV13BC_HomePage = new SdtTrn_AppVersion_Page(context) ;
         SubmitImpl();
         aP10_BC_HomePage=this.AV13BC_HomePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV18baseUrl = AV17GAMApplication.gxTpr_Environment.gxTpr_Url;
         AV23BC_Trn_Location.Load(AV21LocationId, AV22OrganisationId);
         AV13BC_HomePage.gxTpr_Pageid = Guid.NewGuid( );
         AV13BC_HomePage.gxTpr_Pagename = "Home";
         AV13BC_HomePage.gxTpr_Ispredefined = true;
         AV13BC_HomePage.gxTpr_Pagetype = "Menu";
         /* Execute user subroutine: 'RECEPTIONTILE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CALENDARANDMYACTIVITYTILES' */
         S121 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'LOCATIONTILE' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'SERVICESTILES' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'MAPSTILE' */
         S151 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13BC_HomePage.gxTpr_Pagestructure = AV14SDT_MenuPage.ToJSonString(false, true);
         cleanup();
      }

      protected void S111( )
      {
         /* 'RECEPTIONTILE' Routine */
         returnInSub = false;
         AV16RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV16RowsItem.gxTpr_Id = new SdtRandomStringGenerator(context).generate(15);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV15TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Reception", ""),  "#333333",  context.GetMessage( "left", ""),  context.GetMessage( "Reception", ""),  0,  "",  AV23BC_Trn_Location.gxTpr_Receptionimage_gxi,  AV8ReceptionPageId.ToString(),  "Content",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV15TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV16RowsItem.gxTpr_Tiles.Add(AV15TilesItem, 0);
         AV14SDT_MenuPage.gxTpr_Rows.Add(AV16RowsItem, 0);
      }

      protected void S121( )
      {
         /* 'CALENDARANDMYACTIVITYTILES' Routine */
         returnInSub = false;
         AV16RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV16RowsItem.gxTpr_Id = new SdtRandomStringGenerator(context).generate(15);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV15TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Agenda", ""),  "#333333",  context.GetMessage( "left", ""),  context.GetMessage( "Calendar", ""),  0,  "",  AV18baseUrl+context.GetMessage( "media/Calendar.png", ""),  AV19CalendarId.ToString(),  context.GetMessage( "Calendar", ""),  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV15TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV16RowsItem.gxTpr_Tiles.Add(AV15TilesItem, 0);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV15TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "My Activity", ""),  "#333333",  context.GetMessage( "left", ""),  "",  0,  "",  "",  AV20MyActivityId.ToString(),  context.GetMessage( "My Activity", ""),  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV15TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV16RowsItem.gxTpr_Tiles.Add(AV15TilesItem, 0);
         AV14SDT_MenuPage.gxTpr_Rows.Add(AV16RowsItem, 0);
      }

      protected void S131( )
      {
         /* 'LOCATIONTILE' Routine */
         returnInSub = false;
         AV16RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV16RowsItem.gxTpr_Id = new SdtRandomStringGenerator(context).generate(15);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV15TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Location", ""),  "#333333",  context.GetMessage( "left", ""),  "",  0,  "",  AV23BC_Trn_Location.gxTpr_Locationimage_gxi,  AV9LocationPageId.ToString(),  "Content",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV15TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV15TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV15TilesItem.gxTpr_Id = new SdtRandomStringGenerator(context).generate(15);
         AV15TilesItem.gxTpr_Name = context.GetMessage( "Location", "");
         AV15TilesItem.gxTpr_Text = context.GetMessage( "Location", "");
         AV15TilesItem.gxTpr_Color = "";
         AV15TilesItem.gxTpr_Bgcolor = "";
         AV15TilesItem.gxTpr_Bgimageurl = "";
         AV15TilesItem.gxTpr_Opacity = 0;
         AV15TilesItem.gxTpr_Action.gxTpr_Objecttype = "Content";
         AV15TilesItem.gxTpr_Action.gxTpr_Objectid = AV9LocationPageId.ToString();
         AV16RowsItem.gxTpr_Tiles.Add(AV15TilesItem, 0);
         AV14SDT_MenuPage.gxTpr_Rows.Add(AV16RowsItem, 0);
      }

      protected void S141( )
      {
         /* 'SERVICESTILES' Routine */
         returnInSub = false;
         AV16RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV16RowsItem.gxTpr_Id = new SdtRandomStringGenerator(context).generate(15);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV15TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "My Care", ""),  "#333333",  context.GetMessage( "center", ""),  "",  0,  "",  "",  AV10CarePageId.ToString(),  "Menu",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV15TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV16RowsItem.gxTpr_Tiles.Add(AV15TilesItem, 0);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV15TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "My Living", ""),  "#333333",  context.GetMessage( "center", ""),  "",  0,  "",  "",  AV11LivingPageId.ToString(),  "Menu",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV15TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV16RowsItem.gxTpr_Tiles.Add(AV15TilesItem, 0);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV15TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "My Services", ""),  "#333333",  context.GetMessage( "center", ""),  "",  0,  "",  "",  AV12ServicesPageId.ToString(),  "Menu",  "", out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV15TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV16RowsItem.gxTpr_Tiles.Add(AV15TilesItem, 0);
         AV14SDT_MenuPage.gxTpr_Rows.Add(AV16RowsItem, 0);
      }

      protected void S151( )
      {
         /* 'MAPSTILE' Routine */
         returnInSub = false;
         AV16RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV16RowsItem.gxTpr_Id = new SdtRandomStringGenerator(context).generate(15);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = AV15TilesItem;
         new prc_createpagetile(context ).execute(  context.GetMessage( "Maps", ""),  "#333333",  context.GetMessage( "left", ""),  "",  0,  "",  "",  AV19CalendarId.ToString(),  context.GetMessage( "Map", ""),  AV24MapsPageId.ToString(), out  GXt_SdtSDT_MenuPage_RowsItem_TilesItem1) ;
         AV15TilesItem = GXt_SdtSDT_MenuPage_RowsItem_TilesItem1;
         AV16RowsItem.gxTpr_Tiles.Add(AV15TilesItem, 0);
         AV14SDT_MenuPage.gxTpr_Rows.Add(AV16RowsItem, 0);
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
         AV13BC_HomePage = new SdtTrn_AppVersion_Page(context);
         AV17GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV18baseUrl = "";
         AV23BC_Trn_Location = new SdtTrn_Location(context);
         AV14SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV16RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV15TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private string AV18baseUrl ;
      private Guid AV21LocationId ;
      private Guid AV22OrganisationId ;
      private Guid AV8ReceptionPageId ;
      private Guid AV9LocationPageId ;
      private Guid AV10CarePageId ;
      private Guid AV11LivingPageId ;
      private Guid AV12ServicesPageId ;
      private Guid AV20MyActivityId ;
      private Guid AV19CalendarId ;
      private Guid AV24MapsPageId ;
      private SdtTrn_AppVersion_Page AV13BC_HomePage ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV17GAMApplication ;
      private SdtTrn_Location AV23BC_Trn_Location ;
      private SdtSDT_MenuPage AV14SDT_MenuPage ;
      private SdtSDT_MenuPage_RowsItem AV16RowsItem ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV15TilesItem ;
      private SdtSDT_MenuPage_RowsItem_TilesItem GXt_SdtSDT_MenuPage_RowsItem_TilesItem1 ;
      private SdtTrn_AppVersion_Page aP10_BC_HomePage ;
   }

}
