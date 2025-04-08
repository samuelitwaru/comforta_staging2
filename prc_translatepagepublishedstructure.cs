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
   public class prc_translatepagepublishedstructure : GXProcedure
   {
      public prc_translatepagepublishedstructure( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_translatepagepublishedstructure( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_AppVersionId )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( Guid aP0_AppVersionId )
      {
         this.AV8AppVersionId = aP0_AppVersionId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00EA2 */
         pr_default.execute(0, new Object[] {AV8AppVersionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A523AppVersionId = P00EA2_A523AppVersionId[0];
            A516PageId = P00EA2_A516PageId[0];
            AV11VersionPage.Add(A516PageId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A580DynamicTranslationPrimaryKey ,
                                              AV11VersionPage ,
                                              A579DynamicTranslationTrnName ,
                                              A581DynamicTranslationAttributeNam } ,
                                              new int[]{
                                              }
         });
         /* Using cursor P00EA3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEA3 = false;
            A578DynamicTranslationId = P00EA3_A578DynamicTranslationId[0];
            A580DynamicTranslationPrimaryKey = P00EA3_A580DynamicTranslationPrimaryKey[0];
            A581DynamicTranslationAttributeNam = P00EA3_A581DynamicTranslationAttributeNam[0];
            A579DynamicTranslationTrnName = P00EA3_A579DynamicTranslationTrnName[0];
            A583DynamicTranslationDutch = P00EA3_A583DynamicTranslationDutch[0];
            A582DynamicTranslationEnglish = P00EA3_A582DynamicTranslationEnglish[0];
            AV12DynamicTranslationPrimaryKey = A580DynamicTranslationPrimaryKey;
            AV13DynamicTranslationTrnName = A579DynamicTranslationTrnName;
            AV14DynamicTranslationAttributeName = A581DynamicTranslationAttributeNam;
            AV15DynamicTranslationDutch = A583DynamicTranslationDutch;
            AV16DynamicTranslationEnglish = A582DynamicTranslationEnglish;
            AV19GXLvl14 = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00EA3_A578DynamicTranslationId[0] == A578DynamicTranslationId ) )
            {
               BRKEA3 = false;
               A580DynamicTranslationPrimaryKey = P00EA3_A580DynamicTranslationPrimaryKey[0];
               A581DynamicTranslationAttributeNam = P00EA3_A581DynamicTranslationAttributeNam[0];
               A579DynamicTranslationTrnName = P00EA3_A579DynamicTranslationTrnName[0];
               A583DynamicTranslationDutch = P00EA3_A583DynamicTranslationDutch[0];
               A582DynamicTranslationEnglish = P00EA3_A582DynamicTranslationEnglish[0];
               if ( StringUtil.StrCmp(A579DynamicTranslationTrnName, "Trn_AppVersion.Page") == 0 )
               {
                  if ( StringUtil.StrCmp(A581DynamicTranslationAttributeNam, "PagePublishedStructure") == 0 )
                  {
                     if ( A580DynamicTranslationPrimaryKey == AV12DynamicTranslationPrimaryKey )
                     {
                        if ( (AV11VersionPage.IndexOf(A580DynamicTranslationPrimaryKey)>0) )
                        {
                           AV19GXLvl14 = 1;
                           A579DynamicTranslationTrnName = AV13DynamicTranslationTrnName;
                           A583DynamicTranslationDutch = AV15DynamicTranslationDutch;
                           A582DynamicTranslationEnglish = AV16DynamicTranslationEnglish;
                           /* Using cursor P00EA4 */
                           pr_default.execute(2, new Object[] {A579DynamicTranslationTrnName, A583DynamicTranslationDutch, A582DynamicTranslationEnglish, A578DynamicTranslationId});
                           pr_default.close(2);
                           pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
                        }
                     }
                  }
               }
               BRKEA3 = true;
               pr_default.readNext(1);
            }
            if ( AV19GXLvl14 == 0 )
            {
               /*
                  INSERT RECORD ON TABLE Trn_DynamicTranslation

               */
               W579DynamicTranslationTrnName = A579DynamicTranslationTrnName;
               W581DynamicTranslationAttributeNam = A581DynamicTranslationAttributeNam;
               W583DynamicTranslationDutch = A583DynamicTranslationDutch;
               W582DynamicTranslationEnglish = A582DynamicTranslationEnglish;
               A579DynamicTranslationTrnName = AV13DynamicTranslationTrnName;
               A581DynamicTranslationAttributeNam = "PagePublishedStructure";
               A583DynamicTranslationDutch = AV15DynamicTranslationDutch;
               A582DynamicTranslationEnglish = AV16DynamicTranslationEnglish;
               /* Using cursor P00EA5 */
               pr_default.execute(3, new Object[] {A578DynamicTranslationId, A579DynamicTranslationTrnName, A580DynamicTranslationPrimaryKey, A581DynamicTranslationAttributeNam, A582DynamicTranslationEnglish, A583DynamicTranslationDutch});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("Trn_DynamicTranslation");
               if ( (pr_default.getStatus(3) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               A579DynamicTranslationTrnName = W579DynamicTranslationTrnName;
               A581DynamicTranslationAttributeNam = W581DynamicTranslationAttributeNam;
               A583DynamicTranslationDutch = W583DynamicTranslationDutch;
               A582DynamicTranslationEnglish = W582DynamicTranslationEnglish;
               /* End Insert */
            }
            if ( ! BRKEA3 )
            {
               BRKEA3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_translatepagepublishedstructure",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00EA2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         P00EA2_A516PageId = new Guid[] {Guid.Empty} ;
         A523AppVersionId = Guid.Empty;
         A516PageId = Guid.Empty;
         AV11VersionPage = new GxSimpleCollection<Guid>();
         A580DynamicTranslationPrimaryKey = Guid.Empty;
         A579DynamicTranslationTrnName = "";
         A581DynamicTranslationAttributeNam = "";
         P00EA3_A578DynamicTranslationId = new Guid[] {Guid.Empty} ;
         P00EA3_A580DynamicTranslationPrimaryKey = new Guid[] {Guid.Empty} ;
         P00EA3_A581DynamicTranslationAttributeNam = new string[] {""} ;
         P00EA3_A579DynamicTranslationTrnName = new string[] {""} ;
         P00EA3_A583DynamicTranslationDutch = new string[] {""} ;
         P00EA3_A582DynamicTranslationEnglish = new string[] {""} ;
         A578DynamicTranslationId = Guid.Empty;
         A583DynamicTranslationDutch = "";
         A582DynamicTranslationEnglish = "";
         AV12DynamicTranslationPrimaryKey = Guid.Empty;
         AV13DynamicTranslationTrnName = "";
         AV14DynamicTranslationAttributeName = "";
         AV15DynamicTranslationDutch = "";
         AV16DynamicTranslationEnglish = "";
         W579DynamicTranslationTrnName = "";
         W581DynamicTranslationAttributeNam = "";
         W583DynamicTranslationDutch = "";
         W582DynamicTranslationEnglish = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_translatepagepublishedstructure__default(),
            new Object[][] {
                new Object[] {
               P00EA2_A523AppVersionId, P00EA2_A516PageId
               }
               , new Object[] {
               P00EA3_A578DynamicTranslationId, P00EA3_A580DynamicTranslationPrimaryKey, P00EA3_A581DynamicTranslationAttributeNam, P00EA3_A579DynamicTranslationTrnName, P00EA3_A583DynamicTranslationDutch, P00EA3_A582DynamicTranslationEnglish
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19GXLvl14 ;
      private int GX_INS104 ;
      private string Gx_emsg ;
      private bool BRKEA3 ;
      private string A583DynamicTranslationDutch ;
      private string A582DynamicTranslationEnglish ;
      private string AV15DynamicTranslationDutch ;
      private string AV16DynamicTranslationEnglish ;
      private string W583DynamicTranslationDutch ;
      private string W582DynamicTranslationEnglish ;
      private string A579DynamicTranslationTrnName ;
      private string A581DynamicTranslationAttributeNam ;
      private string AV13DynamicTranslationTrnName ;
      private string AV14DynamicTranslationAttributeName ;
      private string W579DynamicTranslationTrnName ;
      private string W581DynamicTranslationAttributeNam ;
      private Guid AV8AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid A516PageId ;
      private Guid A580DynamicTranslationPrimaryKey ;
      private Guid A578DynamicTranslationId ;
      private Guid AV12DynamicTranslationPrimaryKey ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00EA2_A523AppVersionId ;
      private Guid[] P00EA2_A516PageId ;
      private GxSimpleCollection<Guid> AV11VersionPage ;
      private Guid[] P00EA3_A578DynamicTranslationId ;
      private Guid[] P00EA3_A580DynamicTranslationPrimaryKey ;
      private string[] P00EA3_A581DynamicTranslationAttributeNam ;
      private string[] P00EA3_A579DynamicTranslationTrnName ;
      private string[] P00EA3_A583DynamicTranslationDutch ;
      private string[] P00EA3_A582DynamicTranslationEnglish ;
   }

   public class prc_translatepagepublishedstructure__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EA3( IGxContext context ,
                                             Guid A580DynamicTranslationPrimaryKey ,
                                             GxSimpleCollection<Guid> AV11VersionPage ,
                                             string A579DynamicTranslationTrnName ,
                                             string A581DynamicTranslationAttributeNam )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object1 = new Object[2];
         scmdbuf = "SELECT DynamicTranslationId, DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationTrnName, DynamicTranslationDutch, DynamicTranslationEnglish FROM Trn_DynamicTranslation";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV11VersionPage, "DynamicTranslationPrimaryKey IN (", ")")+")");
         AddWhere(sWhereString, "(DynamicTranslationTrnName = ( 'Trn_AppVersion.Page'))");
         AddWhere(sWhereString, "(DynamicTranslationAttributeNam = ( 'PageStructure'))");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY DynamicTranslationId";
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00EA3(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EA2;
          prmP00EA2 = new Object[] {
          new ParDef("AV8AppVersionId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00EA4;
          prmP00EA4 = new Object[] {
          new ParDef("DynamicTranslationTrnName",GXType.VarChar,100,0) ,
          new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0) ,
          new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
          new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00EA5;
          prmP00EA5 = new Object[] {
          new ParDef("DynamicTranslationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("DynamicTranslationTrnName",GXType.VarChar,100,0) ,
          new ParDef("DynamicTranslationPrimaryKey",GXType.UniqueIdentifier,36,0) ,
          new ParDef("DynamicTranslationAttributeNam",GXType.VarChar,100,0) ,
          new ParDef("DynamicTranslationEnglish",GXType.LongVarChar,2097152,0) ,
          new ParDef("DynamicTranslationDutch",GXType.LongVarChar,2097152,0)
          };
          Object[] prmP00EA3;
          prmP00EA3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00EA2", "SELECT AppVersionId, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AV8AppVersionId ORDER BY AppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EA3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EA3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EA4", "SAVEPOINT gxupdate;UPDATE Trn_DynamicTranslation SET DynamicTranslationTrnName=:DynamicTranslationTrnName, DynamicTranslationDutch=:DynamicTranslationDutch, DynamicTranslationEnglish=:DynamicTranslationEnglish  WHERE DynamicTranslationId = :DynamicTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00EA4)
             ,new CursorDef("P00EA5", "SAVEPOINT gxupdate;INSERT INTO Trn_DynamicTranslation(DynamicTranslationId, DynamicTranslationTrnName, DynamicTranslationPrimaryKey, DynamicTranslationAttributeNam, DynamicTranslationEnglish, DynamicTranslationDutch) VALUES(:DynamicTranslationId, :DynamicTranslationTrnName, :DynamicTranslationPrimaryKey, :DynamicTranslationAttributeNam, :DynamicTranslationEnglish, :DynamicTranslationDutch);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_MASKLOOPLOCK,prmP00EA5)
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
                return;
       }
    }

 }

}
