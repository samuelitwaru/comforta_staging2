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
   public class prc_updatecontentpagestructure : GXProcedure
   {
      public prc_updatecontentpagestructure( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatecontentpagestructure( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PageId ,
                           ref SdtSDT_ContentPage aP1_SDT_ContentPage )
      {
         this.AV17PageId = aP0_PageId;
         this.AV9SDT_ContentPage = aP1_SDT_ContentPage;
         initialize();
         ExecuteImpl();
         aP1_SDT_ContentPage=this.AV9SDT_ContentPage;
      }

      public SdtSDT_ContentPage executeUdp( Guid aP0_PageId )
      {
         execute(aP0_PageId, ref aP1_SDT_ContentPage);
         return AV9SDT_ContentPage ;
      }

      public void executeSubmit( Guid aP0_PageId ,
                                 ref SdtSDT_ContentPage aP1_SDT_ContentPage )
      {
         this.AV17PageId = aP0_PageId;
         this.AV9SDT_ContentPage = aP1_SDT_ContentPage;
         SubmitImpl();
         aP1_SDT_ContentPage=this.AV9SDT_ContentPage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00BF2 */
         pr_default.execute(0, new Object[] {AV17PageId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00BF2_A523AppVersionId[0];
            A516PageId = P00BF2_A516PageId[0];
            A525PageType = P00BF2_A525PageType[0];
            A517PageName = P00BF2_A517PageName[0];
            A29LocationId = P00BF2_A29LocationId[0];
            n29LocationId = P00BF2_n29LocationId[0];
            A11OrganisationId = P00BF2_A11OrganisationId[0];
            n11OrganisationId = P00BF2_n11OrganisationId[0];
            A29LocationId = P00BF2_A29LocationId[0];
            n29LocationId = P00BF2_n29LocationId[0];
            A11OrganisationId = P00BF2_A11OrganisationId[0];
            n11OrganisationId = P00BF2_n11OrganisationId[0];
            AV13PageType = A525PageType;
            AV19PageName = A517PageName;
            AV14LocationId = A29LocationId;
            AV18OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new prc_logtoserver(context ).execute(  "PageType: "+AV13PageType) ;
         new prc_logtoserver(context ).execute(  "PageName: "+AV19PageName) ;
         new prc_logtoserver(context ).execute(  "Location: "+AV14LocationId.ToString()) ;
         new prc_logtoserver(context ).execute(  "Organisation: "+AV18OrganisationId.ToString()) ;
         if ( StringUtil.StrCmp(AV13PageType, "Content") == 0 )
         {
            /* Execute user subroutine: 'UPDATESERVICEPAGE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV13PageType, "Location") == 0 )
         {
            /* Execute user subroutine: 'UPDATELOCATIONPAGE' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV13PageType, "Reception") == 0 )
         {
            /* Execute user subroutine: 'UPDATERECEPTIONPAGE' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else
         {
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'UPDATESERVICEPAGE' Routine */
         returnInSub = false;
         /* Using cursor P00BF3 */
         pr_default.execute(1, new Object[] {AV17PageId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A58ProductServiceId = P00BF3_A58ProductServiceId[0];
            A40000ProductServiceImage_GXI = P00BF3_A40000ProductServiceImage_GXI[0];
            A60ProductServiceDescription = P00BF3_A60ProductServiceDescription[0];
            A29LocationId = P00BF3_A29LocationId[0];
            n29LocationId = P00BF3_n29LocationId[0];
            A11OrganisationId = P00BF3_A11OrganisationId[0];
            n11OrganisationId = P00BF3_n11OrganisationId[0];
            AV22GXV1 = 1;
            while ( AV22GXV1 <= AV9SDT_ContentPage.gxTpr_Content.Count )
            {
               AV11ContentItem = ((SdtSDT_ContentPage_ContentItem)AV9SDT_ContentPage.gxTpr_Content.Item(AV22GXV1));
               if ( StringUtil.StrCmp(AV11ContentItem.gxTpr_Contenttype, "Image") == 0 )
               {
                  AV11ContentItem.gxTpr_Contentvalue = A40000ProductServiceImage_GXI;
               }
               else if ( StringUtil.StrCmp(AV11ContentItem.gxTpr_Contenttype, "Description") == 0 )
               {
                  GXt_char1 = "";
                  new prc_getdynamictransation(context ).execute(  "Trn_ProductService",  AV17PageId,  "ProductServiceDescription",  "",  A60ProductServiceDescription, out  GXt_char1) ;
                  AV11ContentItem.gxTpr_Contentvalue = GXt_char1;
               }
               else
               {
               }
               AV22GXV1 = (int)(AV22GXV1+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'UPDATELOCATIONPAGE' Routine */
         returnInSub = false;
         AV23GXV2 = 1;
         while ( AV23GXV2 <= AV9SDT_ContentPage.gxTpr_Content.Count )
         {
            AV11ContentItem = ((SdtSDT_ContentPage_ContentItem)AV9SDT_ContentPage.gxTpr_Content.Item(AV23GXV2));
            if ( StringUtil.StrCmp(AV11ContentItem.gxTpr_Contenttype, "Image") == 0 )
            {
               AV11ContentItem.gxTpr_Contentvalue = A40000ProductServiceImage_GXI;
            }
            else if ( StringUtil.StrCmp(AV11ContentItem.gxTpr_Contenttype, "Description") == 0 )
            {
               GXt_char1 = "";
               new prc_getdynamictransation(context ).execute(  context.GetMessage( "Trn_Location", ""),  AV14LocationId,  context.GetMessage( "LocationDescription", ""),  "",  AV16BC_Trn_Location.gxTpr_Locationdescription, out  GXt_char1) ;
               AV11ContentItem.gxTpr_Contentvalue = GXt_char1;
            }
            else
            {
            }
            AV23GXV2 = (int)(AV23GXV2+1);
         }
      }

      protected void S131( )
      {
         /* 'UPDATERECEPTIONPAGE' Routine */
         returnInSub = false;
         AV24GXV3 = 1;
         while ( AV24GXV3 <= AV9SDT_ContentPage.gxTpr_Content.Count )
         {
            AV11ContentItem = ((SdtSDT_ContentPage_ContentItem)AV9SDT_ContentPage.gxTpr_Content.Item(AV24GXV3));
            if ( StringUtil.StrCmp(AV11ContentItem.gxTpr_Contenttype, "Image") == 0 )
            {
               AV11ContentItem.gxTpr_Contentvalue = A40000ProductServiceImage_GXI;
            }
            else if ( StringUtil.StrCmp(AV11ContentItem.gxTpr_Contenttype, "Description") == 0 )
            {
               GXt_char1 = "";
               new prc_getdynamictransation(context ).execute(  context.GetMessage( "Trn_Location", ""),  AV14LocationId,  context.GetMessage( "ReceptionDescription", ""),  "",  AV16BC_Trn_Location.gxTpr_Receptiondescription, out  GXt_char1) ;
               AV11ContentItem.gxTpr_Contentvalue = GXt_char1;
            }
            else
            {
            }
            AV24GXV3 = (int)(AV24GXV3+1);
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
         P00BF2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00BF2_A516PageId = new Guid[] {Guid.Empty} ;
         P00BF2_A525PageType = new string[] {""} ;
         P00BF2_A517PageName = new string[] {""} ;
         P00BF2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BF2_n29LocationId = new bool[] {false} ;
         P00BF2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BF2_n11OrganisationId = new bool[] {false} ;
         A523AppVersionId = Guid.Empty;
         A516PageId = Guid.Empty;
         A525PageType = "";
         A517PageName = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV13PageType = "";
         AV19PageName = "";
         AV14LocationId = Guid.Empty;
         AV18OrganisationId = Guid.Empty;
         P00BF3_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         P00BF3_A40000ProductServiceImage_GXI = new string[] {""} ;
         P00BF3_A60ProductServiceDescription = new string[] {""} ;
         P00BF3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00BF3_n29LocationId = new bool[] {false} ;
         P00BF3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00BF3_n11OrganisationId = new bool[] {false} ;
         A58ProductServiceId = Guid.Empty;
         A40000ProductServiceImage_GXI = "";
         A60ProductServiceDescription = "";
         AV11ContentItem = new SdtSDT_ContentPage_ContentItem(context);
         AV16BC_Trn_Location = new SdtTrn_Location(context);
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatecontentpagestructure__default(),
            new Object[][] {
                new Object[] {
               P00BF2_A523AppVersionId, P00BF2_A516PageId, P00BF2_A525PageType, P00BF2_A517PageName, P00BF2_A29LocationId, P00BF2_n29LocationId, P00BF2_A11OrganisationId, P00BF2_n11OrganisationId
               }
               , new Object[] {
               P00BF3_A58ProductServiceId, P00BF3_A40000ProductServiceImage_GXI, P00BF3_A60ProductServiceDescription, P00BF3_A29LocationId, P00BF3_A11OrganisationId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private int AV24GXV3 ;
      private string GXt_char1 ;
      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private bool returnInSub ;
      private string A60ProductServiceDescription ;
      private string A525PageType ;
      private string A517PageName ;
      private string AV13PageType ;
      private string AV19PageName ;
      private string A40000ProductServiceImage_GXI ;
      private Guid AV17PageId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV14LocationId ;
      private Guid AV18OrganisationId ;
      private Guid A58ProductServiceId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_ContentPage AV9SDT_ContentPage ;
      private SdtSDT_ContentPage aP1_SDT_ContentPage ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BF2_A523AppVersionId ;
      private Guid[] P00BF2_A516PageId ;
      private string[] P00BF2_A525PageType ;
      private string[] P00BF2_A517PageName ;
      private Guid[] P00BF2_A29LocationId ;
      private bool[] P00BF2_n29LocationId ;
      private Guid[] P00BF2_A11OrganisationId ;
      private bool[] P00BF2_n11OrganisationId ;
      private Guid[] P00BF3_A58ProductServiceId ;
      private string[] P00BF3_A40000ProductServiceImage_GXI ;
      private string[] P00BF3_A60ProductServiceDescription ;
      private Guid[] P00BF3_A29LocationId ;
      private bool[] P00BF3_n29LocationId ;
      private Guid[] P00BF3_A11OrganisationId ;
      private bool[] P00BF3_n11OrganisationId ;
      private SdtSDT_ContentPage_ContentItem AV11ContentItem ;
      private SdtTrn_Location AV16BC_Trn_Location ;
   }

   public class prc_updatecontentpagestructure__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BF2;
          prmP00BF2 = new Object[] {
          new ParDef("AV17PageId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00BF3;
          prmP00BF3 = new Object[] {
          new ParDef("AV17PageId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BF2", "SELECT T1.AppVersionId, T1.PageId, T1.PageType, T1.PageName, T2.LocationId, T2.OrganisationId FROM (Trn_AppVersionPage T1 INNER JOIN Trn_AppVersion T2 ON T2.AppVersionId = T1.AppVersionId) WHERE T1.PageId = :AV17PageId ORDER BY T1.AppVersionId, T1.PageId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BF3", "SELECT ProductServiceId, ProductServiceImage_GXI, ProductServiceDescription, LocationId, OrganisationId FROM Trn_ProductService WHERE ProductServiceId = :AV17PageId ORDER BY ProductServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BF3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((Guid[]) buf[6])[0] = rslt.getGuid(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                return;
             case 1 :
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
