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
   public class prc_deletepreferredgensupplierrecord : GXProcedure
   {
      public prc_deletepreferredgensupplierrecord( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deletepreferredgensupplierrecord( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_SupplierGenId ,
                           Guid aP1_OrganisationId )
      {
         this.AV8SupplierGenId = aP0_SupplierGenId;
         this.AV9OrganisationId = aP1_OrganisationId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_SupplierGenId ,
                                 Guid aP1_OrganisationId )
      {
         this.AV8SupplierGenId = aP0_SupplierGenId;
         this.AV9OrganisationId = aP1_OrganisationId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00922 */
         pr_default.execute(0, new Object[] {AV8SupplierGenId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A382PreferredSupplierGenId = P00922_A382PreferredSupplierGenId[0];
            A383PreferredGenSupplierId = P00922_A383PreferredGenSupplierId[0];
            AV10Trn_PreferredGenSupplier.Load(A383PreferredGenSupplierId);
            AV10Trn_PreferredGenSupplier.Delete();
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
         P00922_A382PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         P00922_A383PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         A382PreferredSupplierGenId = Guid.Empty;
         A383PreferredGenSupplierId = Guid.Empty;
         AV10Trn_PreferredGenSupplier = new SdtTrn_PreferredGenSupplier(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_deletepreferredgensupplierrecord__default(),
            new Object[][] {
                new Object[] {
               P00922_A382PreferredSupplierGenId, P00922_A383PreferredGenSupplierId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private Guid AV8SupplierGenId ;
      private Guid AV9OrganisationId ;
      private Guid A382PreferredSupplierGenId ;
      private Guid A383PreferredGenSupplierId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00922_A382PreferredSupplierGenId ;
      private Guid[] P00922_A383PreferredGenSupplierId ;
      private SdtTrn_PreferredGenSupplier AV10Trn_PreferredGenSupplier ;
   }

   public class prc_deletepreferredgensupplierrecord__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00922;
          prmP00922 = new Object[] {
          new ParDef("AV8SupplierGenId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00922", "SELECT PreferredSupplierGenId, PreferredGenSupplierId FROM Trn_PreferredGenSupplier WHERE PreferredSupplierGenId = :AV8SupplierGenId ORDER BY PreferredGenSupplierId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00922,100, GxCacheFrequency.OFF ,true,false )
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
       }
    }

 }

}
