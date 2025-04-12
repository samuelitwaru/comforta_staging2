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
   public class prc_registerresidentlanguage : GXProcedure
   {
      public prc_registerresidentlanguage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_registerresidentlanguage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserId ,
                           string aP1_Language ,
                           out string aP2_Message )
      {
         this.AV14UserId = aP0_UserId;
         this.AV18Language = aP1_Language;
         this.AV11Message = "" ;
         initialize();
         ExecuteImpl();
         aP2_Message=this.AV11Message;
      }

      public string executeUdp( string aP0_UserId ,
                                string aP1_Language )
      {
         execute(aP0_UserId, aP1_Language, out aP2_Message);
         return AV11Message ;
      }

      public void executeSubmit( string aP0_UserId ,
                                 string aP1_Language ,
                                 out string aP2_Message )
      {
         this.AV14UserId = aP0_UserId;
         this.AV18Language = aP1_Language;
         this.AV11Message = "" ;
         SubmitImpl();
         aP2_Message=this.AV11Message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17GAMUser.load( AV14UserId);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18Language)) )
         {
            AV17GAMUser.gxTpr_Timezone = AV18Language;
            AV17GAMUser.save();
            if ( AV17GAMUser.success() )
            {
               AV11Message = context.GetMessage( "Language preference updated.", "");
               context.CommitDataStores("prc_registerresidentlanguage",pr_default);
            }
            else
            {
               AV19GAMErrorCollection = AV17GAMUser.geterrors();
               AV11Message = context.GetMessage( "Language could not be updated: ", "") + ((GeneXus.Programs.genexussecurity.SdtGAMError)AV19GAMErrorCollection.Item(1)).gxTpr_Message;
            }
         }
         else
         {
            AV11Message = context.GetMessage( "Language preference not provided.", "");
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
         AV11Message = "";
         AV17GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV19GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_registerresidentlanguage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_registerresidentlanguage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_registerresidentlanguage__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV18Language ;
      private string AV11Message ;
      private string AV14UserId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV17GAMUser ;
      private IDataStoreProvider pr_default ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV19GAMErrorCollection ;
      private string aP2_Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_registerresidentlanguage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_registerresidentlanguage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_registerresidentlanguage__default : DataStoreHelperBase, IDataStoreHelper
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
