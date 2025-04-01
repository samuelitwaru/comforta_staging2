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
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_convertnewtooldmenustructure( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSDT_MenuPage aP0_SDT_MenuPage ,
                           Guid aP1_PageId ,
                           string aP2_PageName ,
                           Guid aP3_LocationId ,
                           out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV8SDT_MenuPage = aP0_SDT_MenuPage;
         this.AV17PageId = aP1_PageId;
         this.AV18PageName = aP2_PageName;
         this.AV19LocationId = aP3_LocationId;
         this.AV9SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         initialize();
         ExecuteImpl();
         aP4_SDT_MobilePage=this.AV9SDT_MobilePage;
      }

      public SdtSDT_MobilePage executeUdp( SdtSDT_MenuPage aP0_SDT_MenuPage ,
                                           Guid aP1_PageId ,
                                           string aP2_PageName ,
                                           Guid aP3_LocationId )
      {
         execute(aP0_SDT_MenuPage, aP1_PageId, aP2_PageName, aP3_LocationId, out aP4_SDT_MobilePage);
         return AV9SDT_MobilePage ;
      }

      public void executeSubmit( SdtSDT_MenuPage aP0_SDT_MenuPage ,
                                 Guid aP1_PageId ,
                                 string aP2_PageName ,
                                 Guid aP3_LocationId ,
                                 out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV8SDT_MenuPage = aP0_SDT_MenuPage;
         this.AV17PageId = aP1_PageId;
         this.AV18PageName = aP2_PageName;
         this.AV19LocationId = aP3_LocationId;
         this.AV9SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         SubmitImpl();
         aP4_SDT_MobilePage=this.AV9SDT_MobilePage;
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
         AV21ObjectTypeDictionary.fromjson( context.GetMessage( "{\"Content\":\"Product\", \"\"}", ""));
         /* Using cursor P00DJ2 */
         pr_default.execute(0, new Object[] {AV19LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00DJ2_A29LocationId[0];
            A273Trn_ThemeId = P00DJ2_A273Trn_ThemeId[0];
            n273Trn_ThemeId = P00DJ2_n273Trn_ThemeId[0];
            A11OrganisationId = P00DJ2_A11OrganisationId[0];
            AV20ThemeId = A273Trn_ThemeId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV8SDT_MenuPage.gxTpr_Rows.Count )
         {
            AV13RowsItem = ((SdtSDT_MenuPage_RowsItem)AV8SDT_MenuPage.gxTpr_Rows.Item(AV23GXV1));
            AV10SDT_Row = new SdtSDT_Row(context);
            AV24GXV2 = 1;
            while ( AV24GXV2 <= AV13RowsItem.gxTpr_Tiles.Count )
            {
               AV15TilesItem = ((SdtSDT_MenuPage_RowsItem_TilesItem)AV13RowsItem.gxTpr_Tiles.Item(AV24GXV2));
               AV16SDT_Col = new SdtSDT_Col(context);
               AV12SDT_Tile = new SdtSDT_Tile(context);
               AV12SDT_Tile.gxTpr_Tileid = AV15TilesItem.gxTpr_Id;
               AV12SDT_Tile.gxTpr_Tilename = AV15TilesItem.gxTpr_Name;
               AV12SDT_Tile.gxTpr_Tiletext = AV15TilesItem.gxTpr_Text;
               AV12SDT_Tile.gxTpr_Tilecolor = AV15TilesItem.gxTpr_Color;
               AV12SDT_Tile.gxTpr_Tilealignment = AV15TilesItem.gxTpr_Align;
               AV12SDT_Tile.gxTpr_Tileicon = AV15TilesItem.gxTpr_Icon;
               GXt_char1 = "";
               new prc_getthemecolorbyname(context ).execute(  AV20ThemeId,  AV15TilesItem.gxTpr_Bgcolor, out  GXt_char1) ;
               AV12SDT_Tile.gxTpr_Tilebgcolor = GXt_char1;
               AV12SDT_Tile.gxTpr_Tilebgimageurl = AV15TilesItem.gxTpr_Bgimageurl;
               AV12SDT_Tile.gxTpr_Tilebgimageopacity = AV15TilesItem.gxTpr_Opacity;
               AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objectid = AV15TilesItem.gxTpr_Action.gxTpr_Objectid;
               AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecturl = AV15TilesItem.gxTpr_Action.gxTpr_Objecturl;
               /* Execute user subroutine: 'MAPACTIONOBJECTTYPE' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV16SDT_Col.gxTpr_Tile = AV12SDT_Tile;
               AV10SDT_Row.gxTpr_Col.Add(AV16SDT_Col, 0);
               AV24GXV2 = (int)(AV24GXV2+1);
            }
            AV9SDT_MobilePage.gxTpr_Row.Add(AV10SDT_Row, 0);
            AV23GXV1 = (int)(AV23GXV1+1);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'MAPACTIONOBJECTTYPE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV15TilesItem.gxTpr_Action.gxTpr_Objecttype, "Maps") == 0 )
         {
            AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype = "Maps";
         }
         else if ( StringUtil.StrCmp(AV15TilesItem.gxTpr_Action.gxTpr_Objecttype, "Menu") == 0 )
         {
            AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype = context.GetMessage( "Page", "");
         }
         else if ( ( ( StringUtil.StrCmp(AV15TilesItem.gxTpr_Action.gxTpr_Objecttype, context.GetMessage( "Content", "")) == 0 ) ) || ( ( StringUtil.StrCmp(AV15TilesItem.gxTpr_Action.gxTpr_Objecttype, context.GetMessage( "Location", "")) == 0 ) ) || ( ( StringUtil.StrCmp(AV15TilesItem.gxTpr_Action.gxTpr_Objecttype, context.GetMessage( "Reception", "")) == 0 ) ) )
         {
            AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype = context.GetMessage( "Service/Product Page", "");
         }
         else if ( StringUtil.StrCmp(AV15TilesItem.gxTpr_Action.gxTpr_Objecttype, context.GetMessage( "My Activity", "")) == 0 )
         {
            AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype = context.GetMessage( "Predefined Page, Mailbox", "");
         }
         else if ( StringUtil.StrCmp(AV15TilesItem.gxTpr_Action.gxTpr_Objecttype, "Calendar") == 0 )
         {
            AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype = context.GetMessage( "Predefined Page, Calendar", "");
         }
         else if ( StringUtil.StrCmp(AV15TilesItem.gxTpr_Action.gxTpr_Objecttype, context.GetMessage( "Dynamic Form", "")) == 0 )
         {
            AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype = context.GetMessage( "Dynamic Forms", "");
         }
         else if ( StringUtil.StrCmp(AV15TilesItem.gxTpr_Action.gxTpr_Objecttype, context.GetMessage( "Web Link", "")) == 0 )
         {
            AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype = context.GetMessage( "Web Link", "");
         }
         else
         {
            AV12SDT_Tile.gxTpr_Tileaction.gxTpr_Objecttype = "";
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
         AV9SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV21ObjectTypeDictionary = new GeneXus.Core.genexus.common.SdtDictionary<string, string>();
         P00DJ2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DJ2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         P00DJ2_n273Trn_ThemeId = new bool[] {false} ;
         P00DJ2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A29LocationId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV20ThemeId = Guid.Empty;
         AV13RowsItem = new SdtSDT_MenuPage_RowsItem(context);
         AV10SDT_Row = new SdtSDT_Row(context);
         AV15TilesItem = new SdtSDT_MenuPage_RowsItem_TilesItem(context);
         AV16SDT_Col = new SdtSDT_Col(context);
         AV12SDT_Tile = new SdtSDT_Tile(context);
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_convertnewtooldmenustructure__default(),
            new Object[][] {
                new Object[] {
               P00DJ2_A29LocationId, P00DJ2_A273Trn_ThemeId, P00DJ2_n273Trn_ThemeId, P00DJ2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV23GXV1 ;
      private int AV24GXV2 ;
      private string GXt_char1 ;
      private bool n273Trn_ThemeId ;
      private bool returnInSub ;
      private string AV18PageName ;
      private Guid AV17PageId ;
      private Guid AV19LocationId ;
      private Guid A29LocationId ;
      private Guid A273Trn_ThemeId ;
      private Guid A11OrganisationId ;
      private Guid AV20ThemeId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_MenuPage AV8SDT_MenuPage ;
      private SdtSDT_MobilePage AV9SDT_MobilePage ;
      private GeneXus.Core.genexus.common.SdtDictionary<string, string> AV21ObjectTypeDictionary ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DJ2_A29LocationId ;
      private Guid[] P00DJ2_A273Trn_ThemeId ;
      private bool[] P00DJ2_n273Trn_ThemeId ;
      private Guid[] P00DJ2_A11OrganisationId ;
      private SdtSDT_MenuPage_RowsItem AV13RowsItem ;
      private SdtSDT_Row AV10SDT_Row ;
      private SdtSDT_MenuPage_RowsItem_TilesItem AV15TilesItem ;
      private SdtSDT_Col AV16SDT_Col ;
      private SdtSDT_Tile AV12SDT_Tile ;
      private SdtSDT_MobilePage aP4_SDT_MobilePage ;
   }

   public class prc_convertnewtooldmenustructure__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DJ2;
          prmP00DJ2 = new Object[] {
          new ParDef("AV19LocationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DJ2", "SELECT LocationId, Trn_ThemeId, OrganisationId FROM Trn_Location WHERE LocationId = :AV19LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DJ2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
