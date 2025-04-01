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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_migratepages : GXProcedure
   {
      public prc_migratepages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_migratepages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId )
      {
         this.AV8LocationId = aP0_LocationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_LocationId )
      {
         this.AV8LocationId = aP0_LocationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prc_logtoserver(context ).execute(  context.GetMessage( "Location: ", "")+AV8LocationId.ToString()) ;
         /* Using cursor P00DD2 */
         pr_default.execute(0, new Object[] {AV8LocationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A29LocationId = P00DD2_A29LocationId[0];
            n29LocationId = P00DD2_n29LocationId[0];
            A11OrganisationId = P00DD2_A11OrganisationId[0];
            n11OrganisationId = P00DD2_n11OrganisationId[0];
            AV15OrganisationId = A11OrganisationId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         new prc_logtoserver(context ).execute(  context.GetMessage( "Organisation: ", "")+AV15OrganisationId.ToString()) ;
         AV28GXLvl15 = 0;
         /* Using cursor P00DD3 */
         pr_default.execute(1, new Object[] {AV8LocationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A29LocationId = P00DD3_A29LocationId[0];
            n29LocationId = P00DD3_n29LocationId[0];
            A523AppVersionId = P00DD3_A523AppVersionId[0];
            AV28GXLvl15 = 1;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV28GXLvl15 == 0 )
         {
            new prc_logtoserver(context ).execute(  context.GetMessage( "	creating appversion...", "")) ;
            /* Execute user subroutine: 'CREATEAPPVERSION' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CREATEAPPVERSION' Routine */
         returnInSub = false;
         AV9BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV9BC_Trn_AppVersion.gxTpr_Appversionname = context.GetMessage( "Version 1", "");
         AV9BC_Trn_AppVersion.gxTpr_Organisationid = AV15OrganisationId;
         AV9BC_Trn_AppVersion.gxTpr_Locationid = AV8LocationId;
         AV9BC_Trn_AppVersion.gxTpr_Isactive = true;
         AV16BC_WebLinkPage.gxTpr_Pageid = Guid.NewGuid( );
         AV16BC_WebLinkPage.gxTpr_Pagename = context.GetMessage( "Web Link", "");
         AV16BC_WebLinkPage.gxTpr_Ispredefined = true;
         AV16BC_WebLinkPage.gxTpr_Pagetype = "WebLink";
         AV9BC_Trn_AppVersion.gxTpr_Page.Add(AV16BC_WebLinkPage, 0);
         AV17BC_DynamicFormPage.gxTpr_Pageid = Guid.NewGuid( );
         AV17BC_DynamicFormPage.gxTpr_Pagename = context.GetMessage( "Dynamic Form", "");
         AV17BC_DynamicFormPage.gxTpr_Ispredefined = true;
         AV17BC_DynamicFormPage.gxTpr_Pagetype = "DynamicForm";
         AV9BC_Trn_AppVersion.gxTpr_Page.Add(AV17BC_DynamicFormPage, 0);
         GXt_SdtTrn_AppVersion_Page1 = AV18BC_ReceptionPage;
         new prc_initreceptionpage(context ).execute( ref  AV8LocationId, ref  AV15OrganisationId, out  GXt_SdtTrn_AppVersion_Page1) ;
         AV18BC_ReceptionPage = GXt_SdtTrn_AppVersion_Page1;
         AV9BC_Trn_AppVersion.gxTpr_Page.Add(AV18BC_ReceptionPage, 0);
         GXt_SdtTrn_AppVersion_Page1 = AV19BC_LocationPage;
         new prc_initlocationpage(context ).execute( ref  AV8LocationId, ref  AV15OrganisationId, out  GXt_SdtTrn_AppVersion_Page1) ;
         AV19BC_LocationPage = GXt_SdtTrn_AppVersion_Page1;
         AV9BC_Trn_AppVersion.gxTpr_Page.Add(AV19BC_LocationPage, 0);
         new prc_initservicepages(context ).execute( out  AV20BC_CarePage, out  AV21BC_LivingPage, out  AV22BC_ServicesPage) ;
         AV9BC_Trn_AppVersion.gxTpr_Page.Add(AV20BC_CarePage, 0);
         AV9BC_Trn_AppVersion.gxTpr_Page.Add(AV21BC_LivingPage, 0);
         AV9BC_Trn_AppVersion.gxTpr_Page.Add(AV22BC_ServicesPage, 0);
         AV23BC_MapsPage.gxTpr_Pageid = Guid.NewGuid( );
         AV23BC_MapsPage.gxTpr_Pagename = context.GetMessage( "Maps", "");
         AV23BC_MapsPage.gxTpr_Ispredefined = true;
         AV23BC_MapsPage.gxTpr_Pagetype = "Maps";
         AV9BC_Trn_AppVersion.gxTpr_Page.Add(AV23BC_MapsPage, 0);
         AV26SkipPageNameCollection.FromJSonString(context.GetMessage( "[\"Reception\", \"Location\", \"Calendar\", \"My Activity\", \"Mailbox\"]", ""), null);
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A397Trn_PageName ,
                                              AV26SkipPageNameCollection ,
                                              A29LocationId ,
                                              AV8LocationId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00DD4 */
         pr_default.execute(2, new Object[] {AV8LocationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A397Trn_PageName = P00DD4_A397Trn_PageName[0];
            A29LocationId = P00DD4_A29LocationId[0];
            n29LocationId = P00DD4_n29LocationId[0];
            A392Trn_PageId = P00DD4_A392Trn_PageId[0];
            new prc_logtoserver(context ).execute(  context.GetMessage( "        PageName: ", "")+A397Trn_PageName) ;
            AV12BC_Trn_Page = new SdtTrn_Page(context);
            AV10BC_Page = new SdtTrn_AppVersion_Page(context);
            AV12BC_Trn_Page.Load(A392Trn_PageId, AV8LocationId);
            new prc_logtoserver(context ).execute(  context.GetMessage( "        Page: ", "")+AV12BC_Trn_Page.ToJSonString(true, true)) ;
            GXt_SdtTrn_AppVersion_Page1 = AV10BC_Page;
            new prc_convertpage(context ).execute(  AV12BC_Trn_Page,  AV18BC_ReceptionPage.gxTpr_Pageid,  AV19BC_LocationPage.gxTpr_Pageid,  AV20BC_CarePage.gxTpr_Pageid,  AV21BC_LivingPage.gxTpr_Pageid,  AV22BC_ServicesPage.gxTpr_Pageid,  AV24BC_MyActivityPage.gxTpr_Pageid,  AV25BC_CalendarPage.gxTpr_Pageid,  AV23BC_MapsPage.gxTpr_Pageid,  AV16BC_WebLinkPage.gxTpr_Pageid,  AV17BC_DynamicFormPage.gxTpr_Pageid, out  GXt_SdtTrn_AppVersion_Page1) ;
            AV10BC_Page = GXt_SdtTrn_AppVersion_Page1;
            new prc_logtoserver(context ).execute(  context.GetMessage( "        New Page: ", "")+AV10BC_Page.ToJSonString(true, true)) ;
            AV9BC_Trn_AppVersion.gxTpr_Page.Add(AV10BC_Page, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         new prc_logtoserver(context ).execute(  AV9BC_Trn_AppVersion.ToJSonString(true, true)) ;
         AV9BC_Trn_AppVersion.Save();
         if ( AV9BC_Trn_AppVersion.Success() )
         {
            context.CommitDataStores("prc_migratepages",pr_default);
         }
         else
         {
            AV31GXV2 = 1;
            AV30GXV1 = AV9BC_Trn_AppVersion.GetMessages();
            while ( AV31GXV2 <= AV30GXV1.Count )
            {
               AV13Message = ((GeneXus.Utils.SdtMessages_Message)AV30GXV1.Item(AV31GXV2));
               new prc_logtoserver(context ).execute(  ">>> "+AV13Message.gxTpr_Description) ;
               AV31GXV2 = (int)(AV31GXV2+1);
            }
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
         P00DD2_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DD2_n29LocationId = new bool[] {false} ;
         P00DD2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00DD2_n11OrganisationId = new bool[] {false} ;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV15OrganisationId = Guid.Empty;
         P00DD3_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DD3_n29LocationId = new bool[] {false} ;
         P00DD3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         AV9BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         AV16BC_WebLinkPage = new SdtTrn_AppVersion_Page(context);
         AV17BC_DynamicFormPage = new SdtTrn_AppVersion_Page(context);
         AV18BC_ReceptionPage = new SdtTrn_AppVersion_Page(context);
         AV19BC_LocationPage = new SdtTrn_AppVersion_Page(context);
         AV20BC_CarePage = new SdtTrn_AppVersion_Page(context);
         AV21BC_LivingPage = new SdtTrn_AppVersion_Page(context);
         AV22BC_ServicesPage = new SdtTrn_AppVersion_Page(context);
         AV23BC_MapsPage = new SdtTrn_AppVersion_Page(context);
         AV26SkipPageNameCollection = new GxSimpleCollection<string>();
         A397Trn_PageName = "";
         P00DD4_A397Trn_PageName = new string[] {""} ;
         P00DD4_A29LocationId = new Guid[] {Guid.Empty} ;
         P00DD4_n29LocationId = new bool[] {false} ;
         P00DD4_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         A392Trn_PageId = Guid.Empty;
         AV12BC_Trn_Page = new SdtTrn_Page(context);
         AV10BC_Page = new SdtTrn_AppVersion_Page(context);
         GXt_SdtTrn_AppVersion_Page1 = new SdtTrn_AppVersion_Page(context);
         AV24BC_MyActivityPage = new SdtTrn_AppVersion_Page(context);
         AV25BC_CalendarPage = new SdtTrn_AppVersion_Page(context);
         AV30GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV13Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_migratepages__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_migratepages__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_migratepages__default(),
            new Object[][] {
                new Object[] {
               P00DD2_A29LocationId, P00DD2_A11OrganisationId
               }
               , new Object[] {
               P00DD3_A29LocationId, P00DD3_n29LocationId, P00DD3_A523AppVersionId
               }
               , new Object[] {
               P00DD4_A397Trn_PageName, P00DD4_A29LocationId, P00DD4_A392Trn_PageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28GXLvl15 ;
      private int AV31GXV2 ;
      private bool n29LocationId ;
      private bool n11OrganisationId ;
      private bool returnInSub ;
      private string A397Trn_PageName ;
      private Guid AV8LocationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private Guid AV15OrganisationId ;
      private Guid A523AppVersionId ;
      private Guid A392Trn_PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DD2_A29LocationId ;
      private bool[] P00DD2_n29LocationId ;
      private Guid[] P00DD2_A11OrganisationId ;
      private bool[] P00DD2_n11OrganisationId ;
      private Guid[] P00DD3_A29LocationId ;
      private bool[] P00DD3_n29LocationId ;
      private Guid[] P00DD3_A523AppVersionId ;
      private SdtTrn_AppVersion AV9BC_Trn_AppVersion ;
      private SdtTrn_AppVersion_Page AV16BC_WebLinkPage ;
      private SdtTrn_AppVersion_Page AV17BC_DynamicFormPage ;
      private SdtTrn_AppVersion_Page AV18BC_ReceptionPage ;
      private SdtTrn_AppVersion_Page AV19BC_LocationPage ;
      private SdtTrn_AppVersion_Page AV20BC_CarePage ;
      private SdtTrn_AppVersion_Page AV21BC_LivingPage ;
      private SdtTrn_AppVersion_Page AV22BC_ServicesPage ;
      private SdtTrn_AppVersion_Page AV23BC_MapsPage ;
      private GxSimpleCollection<string> AV26SkipPageNameCollection ;
      private string[] P00DD4_A397Trn_PageName ;
      private Guid[] P00DD4_A29LocationId ;
      private bool[] P00DD4_n29LocationId ;
      private Guid[] P00DD4_A392Trn_PageId ;
      private SdtTrn_Page AV12BC_Trn_Page ;
      private SdtTrn_AppVersion_Page AV10BC_Page ;
      private SdtTrn_AppVersion_Page GXt_SdtTrn_AppVersion_Page1 ;
      private SdtTrn_AppVersion_Page AV24BC_MyActivityPage ;
      private SdtTrn_AppVersion_Page AV25BC_CalendarPage ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV30GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV13Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_migratepages__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_migratepages__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_migratepages__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_P00DD4( IGxContext context ,
                                          string A397Trn_PageName ,
                                          GxSimpleCollection<string> AV26SkipPageNameCollection ,
                                          Guid A29LocationId ,
                                          Guid AV8LocationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int2 = new short[1];
      Object[] GXv_Object3 = new Object[2];
      scmdbuf = "SELECT Trn_PageName, LocationId, Trn_PageId FROM Trn_Page";
      AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV26SkipPageNameCollection, "Trn_PageName IN (", ")")+")");
      AddWhere(sWhereString, "(LocationId = :AV8LocationId)");
      scmdbuf += sWhereString;
      scmdbuf += " ORDER BY Trn_PageId, LocationId";
      GXv_Object3[0] = scmdbuf;
      GXv_Object3[1] = GXv_int2;
      return GXv_Object3 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 2 :
                  return conditional_P00DD4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (Guid)dynConstraints[2] , (Guid)dynConstraints[3] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00DD2;
       prmP00DD2 = new Object[] {
       new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00DD3;
       prmP00DD3 = new Object[] {
       new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00DD4;
       prmP00DD4 = new Object[] {
       new ParDef("AV8LocationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00DD2", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationId = :AV8LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD2,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P00DD3", "SELECT LocationId, AppVersionId FROM Trn_AppVersion WHERE LocationId = :AV8LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD3,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("P00DD4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DD4,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((bool[]) buf[1])[0] = rslt.wasNull(1);
             ((Guid[]) buf[2])[0] = rslt.getGuid(2);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
