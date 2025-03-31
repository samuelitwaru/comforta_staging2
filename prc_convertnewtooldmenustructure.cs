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
   public class prc_convertnewtooldmenustructure : GXProcedure
   {
      public prc_convertnewtooldmenustructure( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_convertnewtooldmenustructure( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtSDT_MenuPage aP0_SDT_MenuPage ,
                           Guid aP1_PageId ,
                           string aP2_PageName ,
                           out SdtSDT_MobilePage aP3_SDT_MobilePage )
      {
         this.AV8SDT_MenuPage = aP0_SDT_MenuPage;
         this.AV17PageId = aP1_PageId;
         this.AV18PageName = aP2_PageName;
         this.AV9SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         initialize();
         ExecuteImpl();
         aP3_SDT_MobilePage=this.AV9SDT_MobilePage;
      }

      public SdtSDT_MobilePage executeUdp( SdtSDT_MenuPage aP0_SDT_MenuPage ,
                                           Guid aP1_PageId ,
                                           string aP2_PageName )
      {
         execute(aP0_SDT_MenuPage, aP1_PageId, aP2_PageName, out aP3_SDT_MobilePage);
         return AV9SDT_MobilePage ;
      }

      public void executeSubmit( SdtSDT_MenuPage aP0_SDT_MenuPage ,
                                 Guid aP1_PageId ,
                                 string aP2_PageName ,
                                 out SdtSDT_MobilePage aP3_SDT_MobilePage )
      {
         this.AV8SDT_MenuPage = aP0_SDT_MenuPage;
         this.AV17PageId = aP1_PageId;
         this.AV18PageName = aP2_PageName;
         this.AV9SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         SubmitImpl();
         aP3_SDT_MobilePage=this.AV9SDT_MobilePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV9SDT_MobilePage.gxTpr_Pageid = AV17PageId;
         AV9SDT_MobilePage.gxTpr_Pagename = AV18PageName;
         AV9SDT_MobilePage.gxTpr_Pageiscontentpage = false;
         AV9SDT_MobilePage.gxTpr_Pageispublished = true;
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV8SDT_MenuPage.gxTpr_Rows.Count )
         {
            AV13RowsItem = ((SdtSDT_MenuPage_RowsItem)AV8SDT_MenuPage.gxTpr_Rows.Item(AV19GXV1));
            AV10SDT_Row = new SdtSDT_Row(context);
            AV20GXV2 = 1;
            while ( AV20GXV2 <= AV13RowsItem.gxTpr_Tiles.Count )
            {
               AV15TilesItem = ((SdtSDT_MenuPage_RowsItem_TilesItem)AV13RowsItem.gxTpr_Tiles.Item(AV20GXV2));
               AV16SDT_Col = new SdtSDT_Col(context);
               AV12SDT_Tile = new SdtSDT_Tile(context);
               AV12SDT_Tile.gxTpr_Tileid = AV15TilesItem.gxTpr_Id;
               AV12SDT_Tile.gxTpr_Tilename = AV15TilesItem.gxTpr_Name;
               AV12SDT_Tile.gxTpr_Tiletext = AV15TilesItem.gxTpr_Text;
               AV12SDT_Tile.gxTpr_Tilecolor = AV15TilesItem.gxTpr_Color;
               AV12SDT_Tile.gxTpr_Tilealignment = AV15TilesItem.gxTpr_Align;
               AV12SDT_Tile.gxTpr_Tileicon = AV15TilesItem.gxTpr_Icon;
               AV12SDT_Tile.gxTpr_Tilebgcolor = AV15TilesItem.gxTpr_Bgcolor;
               AV12SDT_Tile.gxTpr_Tilebgimageurl = AV15TilesItem.gxTpr_Bgimageurl;
               AV12SDT_Tile.gxTpr_Tilebgimageopacity = AV15TilesItem.gxTpr_Opacity;
               AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objectid = AV15TilesItem.gxTpr_Action.gxTpr_Objectid;
               AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype = AV15TilesItem.gxTpr_Action.gxTpr_Objecttype;
               AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecturl = AV15TilesItem.gxTpr_Action.gxTpr_Objecturl;
               AV16SDT_Col.gxTpr_Tile = AV12SDT_Tile;
               AV10SDT_Row.gxTpr_Col.Add(AV16SDT_Col, 0);
               AV20GXV2 = (int)(AV20GXV2+1);
            }
            AV9SDT_MobilePage.gxTpr_Row.Add(AV10SDT_Row, 0);
            AV19GXV1 = (int)(AV19GXV1+1);
         }
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
         AV9SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV13RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV10SDT_Row = new SdtSDT_Row(context);
         AV15TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV16SDT_Col = new SdtSDT_Col(context);
         AV12SDT_Tile = new SdtSDT_Tile(context);
         /* GeneXus formulas. */
      }

      private int AV19GXV1 ;
      private int AV20GXV2 ;
      private string AV18PageName ;
      private Guid AV17PageId ;
      private SdtSDT_MenuPage AV8SDT_MenuPage ;
      private SdtSDT_MobilePage AV9SDT_MobilePage ;
      private SdtSDT_MenuPage_RowsItem AV13RowsItem ;
      private SdtSDT_Row AV10SDT_Row ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV15TilesItem ;
      private SdtSDT_Col AV16SDT_Col ;
      private SdtSDT_Tile AV12SDT_Tile ;
      private SdtSDT_MobilePage aP3_SDT_MobilePage ;
   }

}
