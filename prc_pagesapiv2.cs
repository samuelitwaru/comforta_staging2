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
   public class prc_pagesapiv2 : GXProcedure
   {
      public prc_pagesapiv2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_pagesapiv2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId ,
                           string aP2_UserId ,
                           out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV10UserId = aP2_UserId;
         this.AV17SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version20") ;
         initialize();
         ExecuteImpl();
         aP3_SDT_MobilePageCollection=this.AV17SDT_MobilePageCollection;
      }

      public GXBaseCollection<SdtSDT_MobilePage> executeUdp( Guid aP0_LocationId ,
                                                             Guid aP1_OrganisationId ,
                                                             string aP2_UserId )
      {
         execute(aP0_LocationId, aP1_OrganisationId, aP2_UserId, out aP3_SDT_MobilePageCollection);
         return AV17SDT_MobilePageCollection ;
      }

      public void executeSubmit( Guid aP0_LocationId ,
                                 Guid aP1_OrganisationId ,
                                 string aP2_UserId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection )
      {
         this.AV8LocationId = aP0_LocationId;
         this.AV9OrganisationId = aP1_OrganisationId;
         this.AV10UserId = aP2_UserId;
         this.AV17SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version20") ;
         SubmitImpl();
         aP3_SDT_MobilePageCollection=this.AV17SDT_MobilePageCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SDT_PageCollection.Clear();
         /* Using cursor P00DL2 */
         pr_default.execute(0, new Object[] {AV8LocationId, AV9OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00DL2_A523AppVersionId[0];
            A535IsActive = P00DL2_A535IsActive[0];
            A11OrganisationId = P00DL2_A11OrganisationId[0];
            n11OrganisationId = P00DL2_n11OrganisationId[0];
            A29LocationId = P00DL2_A29LocationId[0];
            n29LocationId = P00DL2_n29LocationId[0];
            /* Using cursor P00DL3 */
            pr_default.execute(1, new Object[] {A523AppVersionId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A525PageType = P00DL3_A525PageType[0];
               A536PagePublishedStructure = P00DL3_A536PagePublishedStructure[0];
               A516PageId = P00DL3_A516PageId[0];
               A517PageName = P00DL3_A517PageName[0];
               AV15SDT_MenuPage.FromJSonString(A536PagePublishedStructure, null);
               GXt_SdtSDT_MobilePage1 = AV16SDT_MobilePage;
               new prc_convertnewtooldmenustructure(context ).execute(  AV15SDT_MenuPage,  A516PageId,  A517PageName,  AV8LocationId, out  GXt_SdtSDT_MobilePage1) ;
               AV16SDT_MobilePage = GXt_SdtSDT_MobilePage1;
               new prc_logtoserver(context ).execute(  A517PageName+" "+AV16SDT_MobilePage.ToJSonString(false, true)) ;
               if ( StringUtil.StrCmp(AV16SDT_MobilePage.gxTpr_Pagename, context.GetMessage( "Home", "")) == 0 )
               {
                  new prc_logtoserver(context ).execute(  "    "+A517PageName+" "+AV16SDT_MobilePage.ToJSonString(false, true)) ;
                  GXt_SdtSDT_MobilePage1 = AV13Filtered_SDT_MobilePage;
                  new prc_filterpagetiles(context ).execute(  AV16SDT_MobilePage,  AV10UserId, out  GXt_SdtSDT_MobilePage1) ;
                  AV13Filtered_SDT_MobilePage = GXt_SdtSDT_MobilePage1;
                  AV17SDT_MobilePageCollection.Add(AV13Filtered_SDT_MobilePage, 0);
               }
               else
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV16SDT_MobilePage.gxTpr_Pagename))) )
                  {
                     AV17SDT_MobilePageCollection.Add(AV16SDT_MobilePage, 0);
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new prc_logtoserver(context ).execute(  AV17SDT_MobilePageCollection.ToJSonString(false)) ;
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
         AV17SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version20");
         AV11SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version20");
         P00DL2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DL2_A535IsActive = new bool[] {false} ;
         P00DL2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DL2_n11OrganisationId = new bool[] {false} ;
         P00DL2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DL2_n29LocationId = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         P00DL3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DL3_A525PageType = new string[] {""} ;
         P00DL3_A536PagePublishedStructure = new string[] {""} ;
         P00DL3_A516PageId = new Guid[] {Guid.Empty} ;
         P00DL3_A517PageName = new string[] {""} ;
         A525PageType = "";
         A536PagePublishedStructure = "";
         A516PageId = Guid.Empty;
         A517PageName = "";
         AV15SDT_MenuPage = new SdtSDT_MenuPage(context);
         AV16SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV13Filtered_SDT_MobilePage = new SdtSDT_MobilePage(context);
         GXt_SdtSDT_MobilePage1 = new SdtSDT_MobilePage(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_pagesapiv2__default(),
            new Object[][] {
                new Object[] {
               P00DL2_A523AppVersionId, P00DL2_A535IsActive, P00DL2_A11OrganisationId, P00DL2_n11OrganisationId, P00DL2_A29LocationId, P00DL2_n29LocationId
               }
               , new Object[] {
               P00DL3_A523AppVersionId, P00DL3_A525PageType, P00DL3_A536PagePublishedStructure, P00DL3_A516PageId, P00DL3_A517PageName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool A535IsActive ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private string A536PagePublishedStructure ;
      private string AV10UserId ;
      private string A525PageType ;
      private string A517PageName ;
      private Guid AV8LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A523AppVersionId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_MobilePage> AV17SDT_MobilePageCollection ;
      private GXBaseCollection<SdtSDT_Page> AV11SDT_PageCollection ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DL2_A523AppVersionId ;
      private bool[] P00DL2_A535IsActive ;
      private Guid[] P00DL2_A11OrganisationId ;
      private bool[] P00DL2_n11OrganisationId ;
      private Guid[] P00DL2_A29LocationId ;
      private bool[] P00DL2_n29LocationId ;
      private Guid[] P00DL3_A523AppVersionId ;
      private string[] P00DL3_A525PageType ;
      private string[] P00DL3_A536PagePublishedStructure ;
      private Guid[] P00DL3_A516PageId ;
      private string[] P00DL3_A517PageName ;
      private SdtSDT_MenuPage AV15SDT_MenuPage ;
      private SdtSDT_MobilePage AV16SDT_MobilePage ;
      private SdtSDT_MobilePage AV13Filtered_SDT_MobilePage ;
      private SdtSDT_MobilePage GXt_SdtSDT_MobilePage1 ;
      private GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection ;
   }

   public class prc_pagesapiv2__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DL2;
          prmP00DL2 = new Object[] {
          new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DL3;
          prmP00DL3 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DL2", "SELECT AppVersionId, IsActive, OrganisationId, LocationId FROM Trn_AppVersion WHERE (LocationId = :AV8LocationId and OrganisationId = :AV9OrganisationId) AND (IsActive = TRUE) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DL2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DL3", "SELECT AppVersionId, PageType, PagePublishedStructure, PageId, PageName FROM Trn_AppVersionPage WHERE (AppVersionId = :AppVersionId) AND (( PageType = ( 'Menu')) or ( PageType = ( 'MyCare')) or ( PageType = ( 'MyLiving')) or ( PageType = ( 'MyService'))) ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DL3,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
