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
   public class prc_publishappversion : GXProcedure
   {
      public prc_publishappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_publishappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId ,
                           bool aP1_Notify ,
                           out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV15AppVersionId = aP0_AppVersionId;
         this.AV18Notify = aP1_Notify;
         this.AV16SDT_Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP2_SDT_Error=this.AV16SDT_Error;
      }

      public SdtSDT_Error executeUdp( Guid aP0_AppVersionId ,
                                      bool aP1_Notify )
      {
         execute(aP0_AppVersionId, aP1_Notify, out aP2_SDT_Error);
         return AV16SDT_Error ;
      }

      public void executeSubmit( Guid aP0_AppVersionId ,
                                 bool aP1_Notify ,
                                 out SdtSDT_Error aP2_SDT_Error )
      {
         this.AV15AppVersionId = aP0_AppVersionId;
         this.AV18Notify = aP1_Notify;
         this.AV16SDT_Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP2_SDT_Error=this.AV16SDT_Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV16SDT_Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV16SDT_Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
            cleanup();
            if (true) return;
         }
         AV17BC_Trn_AppVersion.Load(AV15AppVersionId);
         new prc_logtoserver(context ).execute(  ">>> "+AV17BC_Trn_AppVersion.ToJSonString(true, true)) ;
         if ( ! (Guid.Empty==AV17BC_Trn_AppVersion.gxTpr_Appversionid) )
         {
            /* Using cursor P00BL2 */
            pr_default.execute(0, new Object[] {AV15AppVersionId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A523AppVersionId = P00BL2_A523AppVersionId[0];
               /* Using cursor P00BL3 */
               pr_default.execute(1, new Object[] {A523AppVersionId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  GXTBL3 = 0;
                  A518PageStructure = P00BL3_A518PageStructure[0];
                  A536PagePublishedStructure = P00BL3_A536PagePublishedStructure[0];
                  A517PageName = P00BL3_A517PageName[0];
                  A516PageId = P00BL3_A516PageId[0];
                  A536PagePublishedStructure = A518PageStructure;
                  new prc_logtoserver(context ).execute(  context.GetMessage( "PageName: ", "")+A517PageName) ;
                  GXTBL3 = 1;
                  /* Using cursor P00BL4 */
                  pr_default.execute(2, new Object[] {A536PagePublishedStructure, A523AppVersionId, A516PageId});
                  pr_default.close(2);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                  if ( GXTBL3 == 1 )
                  {
                     context.CommitDataStores("prc_publishappversion",pr_default);
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV18Notify )
            {
               AV19Title = context.GetMessage( "New Updates Available", "");
               AV20NotificationMessage = context.GetMessage( "The latest updates have been published and are now live! Open the app to explore the changes", "");
               AV21Metadata.gxTpr_Notificationcategory = "Toolbox";
               new prc_sendresidentnotification(context ).execute(  AV19Title,  AV20NotificationMessage,  "Toolbox",  AV21Metadata,  AV22ResidentIdCollectionEmpty) ;
            }
         }
         else
         {
            AV16SDT_Error.gxTpr_Message = context.GetMessage( "App version not found", "");
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_publishappversion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV16SDT_Error = new SdtSDT_Error(context);
         AV17BC_Trn_AppVersion = new SdtTrn_AppVersion(context);
         P00BL2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         P00BL3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00BL3_A518PageStructure = new string[] {""} ;
         P00BL3_A536PagePublishedStructure = new string[] {""} ;
         P00BL3_A517PageName = new string[] {""} ;
         P00BL3_A516PageId = new Guid[] {Guid.Empty} ;
         A518PageStructure = "";
         A536PagePublishedStructure = "";
         A517PageName = "";
         A516PageId = Guid.Empty;
         AV19Title = "";
         AV20NotificationMessage = "";
         AV21Metadata = new SdtSDT_OneSignalCustomData(context);
         AV22ResidentIdCollectionEmpty = new GxSimpleCollection<Guid>();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_publishappversion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_publishappversion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_publishappversion__default(),
            new Object[][] {
                new Object[] {
               P00BL2_A523AppVersionId
               }
               , new Object[] {
               P00BL3_A523AppVersionId, P00BL3_A518PageStructure, P00BL3_A536PagePublishedStructure, P00BL3_A517PageName, P00BL3_A516PageId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTBL3 ;
      private bool AV18Notify ;
      private string A518PageStructure ;
      private string A536PagePublishedStructure ;
      private string A517PageName ;
      private string AV19Title ;
      private string AV20NotificationMessage ;
      private Guid AV15AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_Error AV16SDT_Error ;
      private SdtTrn_AppVersion AV17BC_Trn_AppVersion ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00BL2_A523AppVersionId ;
      private Guid[] P00BL3_A523AppVersionId ;
      private string[] P00BL3_A518PageStructure ;
      private string[] P00BL3_A536PagePublishedStructure ;
      private string[] P00BL3_A517PageName ;
      private Guid[] P00BL3_A516PageId ;
      private SdtSDT_OneSignalCustomData AV21Metadata ;
      private GxSimpleCollection<Guid> AV22ResidentIdCollectionEmpty ;
      private SdtSDT_Error aP2_SDT_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_publishappversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_publishappversion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_publishappversion__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new UpdateCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00BL2;
       prmP00BL2 = new Object[] {
       new ParDef("AV15AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BL3;
       prmP00BL3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmP00BL4;
       prmP00BL4 = new Object[] {
       new ParDef("PagePublishedStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("P00BL2", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AV15AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BL2,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("P00BL3", "SELECT AppVersionId, PageStructure, PagePublishedStructure, PageName, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BL3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("P00BL4", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PagePublishedStructure=:PagePublishedStructure  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00BL4)
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             return;
    }
 }

}

}
