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
   public class prc_pageapi : GXProcedure
   {
      public prc_pageapi( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_pageapi( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           Guid aP1_LocationId ,
                           Guid aP2_OrganisationId ,
                           string aP3_UserId ,
                           out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV11PageId = aP0_PageId;
         this.AV10LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         this.AV14UserId = aP3_UserId;
         this.AV8SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         initialize();
         ExecuteImpl();
         aP4_SDT_MobilePage=this.AV8SDT_MobilePage;
      }

      public SdtSDT_MobilePage executeUdp( Guid aP0_PageId ,
                                           Guid aP1_LocationId ,
                                           Guid aP2_OrganisationId ,
                                           string aP3_UserId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, aP3_UserId, out aP4_SDT_MobilePage);
         return AV8SDT_MobilePage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 string aP3_UserId ,
                                 out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV11PageId = aP0_PageId;
         this.AV10LocationId = aP1_LocationId;
         this.AV9OrganisationId = aP2_OrganisationId;
         this.AV14UserId = aP3_UserId;
         this.AV8SDT_MobilePage = new SdtSDT_MobilePage(context) ;
         SubmitImpl();
         aP4_SDT_MobilePage=this.AV8SDT_MobilePage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00902 */
         pr_default.execute(0, new Object[] {AV11PageId, AV10LocationId, AV9OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = P00902_A11OrganisationId[0];
            A29LocationId = P00902_A29LocationId[0];
            A392Trn_PageId = P00902_A392Trn_PageId[0];
            A420PageJsonContent = P00902_A420PageJsonContent[0];
            n420PageJsonContent = P00902_n420PageJsonContent[0];
            A397Trn_PageName = P00902_A397Trn_PageName[0];
            A423PageIsPublished = P00902_A423PageIsPublished[0];
            n423PageIsPublished = P00902_n423PageIsPublished[0];
            A429PageIsContentPage = P00902_A429PageIsContentPage[0];
            n429PageIsContentPage = P00902_n429PageIsContentPage[0];
            AV8SDT_MobilePage = new SdtSDT_MobilePage(context);
            AV8SDT_MobilePage.FromJSonString(A420PageJsonContent, null);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A420PageJsonContent))) )
            {
               AV8SDT_MobilePage.gxTpr_Pageid = A392Trn_PageId;
               AV8SDT_MobilePage.gxTpr_Pagename = A397Trn_PageName;
               AV8SDT_MobilePage.gxTpr_Pageispublished = A423PageIsPublished;
               AV8SDT_MobilePage.gxTpr_Pageiscontentpage = A429PageIsContentPage;
            }
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV8SDT_MobilePage = new SdtSDT_MobilePage(context);
         P00902_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00902_A29LocationId = new Guid[] {Guid.Empty} ;
         P00902_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         P00902_A420PageJsonContent = new string[] {""} ;
         P00902_n420PageJsonContent = new bool[] {false} ;
         P00902_A397Trn_PageName = new string[] {""} ;
         P00902_A423PageIsPublished = new bool[] {false} ;
         P00902_n423PageIsPublished = new bool[] {false} ;
         P00902_A429PageIsContentPage = new bool[] {false} ;
         P00902_n429PageIsContentPage = new bool[] {false} ;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A392Trn_PageId = Guid.Empty;
         A420PageJsonContent = "";
         A397Trn_PageName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_pageapi__default(),
            new Object[][] {
                new Object[] {
               P00902_A11OrganisationId, P00902_A29LocationId, P00902_A392Trn_PageId, P00902_A420PageJsonContent, P00902_n420PageJsonContent, P00902_A397Trn_PageName, P00902_A423PageIsPublished, P00902_n423PageIsPublished, P00902_A429PageIsContentPage, P00902_n429PageIsContentPage
               }
            }
         );
         /* GeneXus formulas. */
      }

      private bool n420PageJsonContent ;
      private bool A423PageIsPublished ;
      private bool n423PageIsPublished ;
      private bool A429PageIsContentPage ;
      private bool n429PageIsContentPage ;
      private string A420PageJsonContent ;
      private string AV14UserId ;
      private string A397Trn_PageName ;
      private Guid AV11PageId ;
      private Guid AV10LocationId ;
      private Guid AV9OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A392Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_MobilePage AV8SDT_MobilePage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00902_A11OrganisationId ;
      private Guid[] P00902_A29LocationId ;
      private Guid[] P00902_A392Trn_PageId ;
      private string[] P00902_A420PageJsonContent ;
      private bool[] P00902_n420PageJsonContent ;
      private string[] P00902_A397Trn_PageName ;
      private bool[] P00902_A423PageIsPublished ;
      private bool[] P00902_n423PageIsPublished ;
      private bool[] P00902_A429PageIsContentPage ;
      private bool[] P00902_n429PageIsContentPage ;
      private SdtSDT_MobilePage aP4_SDT_MobilePage ;
   }

   public class prc_pageapi__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00902;
          prmP00902 = new Object[] {
          new ParDef("AV11PageId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00902", "SELECT OrganisationId, LocationId, Trn_PageId, PageJsonContent, Trn_PageName, PageIsPublished, PageIsContentPage FROM Trn_Page WHERE (Trn_PageId = :AV11PageId and LocationId = :AV10LocationId) AND (OrganisationId = :AV9OrganisationId) ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00902,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.getBool(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((bool[]) buf[8])[0] = rslt.getBool(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
