using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_registerresidentlanguage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
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
            AV17GAMUser.gxTpr_Language = AV18Language;
         }
         AV17GAMUser.save();
         if ( AV17GAMUser.success() )
         {
            AV11Message = context.GetMessage( "Language preference updated.", "");
         }
         else
         {
            AV19GAMErrorCollection = AV17GAMUser.geterrors();
            AV11Message = context.GetMessage( "Language could not be updated: ", "") + ((GeneXus.Programs.genexussecurity.SdtGAMError)AV19GAMErrorCollection.Item(1)).gxTpr_Message;
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
         /* GeneXus formulas. */
      }

      private string AV18Language ;
      private string AV11Message ;
      private string AV14UserId ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV17GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV19GAMErrorCollection ;
      private string aP2_Message ;
   }

}
