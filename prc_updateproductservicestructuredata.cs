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
   public class prc_updateproductservicestructuredata : GXProcedure
   {
      public prc_updateproductservicestructuredata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updateproductservicestructuredata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_ProductServiceId ,
                           SdtSDT_ContentPage aP1_SDT_ContentPage ,
                           out SdtSDT_ContentPage aP2_Update_SDT_ContentPage )
      {
         this.AV8ProductServiceId = aP0_ProductServiceId;
         this.AV9SDT_ContentPage = aP1_SDT_ContentPage;
         this.AV10Update_SDT_ContentPage = new SdtSDT_ContentPage(context) ;
         initialize();
         ExecuteImpl();
         aP2_Update_SDT_ContentPage=this.AV10Update_SDT_ContentPage;
      }

      public SdtSDT_ContentPage executeUdp( Guid aP0_ProductServiceId ,
                                            SdtSDT_ContentPage aP1_SDT_ContentPage )
      {
         execute(aP0_ProductServiceId, aP1_SDT_ContentPage, out aP2_Update_SDT_ContentPage);
         return AV10Update_SDT_ContentPage ;
      }

      public void executeSubmit( Guid aP0_ProductServiceId ,
                                 SdtSDT_ContentPage aP1_SDT_ContentPage ,
                                 out SdtSDT_ContentPage aP2_Update_SDT_ContentPage )
      {
         this.AV8ProductServiceId = aP0_ProductServiceId;
         this.AV9SDT_ContentPage = aP1_SDT_ContentPage;
         this.AV10Update_SDT_ContentPage = new SdtSDT_ContentPage(context) ;
         SubmitImpl();
         aP2_Update_SDT_ContentPage=this.AV10Update_SDT_ContentPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Update_SDT_ContentPage.FromJSonString(AV9SDT_ContentPage.ToJSonString(false, true), null);
         /* Using cursor P00BF2 */
         pr_default.execute(0, new Object[] {AV8ProductServiceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A58ProductServiceId = P00BF2_A58ProductServiceId[0];
            A40000ProductServiceImage_GXI = P00BF2_A40000ProductServiceImage_GXI[0];
            A60ProductServiceDescription = P00BF2_A60ProductServiceDescription[0];
            A29LocationId = P00BF2_A29LocationId[0];
            A11OrganisationId = P00BF2_A11OrganisationId[0];
            AV10Update_SDT_ContentPage.gxTpr_Content.Clear();
            AV14GXV1 = 1;
            while ( AV14GXV1 <= AV9SDT_ContentPage.gxTpr_Content.Count )
            {
               AV11ContentItem = ((SdtSDT_ContentPage_ContentItem)AV9SDT_ContentPage.gxTpr_Content.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV11ContentItem.gxTpr_Contenttype, context.GetMessage( "Image", "")) == 0 )
               {
                  AV11ContentItem.gxTpr_Contentvalue = A40000ProductServiceImage_GXI;
               }
               else if ( StringUtil.StrCmp(AV11ContentItem.gxTpr_Contenttype, context.GetMessage( "Description", "")) == 0 )
               {
                  AV11ContentItem.gxTpr_Contentvalue = A60ProductServiceDescription;
               }
               else
               {
               }
               AV10Update_SDT_ContentPage.gxTpr_Content.Add(AV11ContentItem, 0);
               AV14GXV1 = (int)(AV14GXV1+1);
            }
            pr_default.readNext(0);
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
         AV10Update_SDT_ContentPage = new SdtSDT_ContentPage(context);
         P00BF2_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00BF2_A40000ProductServiceImage_GXI = new string[] {""} ;
         P00BF2_A60ProductServiceDescription = new string[] {""} ;
         P00BF2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BF2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         A58ProductServiceId = Guid.Empty;
         A40000ProductServiceImage_GXI = "";
         A60ProductServiceDescription = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV11ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updateproductservicestructuredata__default(),
            new Object[][] {
                new Object[] {
               P00BF2_A58ProductServiceId, P00BF2_A40000ProductServiceImage_GXI, P00BF2_A60ProductServiceDescription, P00BF2_A29LocationId, P00BF2_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV14GXV1 ;
      private string A60ProductServiceDescription ;
      private string A40000ProductServiceImage_GXI ;
      private Guid AV8ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_ContentPage AV9SDT_ContentPage ;
      private SdtSDT_ContentPage AV10Update_SDT_ContentPage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BF2_A58ProductServiceId ;
      private string[] P00BF2_A40000ProductServiceImage_GXI ;
      private string[] P00BF2_A60ProductServiceDescription ;
      private Guid[] P00BF2_A29LocationId ;
      private Guid[] P00BF2_A11OrganisationId ;
      private SdtSDT_ContentPage_ContentItem AV11ContentItem ;
      private SdtSDT_ContentPage aP2_Update_SDT_ContentPage ;
   }

   public class prc_updateproductservicestructuredata__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BF2;
          prmP00BF2 = new Object[] {
          new ParDef("AV8ProductServiceId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BF2", "SELECT ProductServiceId, ProductServiceImage_GXI, ProductServiceDescription, LocationId, OrganisationId FROM Trn_ProductService WHERE ProductServiceId = :AV8ProductServiceId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
