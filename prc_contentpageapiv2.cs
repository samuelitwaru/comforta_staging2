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
   public class prc_contentpageapiv2 : GXProcedure
   {
      public prc_contentpageapiv2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_contentpageapiv2( IGxContext context )
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
                           out SdtSDT_ContentPageV1 aP3_SDT_ContentPageV1 )
      {
         this.AV9PageId = aP0_PageId;
         this.AV10LocationId = aP1_LocationId;
         this.AV8OrganisationId = aP2_OrganisationId;
         this.AV20SDT_ContentPageV1 = new SdtSDT_ContentPageV1(context) ;
         initialize();
         ExecuteImpl();
         aP3_SDT_ContentPageV1=this.AV20SDT_ContentPageV1;
      }

      public SdtSDT_ContentPageV1 executeUdp( Guid aP0_PageId ,
                                              Guid aP1_LocationId ,
                                              Guid aP2_OrganisationId )
      {
         execute(aP0_PageId, aP1_LocationId, aP2_OrganisationId, out aP3_SDT_ContentPageV1);
         return AV20SDT_ContentPageV1 ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 Guid aP1_LocationId ,
                                 Guid aP2_OrganisationId ,
                                 out SdtSDT_ContentPageV1 aP3_SDT_ContentPageV1 )
      {
         this.AV9PageId = aP0_PageId;
         this.AV10LocationId = aP1_LocationId;
         this.AV8OrganisationId = aP2_OrganisationId;
         this.AV20SDT_ContentPageV1 = new SdtSDT_ContentPageV1(context) ;
         SubmitImpl();
         aP3_SDT_ContentPageV1=this.AV20SDT_ContentPageV1;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DM2 */
         pr_default.execute(0, new Object[] {AV10LocationId, AV8OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00DM2_A523AppVersionId[0];
            A535IsActive = P00DM2_A535IsActive[0];
            A11OrganisationId = P00DM2_A11OrganisationId[0];
            n11OrganisationId = P00DM2_n11OrganisationId[0];
            A29LocationId = P00DM2_A29LocationId[0];
            n29LocationId = P00DM2_n29LocationId[0];
            /* Using cursor P00DM3 */
            pr_default.execute(1, new Object[] {A523AppVersionId, AV9PageId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A525PageType = P00DM3_A525PageType[0];
               A516PageId = P00DM3_A516PageId[0];
               A517PageName = P00DM3_A517PageName[0];
               A536PagePublishedStructure = P00DM3_A536PagePublishedStructure[0];
               AV22PageName = A517PageName;
               AV11SDT_ContentPage.FromJSonString(A536PagePublishedStructure, null);
               if ( StringUtil.StrCmp(A525PageType, "Content") == 0 )
               {
                  AV12BC_Trn_ProductService.Load(AV9PageId, AV10LocationId, AV8OrganisationId);
                  AV25GXV1 = 1;
                  while ( AV25GXV1 <= AV11SDT_ContentPage.gxTpr_Content.Count )
                  {
                     AV15ContentItem = ((SdtSDT_ContentPage_ContentItem)AV11SDT_ContentPage.gxTpr_Content.Item(AV25GXV1));
                     if ( StringUtil.StrCmp(AV15ContentItem.gxTpr_Contenttype, context.GetMessage( "Image", "")) == 0 )
                     {
                        AV15ContentItem.gxTpr_Contentvalue = AV12BC_Trn_ProductService.gxTpr_Productserviceimage_gxi;
                     }
                     else if ( StringUtil.StrCmp(AV15ContentItem.gxTpr_Contenttype, context.GetMessage( "Description", "")) == 0 )
                     {
                        AV15ContentItem.gxTpr_Contentvalue = AV12BC_Trn_ProductService.gxTpr_Productservicedescription;
                     }
                     else
                     {
                     }
                     AV25GXV1 = (int)(AV25GXV1+1);
                  }
                  AV26GXV2 = 1;
                  while ( AV26GXV2 <= AV11SDT_ContentPage.gxTpr_Cta.Count )
                  {
                     AV16CtaItem = ((SdtSDT_ContentPage_CtaItem)AV11SDT_ContentPage.gxTpr_Cta.Item(AV26GXV2));
                     AV13BC_Trn_CallToAction.Load(StringUtil.StrToGuid( AV16CtaItem.gxTpr_Ctaid));
                     if ( StringUtil.StrCmp(AV13BC_Trn_CallToAction.gxTpr_Calltoactiontype, "Phone") == 0 )
                     {
                        AV16CtaItem.gxTpr_Ctaaction = AV13BC_Trn_CallToAction.gxTpr_Calltoactionphone;
                     }
                     else if ( StringUtil.StrCmp(AV13BC_Trn_CallToAction.gxTpr_Calltoactiontype, "Form") == 0 )
                     {
                        AV16CtaItem.gxTpr_Ctaaction = AV13BC_Trn_CallToAction.gxTpr_Calltoactionurl;
                     }
                     else if ( StringUtil.StrCmp(AV13BC_Trn_CallToAction.gxTpr_Calltoactiontype, "SiteUrl") == 0 )
                     {
                        AV16CtaItem.gxTpr_Ctaaction = AV13BC_Trn_CallToAction.gxTpr_Calltoactionurl;
                     }
                     else if ( StringUtil.StrCmp(AV13BC_Trn_CallToAction.gxTpr_Calltoactiontype, "Email") == 0 )
                     {
                        AV16CtaItem.gxTpr_Ctaaction = AV13BC_Trn_CallToAction.gxTpr_Calltoactionemail;
                     }
                     else
                     {
                     }
                     AV26GXV2 = (int)(AV26GXV2+1);
                  }
               }
               if ( ( ( StringUtil.StrCmp(A525PageType, "Location") == 0 ) ) || ( ( StringUtil.StrCmp(A525PageType, "Reception") == 0 ) ) )
               {
                  if ( StringUtil.StrCmp(A525PageType, "Location") == 0 )
                  {
                     AV14BC_Trn_Location.Load(AV10LocationId, AV8OrganisationId);
                     AV11SDT_ContentPage.gxTpr_Content.Clear();
                     AV15ContentItem = new SdtSDT_ContentPage_ContentItem(context);
                     AV15ContentItem.gxTpr_Contenttype = context.GetMessage( "Image", "");
                     AV15ContentItem.gxTpr_Contentvalue = AV14BC_Trn_Location.gxTpr_Locationimage_gxi;
                     AV11SDT_ContentPage.gxTpr_Content.Add(AV15ContentItem, 0);
                     AV15ContentItem = new SdtSDT_ContentPage_ContentItem(context);
                     AV15ContentItem.gxTpr_Contenttype = context.GetMessage( "Description", "");
                     AV15ContentItem.gxTpr_Contentvalue = AV14BC_Trn_Location.gxTpr_Locationdescription;
                     AV11SDT_ContentPage.gxTpr_Content.Add(AV15ContentItem, 0);
                  }
                  if ( StringUtil.StrCmp(A525PageType, "Reception") == 0 )
                  {
                     AV14BC_Trn_Location.Load(AV10LocationId, AV8OrganisationId);
                     AV11SDT_ContentPage.gxTpr_Content.Clear();
                     AV15ContentItem = new SdtSDT_ContentPage_ContentItem(context);
                     AV15ContentItem.gxTpr_Contenttype = context.GetMessage( "Image", "");
                     AV15ContentItem.gxTpr_Contentvalue = AV14BC_Trn_Location.gxTpr_Receptionimage_gxi;
                     AV11SDT_ContentPage.gxTpr_Content.Add(AV15ContentItem, 0);
                     AV15ContentItem = new SdtSDT_ContentPage_ContentItem(context);
                     AV15ContentItem.gxTpr_Contenttype = context.GetMessage( "Description", "");
                     AV15ContentItem.gxTpr_Contentvalue = AV14BC_Trn_Location.gxTpr_Receptiondescription;
                     AV11SDT_ContentPage.gxTpr_Content.Add(AV15ContentItem, 0);
                  }
                  AV11SDT_ContentPage.gxTpr_Cta.Clear();
                  AV16CtaItem = new SdtSDT_ContentPage_CtaItem(context);
                  AV16CtaItem.gxTpr_Ctaid = Guid.NewGuid( ).ToString();
                  AV16CtaItem.gxTpr_Ctalabel = "CALL US";
                  AV16CtaItem.gxTpr_Ctabgcolor = "#5068a8";
                  AV16CtaItem.gxTpr_Ctatype = "Phone";
                  AV16CtaItem.gxTpr_Ctaaction = AV14BC_Trn_Location.gxTpr_Locationphone;
                  AV11SDT_ContentPage.gxTpr_Cta.Add(AV16CtaItem, 0);
                  AV16CtaItem = new SdtSDT_ContentPage_CtaItem(context);
                  AV16CtaItem.gxTpr_Ctaid = Guid.NewGuid( ).ToString();
                  AV16CtaItem.gxTpr_Ctalabel = "EMAIL US";
                  AV16CtaItem.gxTpr_Ctabgcolor = "#5068a8";
                  AV16CtaItem.gxTpr_Ctatype = "Email";
                  AV16CtaItem.gxTpr_Ctaaction = AV14BC_Trn_Location.gxTpr_Locationphone;
                  AV11SDT_ContentPage.gxTpr_Cta.Add(AV16CtaItem, 0);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         GXt_SdtSDT_ContentPageV11 = AV20SDT_ContentPageV1;
         new prc_convertnewtooldcontentstructure(context ).execute(  AV11SDT_ContentPage,  AV9PageId,  AV22PageName, out  GXt_SdtSDT_ContentPageV11) ;
         AV20SDT_ContentPageV1 = GXt_SdtSDT_ContentPageV11;
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
         AV20SDT_ContentPageV1 = new SdtSDT_ContentPageV1(context);
         P00DM2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DM2_A535IsActive = new bool[] {false} ;
         P00DM2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DM2_n11OrganisationId = new bool[] {false} ;
         P00DM2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DM2_n29LocationId = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         P00DM3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00DM3_A525PageType = new string[] {""} ;
         P00DM3_A516PageId = new Guid[] {Guid.Empty} ;
         P00DM3_A517PageName = new string[] {""} ;
         P00DM3_A536PagePublishedStructure = new string[] {""} ;
         A525PageType = "";
         A516PageId = Guid.Empty;
         A517PageName = "";
         A536PagePublishedStructure = "";
         AV22PageName = "";
         AV11SDT_ContentPage = new SdtSDT_ContentPage(context);
         AV12BC_Trn_ProductService = new SdtTrn_ProductService(context);
         AV15ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV16CtaItem = new SdtSDT_ContentPage_CtaItem(context);
         AV13BC_Trn_CallToAction = new SdtTrn_CallToAction(context);
         AV14BC_Trn_Location = new SdtTrn_Location(context);
         GXt_SdtSDT_ContentPageV11 = new SdtSDT_ContentPageV1(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_contentpageapiv2__default(),
            new Object[][] {
                new Object[] {
               P00DM2_A523AppVersionId, P00DM2_A535IsActive, P00DM2_A11OrganisationId, P00DM2_n11OrganisationId, P00DM2_A29LocationId, P00DM2_n29LocationId
               }
               , new Object[] {
               P00DM3_A523AppVersionId, P00DM3_A525PageType, P00DM3_A516PageId, P00DM3_A517PageName, P00DM3_A536PagePublishedStructure
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV25GXV1 ;
      private int AV26GXV2 ;
      private bool A535IsActive ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private string A536PagePublishedStructure ;
      private string A525PageType ;
      private string A517PageName ;
      private string AV22PageName ;
      private Guid AV9PageId ;
      private Guid AV10LocationId ;
      private Guid AV8OrganisationId ;
      private Guid A523AppVersionId ;
      private Guid A11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_ContentPageV1 AV20SDT_ContentPageV1 ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DM2_A523AppVersionId ;
      private bool[] P00DM2_A535IsActive ;
      private Guid[] P00DM2_A11OrganisationId ;
      private bool[] P00DM2_n11OrganisationId ;
      private Guid[] P00DM2_A29LocationId ;
      private bool[] P00DM2_n29LocationId ;
      private Guid[] P00DM3_A523AppVersionId ;
      private string[] P00DM3_A525PageType ;
      private Guid[] P00DM3_A516PageId ;
      private string[] P00DM3_A517PageName ;
      private string[] P00DM3_A536PagePublishedStructure ;
      private SdtSDT_ContentPage AV11SDT_ContentPage ;
      private SdtTrn_ProductService AV12BC_Trn_ProductService ;
      private SdtSDT_ContentPage_ContentItem AV15ContentItem ;
      private SdtSDT_ContentPage_CtaItem AV16CtaItem ;
      private SdtTrn_CallToAction AV13BC_Trn_CallToAction ;
      private SdtTrn_Location AV14BC_Trn_Location ;
      private SdtSDT_ContentPageV1 GXt_SdtSDT_ContentPageV11 ;
      private SdtSDT_ContentPageV1 aP3_SDT_ContentPageV1 ;
   }

   public class prc_contentpageapiv2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DM2;
          prmP00DM2 = new Object[] {
          new ParDef("AV10LocationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8OrganisationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00DM3;
          prmP00DM3 = new Object[] {
          new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DM2", "SELECT AppVersionId, IsActive, OrganisationId, LocationId FROM Trn_AppVersion WHERE (LocationId = :AV10LocationId and OrganisationId = :AV8OrganisationId) AND (IsActive = TRUE) ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DM2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DM3", "SELECT AppVersionId, PageType, PageId, PageName, PagePublishedStructure FROM Trn_AppVersionPage WHERE (AppVersionId = :AppVersionId and PageId = :AV9PageId) AND (( PageType = ( 'Content')) or ( PageType = ( 'Reception')) or ( PageType = ( 'Location'))) ORDER BY AppVersionId, PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DM3,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
       }
    }

 }

}
