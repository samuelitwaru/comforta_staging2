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
   public class prc_debugappversion : GXProcedure
   {
      public prc_debugappversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_debugappversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<SdtSDT_PageUrl> aP0_UrlList ,
                           out SdtSDT_DebugResults aP1_DebugResults ,
                           out SdtSDT_Error aP2_Error )
      {
         this.AV16UrlList = aP0_UrlList;
         this.AV9DebugResults = new SdtSDT_DebugResults(context) ;
         this.AV10Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP1_DebugResults=this.AV9DebugResults;
         aP2_Error=this.AV10Error;
      }

      public SdtSDT_Error executeUdp( GXBaseCollection<SdtSDT_PageUrl> aP0_UrlList ,
                                      out SdtSDT_DebugResults aP1_DebugResults )
      {
         execute(aP0_UrlList, out aP1_DebugResults, out aP2_Error);
         return AV10Error ;
      }

      public void executeSubmit( GXBaseCollection<SdtSDT_PageUrl> aP0_UrlList ,
                                 out SdtSDT_DebugResults aP1_DebugResults ,
                                 out SdtSDT_Error aP2_Error )
      {
         this.AV16UrlList = aP0_UrlList;
         this.AV9DebugResults = new SdtSDT_DebugResults(context) ;
         this.AV10Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP1_DebugResults=this.AV9DebugResults;
         aP2_Error=this.AV10Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         AV9DebugResults = new SdtSDT_DebugResults(context);
         AV10Error = new SdtSDT_Error(context);
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtSDT_PageUrl> AV16UrlList ;
      private SdtSDT_DebugResults AV9DebugResults ;
      private SdtSDT_Error AV10Error ;
      private SdtSDT_DebugResults aP1_DebugResults ;
      private SdtSDT_Error aP2_Error ;
   }

}
