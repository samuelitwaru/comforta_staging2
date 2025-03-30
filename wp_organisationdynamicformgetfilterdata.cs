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
   public class wp_organisationdynamicformgetfilterdata : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "wp_organisationdynamicform_Services_Execute" ;
         }

      }

      public wp_organisationdynamicformgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_organisationdynamicformgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV42OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24MaxItems = 10;
         AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV38SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? "" : StringUtil.Substring( AV38SearchTxtParms, 3, -1));
         AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_WWPFORMTITLE") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMTITLEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_WWPFORMREFERENCENAME") == 0 )
         {
            /* Execute user subroutine: 'LOADWWPFORMREFERENCENAMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV40OptionsJson = AV27Options.ToJSonString(false);
         AV41OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV42OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("WP_OrganisationDynamicFormGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WP_OrganisationDynamicFormGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("WP_OrganisationDynamicFormGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV11TFWWPFormTitle = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV12TFWWPFormTitle_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV13TFWWPFormReferenceName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV14TFWWPFormReferenceName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV15TFWWPFormDate = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV16TFWWPFormDate_To = context.localUtil.CToT( AV35GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMVERSIONNUMBER") == 0 )
            {
               AV17TFWWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFWWPFormVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFWWPFORMLATESTVERSIONNUMBER") == 0 )
            {
               AV19TFWWPFormLatestVersionNumber = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFWWPFormLatestVersionNumber_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMTYPE") == 0 )
            {
               AV44WWPFormType = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARM_&WWPFORMISFORDYNAMICVALIDATIONS") == 0 )
            {
               AV45WWPFormIsForDynamicValidations = BooleanUtil.Val( AV35GridStateFilterValue.gxTpr_Value);
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADWWPFORMTITLEOPTIONS' Routine */
         returnInSub = false;
         AV11TFWWPFormTitle = AV21SearchTxt;
         AV12TFWWPFormTitle_Sel = "";
         AV49Wp_organisationdynamicformds_1_wwpformtype = AV44WWPFormType;
         AV50Wp_organisationdynamicformds_2_filterfulltext = AV43FilterFullText;
         AV51Wp_organisationdynamicformds_3_tfwwpformtitle = AV11TFWWPFormTitle;
         AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel = AV12TFWWPFormTitle_Sel;
         AV53Wp_organisationdynamicformds_5_tfwwpformreferencename = AV13TFWWPFormReferenceName;
         AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel = AV14TFWWPFormReferenceName_Sel;
         AV55Wp_organisationdynamicformds_7_tfwwpformdate = AV15TFWWPFormDate;
         AV56Wp_organisationdynamicformds_8_tfwwpformdate_to = AV16TFWWPFormDate_To;
         AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber = AV17TFWWPFormVersionNumber;
         AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to = AV18TFWWPFormVersionNumber_To;
         AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber = AV19TFWWPFormLatestVersionNumber;
         AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to = AV20TFWWPFormLatestVersionNumber_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel ,
                                              AV51Wp_organisationdynamicformds_3_tfwwpformtitle ,
                                              AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel ,
                                              AV53Wp_organisationdynamicformds_5_tfwwpformreferencename ,
                                              AV55Wp_organisationdynamicformds_7_tfwwpformdate ,
                                              AV56Wp_organisationdynamicformds_8_tfwwpformdate_to ,
                                              AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber ,
                                              AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to ,
                                              A209WWPFormTitle ,
                                              A208WWPFormReferenceName ,
                                              A231WWPFormDate ,
                                              A207WWPFormVersionNumber ,
                                              AV50Wp_organisationdynamicformds_2_filterfulltext ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber ,
                                              AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to ,
                                              A11OrganisationId ,
                                              AV46OrganisationId ,
                                              AV49Wp_organisationdynamicformds_1_wwpformtype ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV51Wp_organisationdynamicformds_3_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV51Wp_organisationdynamicformds_3_tfwwpformtitle), "%", "");
         lV53Wp_organisationdynamicformds_5_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV53Wp_organisationdynamicformds_5_tfwwpformreferencename), "%", "");
         /* Using cursor P00AY2 */
         pr_default.execute(0, new Object[] {AV49Wp_organisationdynamicformds_1_wwpformtype, AV46OrganisationId, lV51Wp_organisationdynamicformds_3_tfwwpformtitle, AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel, lV53Wp_organisationdynamicformds_5_tfwwpformreferencename, AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel, AV55Wp_organisationdynamicformds_7_tfwwpformdate, AV56Wp_organisationdynamicformds_8_tfwwpformdate_to, AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber, AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAY2 = false;
            A240WWPFormType = P00AY2_A240WWPFormType[0];
            A11OrganisationId = P00AY2_A11OrganisationId[0];
            A209WWPFormTitle = P00AY2_A209WWPFormTitle[0];
            A207WWPFormVersionNumber = P00AY2_A207WWPFormVersionNumber[0];
            A231WWPFormDate = P00AY2_A231WWPFormDate[0];
            A208WWPFormReferenceName = P00AY2_A208WWPFormReferenceName[0];
            A206WWPFormId = P00AY2_A206WWPFormId[0];
            A509OrganisationDynamicFormId = P00AY2_A509OrganisationDynamicFormId[0];
            A240WWPFormType = P00AY2_A240WWPFormType[0];
            A209WWPFormTitle = P00AY2_A209WWPFormTitle[0];
            A231WWPFormDate = P00AY2_A231WWPFormDate[0];
            A208WWPFormReferenceName = P00AY2_A208WWPFormReferenceName[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_organisationdynamicformds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wp_organisationdynamicformds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A208WWPFormReferenceName) , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wp_organisationdynamicformds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV50Wp_organisationdynamicformds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV50Wp_organisationdynamicformds_2_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber) || ( ( A219WWPFormLatestVersionNumber >= AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber ) ) )
               {
                  if ( (0==AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to) || ( ( A219WWPFormLatestVersionNumber <= AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to ) ) )
                  {
                     W240WWPFormType = A240WWPFormType;
                     AV31count = 0;
                     while ( (pr_default.getStatus(0) != 101) && ( P00AY2_A240WWPFormType[0] == A240WWPFormType ) && ( StringUtil.StrCmp(P00AY2_A209WWPFormTitle[0], A209WWPFormTitle) == 0 ) )
                     {
                        BRKAY2 = false;
                        A11OrganisationId = P00AY2_A11OrganisationId[0];
                        A207WWPFormVersionNumber = P00AY2_A207WWPFormVersionNumber[0];
                        A206WWPFormId = P00AY2_A206WWPFormId[0];
                        A509OrganisationDynamicFormId = P00AY2_A509OrganisationDynamicFormId[0];
                        AV31count = (long)(AV31count+1);
                        BRKAY2 = true;
                        pr_default.readNext(0);
                     }
                     if ( (0==AV22SkipItems) )
                     {
                        AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A209WWPFormTitle)) ? "<#Empty#>" : A209WWPFormTitle);
                        AV27Options.Add(AV26Option, 0);
                        AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                        if ( AV27Options.Count == 10 )
                        {
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                     else
                     {
                        AV22SkipItems = (short)(AV22SkipItems-1);
                     }
                     A240WWPFormType = W240WWPFormType;
                  }
               }
            }
            if ( ! BRKAY2 )
            {
               BRKAY2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADWWPFORMREFERENCENAMEOPTIONS' Routine */
         returnInSub = false;
         AV13TFWWPFormReferenceName = AV21SearchTxt;
         AV14TFWWPFormReferenceName_Sel = "";
         AV49Wp_organisationdynamicformds_1_wwpformtype = AV44WWPFormType;
         AV50Wp_organisationdynamicformds_2_filterfulltext = AV43FilterFullText;
         AV51Wp_organisationdynamicformds_3_tfwwpformtitle = AV11TFWWPFormTitle;
         AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel = AV12TFWWPFormTitle_Sel;
         AV53Wp_organisationdynamicformds_5_tfwwpformreferencename = AV13TFWWPFormReferenceName;
         AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel = AV14TFWWPFormReferenceName_Sel;
         AV55Wp_organisationdynamicformds_7_tfwwpformdate = AV15TFWWPFormDate;
         AV56Wp_organisationdynamicformds_8_tfwwpformdate_to = AV16TFWWPFormDate_To;
         AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber = AV17TFWWPFormVersionNumber;
         AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to = AV18TFWWPFormVersionNumber_To;
         AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber = AV19TFWWPFormLatestVersionNumber;
         AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to = AV20TFWWPFormLatestVersionNumber_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel ,
                                              AV51Wp_organisationdynamicformds_3_tfwwpformtitle ,
                                              AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel ,
                                              AV53Wp_organisationdynamicformds_5_tfwwpformreferencename ,
                                              AV55Wp_organisationdynamicformds_7_tfwwpformdate ,
                                              AV56Wp_organisationdynamicformds_8_tfwwpformdate_to ,
                                              AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber ,
                                              AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to ,
                                              A209WWPFormTitle ,
                                              A208WWPFormReferenceName ,
                                              A231WWPFormDate ,
                                              A207WWPFormVersionNumber ,
                                              AV50Wp_organisationdynamicformds_2_filterfulltext ,
                                              A219WWPFormLatestVersionNumber ,
                                              AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber ,
                                              AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to ,
                                              A11OrganisationId ,
                                              AV46OrganisationId ,
                                              AV49Wp_organisationdynamicformds_1_wwpformtype ,
                                              A240WWPFormType } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV51Wp_organisationdynamicformds_3_tfwwpformtitle = StringUtil.Concat( StringUtil.RTrim( AV51Wp_organisationdynamicformds_3_tfwwpformtitle), "%", "");
         lV53Wp_organisationdynamicformds_5_tfwwpformreferencename = StringUtil.Concat( StringUtil.RTrim( AV53Wp_organisationdynamicformds_5_tfwwpformreferencename), "%", "");
         /* Using cursor P00AY3 */
         pr_default.execute(1, new Object[] {AV49Wp_organisationdynamicformds_1_wwpformtype, AV46OrganisationId, lV51Wp_organisationdynamicformds_3_tfwwpformtitle, AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel, lV53Wp_organisationdynamicformds_5_tfwwpformreferencename, AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel, AV55Wp_organisationdynamicformds_7_tfwwpformdate, AV56Wp_organisationdynamicformds_8_tfwwpformdate_to, AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber, AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAY4 = false;
            A240WWPFormType = P00AY3_A240WWPFormType[0];
            A11OrganisationId = P00AY3_A11OrganisationId[0];
            A207WWPFormVersionNumber = P00AY3_A207WWPFormVersionNumber[0];
            A231WWPFormDate = P00AY3_A231WWPFormDate[0];
            A208WWPFormReferenceName = P00AY3_A208WWPFormReferenceName[0];
            A209WWPFormTitle = P00AY3_A209WWPFormTitle[0];
            A206WWPFormId = P00AY3_A206WWPFormId[0];
            A509OrganisationDynamicFormId = P00AY3_A509OrganisationDynamicFormId[0];
            A240WWPFormType = P00AY3_A240WWPFormType[0];
            A231WWPFormDate = P00AY3_A231WWPFormDate[0];
            A208WWPFormReferenceName = P00AY3_A208WWPFormReferenceName[0];
            A209WWPFormTitle = P00AY3_A209WWPFormTitle[0];
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Wp_organisationdynamicformds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A209WWPFormTitle) , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wp_organisationdynamicformds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A208WWPFormReferenceName) , StringUtil.PadR( "%" + StringUtil.Lower( AV50Wp_organisationdynamicformds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV50Wp_organisationdynamicformds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A219WWPFormLatestVersionNumber), 4, 0) , StringUtil.PadR( "%" + AV50Wp_organisationdynamicformds_2_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (0==AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber) || ( ( A219WWPFormLatestVersionNumber >= AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber ) ) )
               {
                  if ( (0==AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to) || ( ( A219WWPFormLatestVersionNumber <= AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to ) ) )
                  {
                     W240WWPFormType = A240WWPFormType;
                     AV31count = 0;
                     while ( (pr_default.getStatus(1) != 101) && ( P00AY3_A240WWPFormType[0] == A240WWPFormType ) && ( P00AY3_A206WWPFormId[0] == A206WWPFormId ) && ( P00AY3_A207WWPFormVersionNumber[0] == A207WWPFormVersionNumber ) )
                     {
                        BRKAY4 = false;
                        A11OrganisationId = P00AY3_A11OrganisationId[0];
                        A509OrganisationDynamicFormId = P00AY3_A509OrganisationDynamicFormId[0];
                        AV31count = (long)(AV31count+1);
                        BRKAY4 = true;
                        pr_default.readNext(1);
                     }
                     AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A208WWPFormReferenceName)) ? "<#Empty#>" : A208WWPFormReferenceName);
                     AV25InsertIndex = 1;
                     while ( ( StringUtil.StrCmp(AV26Option, "<#Empty#>") != 0 ) && ( AV25InsertIndex <= AV27Options.Count ) && ( ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) < 0 ) || ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), "<#Empty#>") == 0 ) ) )
                     {
                        AV25InsertIndex = (int)(AV25InsertIndex+1);
                     }
                     AV27Options.Add(AV26Option, AV25InsertIndex);
                     AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), AV25InsertIndex);
                     if ( AV27Options.Count == AV22SkipItems + 11 )
                     {
                        AV27Options.RemoveItem(AV27Options.Count);
                        AV30OptionIndexes.RemoveItem(AV30OptionIndexes.Count);
                     }
                     A240WWPFormType = W240WWPFormType;
                  }
               }
            }
            if ( ! BRKAY4 )
            {
               BRKAY4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV22SkipItems > 0 )
         {
            AV27Options.RemoveItem(1);
            AV30OptionIndexes.RemoveItem(1);
            AV22SkipItems = (short)(AV22SkipItems-1);
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
         AV40OptionsJson = "";
         AV41OptionsDescJson = "";
         AV42OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV11TFWWPFormTitle = "";
         AV12TFWWPFormTitle_Sel = "";
         AV13TFWWPFormReferenceName = "";
         AV14TFWWPFormReferenceName_Sel = "";
         AV15TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV16TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AV50Wp_organisationdynamicformds_2_filterfulltext = "";
         AV51Wp_organisationdynamicformds_3_tfwwpformtitle = "";
         AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel = "";
         AV53Wp_organisationdynamicformds_5_tfwwpformreferencename = "";
         AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel = "";
         AV55Wp_organisationdynamicformds_7_tfwwpformdate = (DateTime)(DateTime.MinValue);
         AV56Wp_organisationdynamicformds_8_tfwwpformdate_to = (DateTime)(DateTime.MinValue);
         lV51Wp_organisationdynamicformds_3_tfwwpformtitle = "";
         lV53Wp_organisationdynamicformds_5_tfwwpformreferencename = "";
         A209WWPFormTitle = "";
         A208WWPFormReferenceName = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         A11OrganisationId = Guid.Empty;
         AV46OrganisationId = Guid.Empty;
         P00AY2_A240WWPFormType = new short[1] ;
         P00AY2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AY2_A209WWPFormTitle = new string[] {""} ;
         P00AY2_A207WWPFormVersionNumber = new short[1] ;
         P00AY2_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00AY2_A208WWPFormReferenceName = new string[] {""} ;
         P00AY2_A206WWPFormId = new short[1] ;
         P00AY2_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         A509OrganisationDynamicFormId = Guid.Empty;
         AV26Option = "";
         P00AY3_A240WWPFormType = new short[1] ;
         P00AY3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         P00AY3_A207WWPFormVersionNumber = new short[1] ;
         P00AY3_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00AY3_A208WWPFormReferenceName = new string[] {""} ;
         P00AY3_A209WWPFormTitle = new string[] {""} ;
         P00AY3_A206WWPFormId = new short[1] ;
         P00AY3_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationdynamicformgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AY2_A240WWPFormType, P00AY2_A11OrganisationId, P00AY2_A209WWPFormTitle, P00AY2_A207WWPFormVersionNumber, P00AY2_A231WWPFormDate, P00AY2_A208WWPFormReferenceName, P00AY2_A206WWPFormId, P00AY2_A509OrganisationDynamicFormId
               }
               , new Object[] {
               P00AY3_A240WWPFormType, P00AY3_A11OrganisationId, P00AY3_A207WWPFormVersionNumber, P00AY3_A231WWPFormDate, P00AY3_A208WWPFormReferenceName, P00AY3_A209WWPFormTitle, P00AY3_A206WWPFormId, P00AY3_A509OrganisationDynamicFormId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private short AV17TFWWPFormVersionNumber ;
      private short AV18TFWWPFormVersionNumber_To ;
      private short AV19TFWWPFormLatestVersionNumber ;
      private short AV20TFWWPFormLatestVersionNumber_To ;
      private short AV44WWPFormType ;
      private short AV49Wp_organisationdynamicformds_1_wwpformtype ;
      private short AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber ;
      private short AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to ;
      private short AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber ;
      private short AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to ;
      private short A207WWPFormVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short A240WWPFormType ;
      private short A206WWPFormId ;
      private short W240WWPFormType ;
      private short GXt_int1 ;
      private int AV47GXV1 ;
      private int AV25InsertIndex ;
      private long AV31count ;
      private DateTime AV15TFWWPFormDate ;
      private DateTime AV16TFWWPFormDate_To ;
      private DateTime AV55Wp_organisationdynamicformds_7_tfwwpformdate ;
      private DateTime AV56Wp_organisationdynamicformds_8_tfwwpformdate_to ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool AV45WWPFormIsForDynamicValidations ;
      private bool BRKAY2 ;
      private bool BRKAY4 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV11TFWWPFormTitle ;
      private string AV12TFWWPFormTitle_Sel ;
      private string AV13TFWWPFormReferenceName ;
      private string AV14TFWWPFormReferenceName_Sel ;
      private string AV50Wp_organisationdynamicformds_2_filterfulltext ;
      private string AV51Wp_organisationdynamicformds_3_tfwwpformtitle ;
      private string AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel ;
      private string AV53Wp_organisationdynamicformds_5_tfwwpformreferencename ;
      private string AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel ;
      private string lV51Wp_organisationdynamicformds_3_tfwwpformtitle ;
      private string lV53Wp_organisationdynamicformds_5_tfwwpformreferencename ;
      private string A209WWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string AV26Option ;
      private Guid A11OrganisationId ;
      private Guid AV46OrganisationId ;
      private Guid A509OrganisationDynamicFormId ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private short[] P00AY2_A240WWPFormType ;
      private Guid[] P00AY2_A11OrganisationId ;
      private string[] P00AY2_A209WWPFormTitle ;
      private short[] P00AY2_A207WWPFormVersionNumber ;
      private DateTime[] P00AY2_A231WWPFormDate ;
      private string[] P00AY2_A208WWPFormReferenceName ;
      private short[] P00AY2_A206WWPFormId ;
      private Guid[] P00AY2_A509OrganisationDynamicFormId ;
      private short[] P00AY3_A240WWPFormType ;
      private Guid[] P00AY3_A11OrganisationId ;
      private short[] P00AY3_A207WWPFormVersionNumber ;
      private DateTime[] P00AY3_A231WWPFormDate ;
      private string[] P00AY3_A208WWPFormReferenceName ;
      private string[] P00AY3_A209WWPFormTitle ;
      private short[] P00AY3_A206WWPFormId ;
      private Guid[] P00AY3_A509OrganisationDynamicFormId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wp_organisationdynamicformgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AY2( IGxContext context ,
                                             string AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel ,
                                             string AV51Wp_organisationdynamicformds_3_tfwwpformtitle ,
                                             string AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel ,
                                             string AV53Wp_organisationdynamicformds_5_tfwwpformreferencename ,
                                             DateTime AV55Wp_organisationdynamicformds_7_tfwwpformdate ,
                                             DateTime AV56Wp_organisationdynamicformds_8_tfwwpformdate_to ,
                                             short AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber ,
                                             short AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to ,
                                             string A209WWPFormTitle ,
                                             string A208WWPFormReferenceName ,
                                             DateTime A231WWPFormDate ,
                                             short A207WWPFormVersionNumber ,
                                             string AV50Wp_organisationdynamicformds_2_filterfulltext ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber ,
                                             short AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to ,
                                             Guid A11OrganisationId ,
                                             Guid AV46OrganisationId ,
                                             short AV49Wp_organisationdynamicformds_1_wwpformtype ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.WWPFormType, T1.OrganisationId, T2.WWPFormTitle, T1.WWPFormVersionNumber, T2.WWPFormDate, T2.WWPFormReferenceName, T1.WWPFormId, T1.OrganisationDynamicFormId FROM (Trn_OrganisationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T2.WWPFormType = :AV49Wp_organisationdynamicformds_1_wwpformtype)");
         AddWhere(sWhereString, "(T1.OrganisationId = :AV46OrganisationId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wp_organisationdynamicformds_3_tfwwpformtitle)) ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormTitle like :lV51Wp_organisationdynamicformds_3_tfwwpformtitle)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormTitle = ( :AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormTitle))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationdynamicformds_5_tfwwpformreferencename)) ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormReferenceName like :lV53Wp_organisationdynamicformds_5_tfwwpformreferencename)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormReferenceName = ( :AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormReferenceName))=0))");
         }
         if ( ! (DateTime.MinValue==AV55Wp_organisationdynamicformds_7_tfwwpformdate) )
         {
            AddWhere(sWhereString, "(T2.WWPFormDate >= :AV55Wp_organisationdynamicformds_7_tfwwpformdate)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Wp_organisationdynamicformds_8_tfwwpformdate_to) )
         {
            AddWhere(sWhereString, "(T2.WWPFormDate <= :AV56Wp_organisationdynamicformds_8_tfwwpformdate_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.WWPFormType, T2.WWPFormTitle";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00AY3( IGxContext context ,
                                             string AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel ,
                                             string AV51Wp_organisationdynamicformds_3_tfwwpformtitle ,
                                             string AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel ,
                                             string AV53Wp_organisationdynamicformds_5_tfwwpformreferencename ,
                                             DateTime AV55Wp_organisationdynamicformds_7_tfwwpformdate ,
                                             DateTime AV56Wp_organisationdynamicformds_8_tfwwpformdate_to ,
                                             short AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber ,
                                             short AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to ,
                                             string A209WWPFormTitle ,
                                             string A208WWPFormReferenceName ,
                                             DateTime A231WWPFormDate ,
                                             short A207WWPFormVersionNumber ,
                                             string AV50Wp_organisationdynamicformds_2_filterfulltext ,
                                             short A219WWPFormLatestVersionNumber ,
                                             short AV59Wp_organisationdynamicformds_11_tfwwpformlatestversionnumber ,
                                             short AV60Wp_organisationdynamicformds_12_tfwwpformlatestversionnumber_to ,
                                             Guid A11OrganisationId ,
                                             Guid AV46OrganisationId ,
                                             short AV49Wp_organisationdynamicformds_1_wwpformtype ,
                                             short A240WWPFormType )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.WWPFormType, T1.OrganisationId, T1.WWPFormVersionNumber, T2.WWPFormDate, T2.WWPFormReferenceName, T2.WWPFormTitle, T1.WWPFormId, T1.OrganisationDynamicFormId FROM (Trn_OrganisationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
         AddWhere(sWhereString, "(T2.WWPFormType = :AV49Wp_organisationdynamicformds_1_wwpformtype)");
         AddWhere(sWhereString, "(T1.OrganisationId = :AV46OrganisationId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wp_organisationdynamicformds_3_tfwwpformtitle)) ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormTitle like :lV51Wp_organisationdynamicformds_3_tfwwpformtitle)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel)) && ! ( StringUtil.StrCmp(AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormTitle = ( :AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormTitle))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wp_organisationdynamicformds_5_tfwwpformreferencename)) ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormReferenceName like :lV53Wp_organisationdynamicformds_5_tfwwpformreferencename)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel)) && ! ( StringUtil.StrCmp(AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WWPFormReferenceName = ( :AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel, context.GetMessage( "<#Empty#>", "")) == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.WWPFormReferenceName))=0))");
         }
         if ( ! (DateTime.MinValue==AV55Wp_organisationdynamicformds_7_tfwwpformdate) )
         {
            AddWhere(sWhereString, "(T2.WWPFormDate >= :AV55Wp_organisationdynamicformds_7_tfwwpformdate)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Wp_organisationdynamicformds_8_tfwwpformdate_to) )
         {
            AddWhere(sWhereString, "(T2.WWPFormDate <= :AV56Wp_organisationdynamicformds_8_tfwwpformdate_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber >= :AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to) )
         {
            AddWhere(sWhereString, "(T1.WWPFormVersionNumber <= :AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.WWPFormType, T1.WWPFormId, T1.WWPFormVersionNumber";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AY2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] );
               case 1 :
                     return conditional_P00AY3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00AY2;
          prmP00AY2 = new Object[] {
          new ParDef("AV49Wp_organisationdynamicformds_1_wwpformtype",GXType.Int16,1,0) ,
          new ParDef("AV46OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV51Wp_organisationdynamicformds_3_tfwwpformtitle",GXType.VarChar,100,0) ,
          new ParDef("AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationdynamicformds_5_tfwwpformreferencename",GXType.VarChar,100,0) ,
          new ParDef("AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
          new ParDef("AV55Wp_organisationdynamicformds_7_tfwwpformdate",GXType.DateTime,8,5) ,
          new ParDef("AV56Wp_organisationdynamicformds_8_tfwwpformdate_to",GXType.DateTime,8,5) ,
          new ParDef("AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber",GXType.Int16,4,0) ,
          new ParDef("AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to",GXType.Int16,4,0)
          };
          Object[] prmP00AY3;
          prmP00AY3 = new Object[] {
          new ParDef("AV49Wp_organisationdynamicformds_1_wwpformtype",GXType.Int16,1,0) ,
          new ParDef("AV46OrganisationId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV51Wp_organisationdynamicformds_3_tfwwpformtitle",GXType.VarChar,100,0) ,
          new ParDef("AV52Wp_organisationdynamicformds_4_tfwwpformtitle_sel",GXType.VarChar,100,0) ,
          new ParDef("lV53Wp_organisationdynamicformds_5_tfwwpformreferencename",GXType.VarChar,100,0) ,
          new ParDef("AV54Wp_organisationdynamicformds_6_tfwwpformreferencename_sel",GXType.VarChar,100,0) ,
          new ParDef("AV55Wp_organisationdynamicformds_7_tfwwpformdate",GXType.DateTime,8,5) ,
          new ParDef("AV56Wp_organisationdynamicformds_8_tfwwpformdate_to",GXType.DateTime,8,5) ,
          new ParDef("AV57Wp_organisationdynamicformds_9_tfwwpformversionnumber",GXType.Int16,4,0) ,
          new ParDef("AV58Wp_organisationdynamicformds_10_tfwwpformversionnumber_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AY3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AY3,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
