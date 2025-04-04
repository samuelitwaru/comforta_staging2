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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_sendwebnotification : GXProcedure
   {
      public wwp_sendwebnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sendwebnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WebNotificationId ,
                           out short aP1_SendStatus )
      {
         this.AV10WebNotificationId = aP0_WebNotificationId;
         this.AV11SendStatus = 0 ;
         initialize();
         ExecuteImpl();
         aP1_SendStatus=this.AV11SendStatus;
      }

      public short executeUdp( long aP0_WebNotificationId )
      {
         execute(aP0_WebNotificationId, out aP1_SendStatus);
         return AV11SendStatus ;
      }

      public void executeSubmit( long aP0_WebNotificationId ,
                                 out short aP1_SendStatus )
      {
         this.AV10WebNotificationId = aP0_WebNotificationId;
         this.AV11SendStatus = 0 ;
         SubmitImpl();
         aP1_SendStatus=this.AV11SendStatus;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SendStatus = -1;
         AV9webnotification.Load(AV10WebNotificationId);
         if ( AV9webnotification.Fail() )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV14Pgmname,  "Web Notification not found with id: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV10WebNotificationId), 10, 0))) ;
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9webnotification.gxTpr_Wwpwebnotificationtitle)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9webnotification.gxTpr_Wwpwebnotificationtext)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV14Pgmname,  "Title/Text cannot be empty: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV10WebNotificationId), 10, 0))) ;
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_updatewebnotificationstatus(context ).execute(  AV10WebNotificationId,  3,  "Title/Text cannot be empty") ;
            cleanup();
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9webnotification.gxTpr_Wwpwebnotificationclientid)) )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV14Pgmname,  "Client Id cannot be empty: "+StringUtil.Trim( StringUtil.Str( (decimal)(AV10WebNotificationId), 10, 0))) ;
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_updatewebnotificationstatus(context ).execute(  AV10WebNotificationId,  3,  "Client Id cannot be empty") ;
            cleanup();
            if (true) return;
         }
         AV13NotificationInfo.gxTpr_Id = "WebNotification#"+StringUtil.Trim( StringUtil.Str( (decimal)(AV10WebNotificationId), 10, 0));
         AV13NotificationInfo.gxTpr_Message = AV9webnotification.ToJSonString(true, true);
         AV12ClientId = AV9webnotification.gxTpr_Wwpwebnotificationclientid;
         AV11SendStatus = AV8ServerSocket.notifyclient(AV12ClientId, AV13NotificationInfo);
         if ( AV11SendStatus > 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV14Pgmname,  StringUtil.Format( "Error sending web notification with id: %1 - %2 - %3 - %4", StringUtil.Trim( StringUtil.Str( (decimal)(AV10WebNotificationId), 10, 0)), StringUtil.LTrimStr( (decimal)(AV11SendStatus), 4, 0), StringUtil.Trim( StringUtil.Str( (decimal)(AV8ServerSocket.gxTpr_Errcode), 4, 0)), AV8ServerSocket.gxTpr_Errdescription, "", "", "", "", "")) ;
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_updatewebnotificationstatus(context ).execute(  AV10WebNotificationId,  3,  StringUtil.Format( "%1 - %2 - %3", StringUtil.LTrimStr( (decimal)(AV11SendStatus), 4, 0), StringUtil.Trim( StringUtil.Str( (decimal)(AV8ServerSocket.gxTpr_Errcode), 4, 0)), AV8ServerSocket.gxTpr_Errdescription, "", "", "", "", "", "")) ;
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_updatewebnotificationstatus(context ).execute(  AV10WebNotificationId,  2,  "OK") ;
         context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_sendwebnotification",pr_default);
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
         AV9webnotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         AV14Pgmname = "";
         AV13NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV12ClientId = "";
         AV8ServerSocket = new GeneXus.Core.genexus.server.SdtSocket(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_sendwebnotification__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_sendwebnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_sendwebnotification__default(),
            new Object[][] {
            }
         );
         AV14Pgmname = "WWPBaseObjects.Notifications.Web.WWP_SendWebNotification";
         /* GeneXus formulas. */
         AV14Pgmname = "WWPBaseObjects.Notifications.Web.WWP_SendWebNotification";
      }

      private short AV11SendStatus ;
      private long AV10WebNotificationId ;
      private string AV14Pgmname ;
      private string AV12ClientId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification AV9webnotification ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV13NotificationInfo ;
      private GeneXus.Core.genexus.server.SdtSocket AV8ServerSocket ;
      private IDataStoreProvider pr_default ;
      private short aP1_SendStatus ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_sendwebnotification__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sendwebnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_sendwebnotification__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
