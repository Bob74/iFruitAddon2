
namespace iFruitAddon2
{
    /// <summary>
    /// Represents a contact icon that will be displayed in the phone.
    /// </summary>
    public sealed class ContactIcon : PhoneImage
    {
        /// <summary>
        /// Initialize the class.
        /// </summary>
        /// <param name="txd">Tips: put the name in lower case to appear bold in game.</param>            
        public ContactIcon(string txd) : base(txd)
        { }

        // Full list:
        // https://github.com/scripthookvdotnet/scripthookvdotnet/tree/main/source/scripting_v3/GTA.UI/Notification.cs

        /// <summary>Generic</summary>
        public static ContactIcon Generic { get { return new ContactIcon("CHAR_DEFAULT"); } }
        /// <summary>Abigail</summary>
        public static ContactIcon Abigail { get { return new ContactIcon("CHAR_ABIGAIL"); } }
        /// <summary>AllCharacters</summary>
        public static ContactIcon AllCharacters { get { return new ContactIcon("CHAR_ALL_PLAYERS_CONF"); } }
        /// <summary>Amanda</summary>
        public static ContactIcon Amanda { get { return new ContactIcon("CHAR_AMANDA"); } }
        /// <summary>Ammunation</summary>
        public static ContactIcon Ammunation { get { return new ContactIcon("CHAR_AMMUNATION"); } }
        /// <summary>Andreas</summary>
        public static ContactIcon Andreas { get { return new ContactIcon("CHAR_ANDREAS"); } }
        /// <summary>Antonia</summary>
        public static ContactIcon Antonia { get { return new ContactIcon("CHAR_ANTONIA"); } }
        /// <summary>Arthur</summary>
        public static ContactIcon Arthur { get { return new ContactIcon("CHAR_ARTHUR"); } }
        /// <summary>Ashley</summary>
        public static ContactIcon Ashley { get { return new ContactIcon("CHAR_ASHLEY"); } }
        /// <summary>BankOfLiberty</summary>
        public static ContactIcon BankOfLiberty { get { return new ContactIcon("CHAR_BANK_BOL"); } }
        /// <summary>FleecaBank</summary>
        public static ContactIcon FleecaBank { get { return new ContactIcon("CHAR_BANK_FLEECA"); } }
        /// <summary>MazeBank</summary>
        public static ContactIcon MazeBank { get { return new ContactIcon("CHAR_BANK_MAZE"); } }
        /// <summary>Barry</summary>
        public static ContactIcon Barry { get { return new ContactIcon("CHAR_BARRY"); } }
        /// <summary>Beverly</summary>
        public static ContactIcon Beverly { get { return new ContactIcon("CHAR_BEVERLY"); } }
        /// <summary>Bikesite</summary>
        public static ContactIcon Bikesite { get { return new ContactIcon("CHAR_BIKESITE"); } }
        /// <summary>Blank</summary>
        public static ContactIcon Blank { get { return new ContactIcon("CHAR_BLANK_ENTRY"); } }
        /// <summary>Blimp</summary>
        public static ContactIcon Blimp { get { return new ContactIcon("CHAR_BLIMP"); } }
        /// <summary>Blocked</summary>
        public static ContactIcon Blocked { get { return new ContactIcon("CHAR_BLOCKED"); } }
        /// <summary>Boatsite</summary>
        public static ContactIcon Boatsite { get { return new ContactIcon("CHAR_BOATSITE"); } }
        /// <summary>BrokenDownGirl</summary>
        public static ContactIcon BrokenDownGirl { get { return new ContactIcon("CHAR_BROKEN_DOWN_GIRL"); } }
        /// <summary>Bugstars</summary>
        public static ContactIcon Bugstars { get { return new ContactIcon("CHAR_BUGSTARS"); } }
        /// <summary>Emergency</summary>
        public static ContactIcon Emergency { get { return new ContactIcon("CHAR_CALL911"); } }
        /// <summary>LegendaryMotorsport</summary>
        public static ContactIcon LegendaryMotorsport { get { return new ContactIcon("CHAR_CARSITE"); } }
        /// <summary>SSASuperAutos</summary>
        public static ContactIcon SSASuperAutos { get { return new ContactIcon("CHAR_CARSITE2"); } }
        /// <summary>Castro</summary>
        public static ContactIcon Castro { get { return new ContactIcon("CHAR_CASTRO"); } }
        /// <summary>ChatIcon</summary>
        public static ContactIcon ChatIcon { get { return new ContactIcon("CHAR_CHAT_CALL"); } }
        /// <summary>Chef</summary>
        public static ContactIcon Chef { get { return new ContactIcon("CHAR_CHEF"); } }
        /// <summary>Cheng</summary>
        public static ContactIcon Cheng { get { return new ContactIcon("CHAR_CHENG"); } }
        /// <summary>ChengSr</summary>
        public static ContactIcon ChengSr { get { return new ContactIcon("CHAR_CHENGSR"); } }
        /// <summary>Chop</summary>
        public static ContactIcon Chop { get { return new ContactIcon("CHAR_CHOP"); } }
        /// <summary>CreatorPortraits</summary>
        public static ContactIcon CreatorPortraits { get { return new ContactIcon("CHAR_CREATOR_PORTRAITS"); } }
        /// <summary>Cris</summary>
        public static ContactIcon Cris { get { return new ContactIcon("CHAR_CRIS"); } }
        /// <summary>Dave</summary>
        public static ContactIcon Dave { get { return new ContactIcon("CHAR_DAVE"); } }
        ///<summary>Denise</summary>
        public static ContactIcon Denise { get { return new ContactIcon("CHAR_DENISE"); } }
        ///<summary>DetonateBomb</summary>
        public static ContactIcon DetonateBomb { get { return new ContactIcon("CHAR_DETONATEBOMB"); } }
        ///<summary>DetonatePhone</summary>
        public static ContactIcon DetonatePhone { get { return new ContactIcon("CHAR_DETONATEPHONE"); } }
        ///<summary>Devin</summary>
        public static ContactIcon Devin { get { return new ContactIcon("CHAR_DEVIN"); } }
        ///<summary>DialASub</summary>
        public static ContactIcon DialASub { get { return new ContactIcon("CHAR_DIAL_A_SUB"); } }
        ///<summary>Dom</summary>
        public static ContactIcon Dom { get { return new ContactIcon("CHAR_DOM"); } }
        ///<summary>DomesticGirl</summary>
        public static ContactIcon DomesticGirl { get { return new ContactIcon("CHAR_DOMESTIC_GIRL"); } }
        ///<summary>Dreyfuss</summary>
        public static ContactIcon Dreyfuss { get { return new ContactIcon("CHAR_DREYFUSS"); } }
        ///<summary>DrFriedlander</summary>
        public static ContactIcon DrFriedlander { get { return new ContactIcon("CHAR_DR_FRIEDLANDER"); } }
        ///<summary>Epsilon</summary>
        public static ContactIcon Epsilon { get { return new ContactIcon("CHAR_EPSILON"); } }
        ///<summary>EstateAgent</summary>
        public static ContactIcon EstateAgent { get { return new ContactIcon("CHAR_ESTATE_AGENT"); } }
        ///<summary>Facebook</summary>
        public static ContactIcon Facebook { get { return new ContactIcon("CHAR_FACEBOOK"); } }
        ///<summary>Filmnoir</summary>
        public static ContactIcon Filmnoir { get { return new ContactIcon("CHAR_FILMNOIR"); } }
        ///<summary>Floyd</summary>
        public static ContactIcon Floyd { get { return new ContactIcon("CHAR_FLOYD"); } }
        ///<summary>Franklin</summary>
        public static ContactIcon Franklin { get { return new ContactIcon("CHAR_FRANKLIN"); } }
        ///<summary>FranklinTrevor</summary>
        public static ContactIcon FranklinTrevor { get { return new ContactIcon("CHAR_FRANK_TREV_CONF"); } }
        ///<summary>GayMilitary</summary>
        public static ContactIcon GayMilitary { get { return new ContactIcon("CHAR_GAYMILITARY"); } }
        ///<summary>Hao</summary>
        public static ContactIcon Hao { get { return new ContactIcon("CHAR_HAO"); } }
        ///<summary>HitcherGirl</summary>
        public static ContactIcon HitcherGirl { get { return new ContactIcon("CHAR_HITCHER_GIRL"); } }
        ///<summary>Human</summary>
        public static ContactIcon Human { get { return new ContactIcon("CHAR_HUMANDEFAULT"); } }
        ///<summary>Hunter</summary>
        public static ContactIcon Hunter { get { return new ContactIcon("CHAR_HUNTER"); } }
        ///<summary>Jimmy</summary>
        public static ContactIcon Jimmy { get { return new ContactIcon("CHAR_JIMMY"); } }
        ///<summary>JimmyBoston</summary>
        public static ContactIcon JimmyBoston { get { return new ContactIcon("CHAR_JIMMY_BOSTON"); } }
        ///<summary>Joe</summary>
        public static ContactIcon Joe { get { return new ContactIcon("CHAR_JOE"); } }
        ///<summary>Josef</summary>
        public static ContactIcon Josef { get { return new ContactIcon("CHAR_JOSEF"); } }
        ///<summary>Josh</summary>
        public static ContactIcon Josh { get { return new ContactIcon("CHAR_JOSH"); } }
        ///<summary>Lamar</summary>
        public static ContactIcon Lamar { get { return new ContactIcon("CHAR_LAMAR"); } }
        ///<summary>Lazlow</summary>
        public static ContactIcon Lazlow { get { return new ContactIcon("CHAR_LAZLOW"); } }
        ///<summary>Lester</summary>
        public static ContactIcon Lester { get { return new ContactIcon("CHAR_LESTER"); } }
        ///<summary>Skull</summary>
        public static ContactIcon Skull { get { return new ContactIcon("CHAR_LESTER_DEATHWISH"); } }
        ///<summary>LesterFranklin</summary>
        public static ContactIcon LesterFranklin { get { return new ContactIcon("CHAR_LEST_FRANK_CONF"); } }
        ///<summary>LesterMichael</summary>
        public static ContactIcon LesterMichael { get { return new ContactIcon("CHAR_LEST_MIKE_CONF"); } }
        ///<summary>Lifeinvader</summary>
        public static ContactIcon Lifeinvader { get { return new ContactIcon("CHAR_LIFEINVADER"); } }
        ///<summary>LSCustoms</summary>
        public static ContactIcon LSCustoms { get { return new ContactIcon("CHAR_LS_CUSTOMS"); } }
        ///<summary>LSTouristBoard</summary>
        public static ContactIcon LSTouristBoard { get { return new ContactIcon("CHAR_LS_TOURIST_BOARD"); } }
        ///<summary>Manuel</summary>
        public static ContactIcon Manuel { get { return new ContactIcon("CHAR_MANUEL"); } }
        ///<summary>Marnie</summary>
        public static ContactIcon Marnie { get { return new ContactIcon("CHAR_MARNIE"); } }
        ///<summary>Martin</summary>
        public static ContactIcon Martin { get { return new ContactIcon("CHAR_MARTIN"); } }
        ///<summary>MaryAnn</summary>
        public static ContactIcon MaryAnn { get { return new ContactIcon("CHAR_MARY_ANN"); } }
        ///<summary>Maude</summary>
        public static ContactIcon Maude { get { return new ContactIcon("CHAR_MAUDE"); } }
        ///<summary>Mechanic</summary>
        public static ContactIcon Mechanic { get { return new ContactIcon("CHAR_MECHANIC"); } }
        ///<summary>Michael</summary>
        public static ContactIcon Michael { get { return new ContactIcon("CHAR_MICHAEL"); } }
        ///<summary>MichaelFranklin</summary>
        public static ContactIcon MichaelFranklin { get { return new ContactIcon("CHAR_MIKE_FRANK_CONF"); } }
        ///<summary>MichaelTrevor</summary>
        public static ContactIcon MichaelTrevor { get { return new ContactIcon("CHAR_MIKE_TREV_CONF"); } }
        ///<summary>Milsite</summary>
        public static ContactIcon Milsite { get { return new ContactIcon("CHAR_MILSITE"); } }
        ///<summary>Minotaur</summary>
        public static ContactIcon Minotaur { get { return new ContactIcon("CHAR_MINOTAUR"); } }
        ///<summary>Molly</summary>
        public static ContactIcon Molly { get { return new ContactIcon("CHAR_MOLLY"); } }
        ///<summary>MP_ArmyContact</summary>
        public static ContactIcon MP_ArmyContact { get { return new ContactIcon("CHAR_MP_ARMY_CONTACT"); } }
        ///<summary>MP_BikerBoss</summary>
        public static ContactIcon MP_BikerBoss { get { return new ContactIcon("CHAR_MP_BIKER_BOSS"); } }
        ///<summary>MP_BikerMechanic</summary>
        public static ContactIcon MP_BikerMechanic { get { return new ContactIcon("CHAR_MP_BIKER_MECHANIC"); } }
        ///<summary>MP_Brucie</summary>
        public static ContactIcon MP_Brucie { get { return new ContactIcon("CHAR_MP_BRUCIE"); } }
        ///<summary>MP_Detonatephone</summary>
        public static ContactIcon MP_Detonatephone { get { return new ContactIcon("CHAR_MP_DETONATEPHONE"); } }
        ///<summary>MP_FamBoss</summary>
        public static ContactIcon MP_FamBoss { get { return new ContactIcon("CHAR_MP_FAM_BOSS"); } }
        ///<summary>MP_FibContact</summary>
        public static ContactIcon MP_FibContact { get { return new ContactIcon("CHAR_MP_FIB_CONTACT"); } }
        ///<summary>MP_FmContact</summary>
        public static ContactIcon MP_FmContact { get { return new ContactIcon("CHAR_MP_FM_CONTACT"); } }
        ///<summary>MP_Gerald</summary>
        public static ContactIcon MP_Gerald { get { return new ContactIcon("CHAR_MP_GERALD"); } }
        ///<summary>MP_Julio</summary>
        public static ContactIcon MP_Julio { get { return new ContactIcon("CHAR_MP_JULIO"); } }
        ///<summary>MP_Mechanic</summary>
        public static ContactIcon MP_Mechanic { get { return new ContactIcon("CHAR_MP_MECHANIC"); } }
        ///<summary>MP_Merryweather</summary>
        public static ContactIcon MP_Merryweather { get { return new ContactIcon("CHAR_MP_MERRYWEATHER"); } }
        ///<summary>MP_MexBoss</summary>
        public static ContactIcon MP_MexBoss { get { return new ContactIcon("CHAR_MP_MEX_BOSS"); } }
        ///<summary>MP_MexDocks</summary>
        public static ContactIcon MP_MexDocks { get { return new ContactIcon("CHAR_MP_MEX_DOCKS"); } }
        ///<summary>MP_MexLt</summary>
        public static ContactIcon MP_MexLt { get { return new ContactIcon("CHAR_MP_MEX_LT"); } }
        ///<summary>MP_MorsMutual</summary>
        public static ContactIcon MP_MorsMutual { get { return new ContactIcon("CHAR_MP_MORS_MUTUAL"); } }
        ///<summary>MP_ProfBoss</summary>
        public static ContactIcon MP_ProfBoss { get { return new ContactIcon("CHAR_MP_PROF_BOSS"); } }
        ///<summary>MP_RayLavoy</summary>
        public static ContactIcon MP_RayLavoy { get { return new ContactIcon("CHAR_MP_RAY_LAVOY"); } }
        ///<summary>MP_Roberto</summary>
        public static ContactIcon MP_Roberto { get { return new ContactIcon("CHAR_MP_ROBERTO"); } }
        ///<summary>MP_Snitch</summary>
        public static ContactIcon MP_Snitch { get { return new ContactIcon("CHAR_MP_SNITCH"); } }
        ///<summary>MP_Stretch</summary>
        public static ContactIcon MP_Stretch { get { return new ContactIcon("CHAR_MP_STRETCH"); } }
        ///<summary>MP_StripclubPr</summary>
        public static ContactIcon MP_StripclubPr { get { return new ContactIcon("CHAR_MP_STRIPCLUB_PR"); } }
        ///<summary>MrsThornhill</summary>
        public static ContactIcon MrsThornhill { get { return new ContactIcon("CHAR_MRS_THORNHILL"); } }
        ///<summary>Multiplayer</summary>
        public static ContactIcon Multiplayer { get { return new ContactIcon("CHAR_MULTIPLAYER"); } }
        ///<summary>Nigel</summary>
        public static ContactIcon Nigel { get { return new ContactIcon("CHAR_NIGEL"); } }
        ///<summary>Omega</summary>
        public static ContactIcon Omega { get { return new ContactIcon("CHAR_OMEGA"); } }
        ///<summary>Oneil</summary>
        public static ContactIcon Oneil { get { return new ContactIcon("CHAR_ONEIL"); } }
        ///<summary>Ortega</summary>
        public static ContactIcon Ortega { get { return new ContactIcon("CHAR_ORTEGA"); } }
        ///<summary>Oscar</summary>
        public static ContactIcon Oscar { get { return new ContactIcon("CHAR_OSCAR"); } }
        ///<summary>Patricia</summary>
        public static ContactIcon Patricia { get { return new ContactIcon("CHAR_PATRICIA"); } }
        ///<summary>Pegasus</summary>
        public static ContactIcon Pegasus { get { return new ContactIcon("CHAR_PEGASUS_DELIVERY"); } }
        ///<summary>Planesite</summary>
        public static ContactIcon Planesite { get { return new ContactIcon("CHAR_PLANESITE"); } }
        ///<summary>Property_ArmsTrafficking</summary>
        public static ContactIcon Property_ArmsTrafficking { get { return new ContactIcon("CHAR_PROPERTY_ARMS_TRAFFICKING"); } }
        ///<summary>Property_BarAirport</summary>
        public static ContactIcon Property_BarAirport { get { return new ContactIcon("CHAR_PROPERTY_BAR_AIRPORT"); } }
        ///<summary>Property_BarBayview</summary>
        public static ContactIcon Property_BarBayview { get { return new ContactIcon("CHAR_PROPERTY_BAR_BAYVIEW"); } }
        ///<summary>Property_BarCafeRojo</summary>
        public static ContactIcon Property_BarCafeRojo { get { return new ContactIcon("CHAR_PROPERTY_BAR_CAFE_ROJO"); } }
        ///<summary>Property_BarCockotoos</summary>
        public static ContactIcon Property_BarCockotoos { get { return new ContactIcon("CHAR_PROPERTY_BAR_COCKOTOOS"); } }
        ///<summary>Property_BarEclipse</summary>
        public static ContactIcon Property_BarEclipse { get { return new ContactIcon("CHAR_PROPERTY_BAR_ECLIPSE"); } }
        ///<summary>Property_BarFes</summary>
        public static ContactIcon Property_BarFes { get { return new ContactIcon("CHAR_PROPERTY_BAR_FES"); } }
        ///<summary>Property_BarHenHouse</summary>
        public static ContactIcon Property_BarHenHouse { get { return new ContactIcon("CHAR_PROPERTY_BAR_HEN_HOUSE"); } }
        ///<summary>Property_BarHiMen</summary>
        public static ContactIcon Property_BarHiMen { get { return new ContactIcon("CHAR_PROPERTY_BAR_HI_MEN"); } }
        ///<summary>Property_BarHookies</summary>
        public static ContactIcon Property_BarHookies { get { return new ContactIcon("CHAR_PROPERTY_BAR_HOOKIES"); } }
        ///<summary>Property_BarIrish</summary>
        public static ContactIcon Property_BarIrish { get { return new ContactIcon("CHAR_PROPERTY_BAR_IRISH"); } }
        ///<summary>Property_BarLesBianco</summary>
        public static ContactIcon Property_BarLesBianco { get { return new ContactIcon("CHAR_PROPERTY_BAR_LES_BIANCO"); } }
        ///<summary>Property_BarMirrorPark</summary>
        public static ContactIcon Property_BarMirrorPark { get { return new ContactIcon("CHAR_PROPERTY_BAR_MIRROR_PARK"); } }
        ///<summary>Property_BarPitchers</summary>
        public static ContactIcon Property_BarPitchers { get { return new ContactIcon("CHAR_PROPERTY_BAR_PITCHERS"); } }
        ///<summary>Property_BarSingletons</summary>
        public static ContactIcon Property_BarSingletons { get { return new ContactIcon("CHAR_PROPERTY_BAR_SINGLETONS"); } }
        ///<summary>Property_BarTequilala</summary>
        public static ContactIcon Property_BarTequilala { get { return new ContactIcon("CHAR_PROPERTY_BAR_TEQUILALA"); } }
        ///<summary>Property_BarUnbranded</summary>
        public static ContactIcon Property_BarUnbranded { get { return new ContactIcon("CHAR_PROPERTY_BAR_UNBRANDED"); } }
        ///<summary>Property_CarModShop</summary>
        public static ContactIcon Property_CarModShop { get { return new ContactIcon("CHAR_PROPERTY_CAR_MOD_SHOP"); } }
        ///<summary>Property_CarScrapYard</summary>
        public static ContactIcon Property_CarScrapYard { get { return new ContactIcon("CHAR_PROPERTY_CAR_SCRAP_YARD"); } }
        ///<summary>Property_CinemaDowntown</summary>
        public static ContactIcon Property_CinemaDowntown { get { return new ContactIcon("CHAR_PROPERTY_CINEMA_DOWNTOWN"); } }
        ///<summary>Property_CinemaMorningwood</summary>
        public static ContactIcon Property_CinemaMorningwood { get { return new ContactIcon("CHAR_PROPERTY_CINEMA_MORNINGWOOD"); } }
        ///<summary>Property_CinemaVinewood</summary>
        public static ContactIcon Property_CinemaVinewood { get { return new ContactIcon("CHAR_PROPERTY_CINEMA_VINEWOOD"); } }
        ///<summary>Property_GolfClub</summary>
        public static ContactIcon Property_GolfClub { get { return new ContactIcon("CHAR_PROPERTY_GOLF_CLUB"); } }
        ///<summary>Property_PlaneScrapYard</summary>
        public static ContactIcon Property_PlaneScrapYard { get { return new ContactIcon("CHAR_PROPERTY_PLANE_SCRAP_YARD"); } }
        ///<summary>Property_SonarCollections</summary>
        public static ContactIcon Property_SonarCollections { get { return new ContactIcon("CHAR_PROPERTY_SONAR_COLLECTIONS"); } }
        ///<summary>Property_TaxiLot</summary>
        public static ContactIcon Property_TaxiLot { get { return new ContactIcon("CHAR_PROPERTY_TAXI_LOT"); } }
        ///<summary>Property_TowingImpound</summary>
        public static ContactIcon Property_TowingImpound { get { return new ContactIcon("CHAR_PROPERTY_TOWING_IMPOUND"); } }
        ///<summary>Property_WeedShop</summary>
        public static ContactIcon Property_WeedShop { get { return new ContactIcon("CHAR_PROPERTY_WEED_SHOP"); } }
        ///<summary>Ron</summary>
        public static ContactIcon Ron { get { return new ContactIcon("CHAR_RON"); } }
        ///<summary>Saeeda</summary>
        public static ContactIcon Saeeda { get { return new ContactIcon("CHAR_SAEEDA"); } }
        ///<summary>Sasquatch</summary>
        public static ContactIcon Sasquatch { get { return new ContactIcon("CHAR_SASQUATCH"); } }
        ///<summary>Simeon</summary>
        public static ContactIcon Simeon { get { return new ContactIcon("CHAR_SIMEON"); } }
        ///<summary>SocialClub</summary>
        public static ContactIcon SocialClub { get { return new ContactIcon("CHAR_SOCIAL_CLUB"); } }
        ///<summary>Solomon</summary>
        public static ContactIcon Solomon { get { return new ContactIcon("CHAR_SOLOMON"); } }
        ///<summary>Steve</summary>
        public static ContactIcon Steve { get { return new ContactIcon("CHAR_STEVE"); } }
        ///<summary>SteveMichael</summary>
        public static ContactIcon SteveMichael { get { return new ContactIcon("CHAR_STEVE_MIKE_CONF"); } }
        ///<summary>SteveTrevor</summary>
        public static ContactIcon SteveTrevor { get { return new ContactIcon("CHAR_STEVE_TREV_CONF"); } }
        ///<summary>Stretch</summary>
        public static ContactIcon Stretch { get { return new ContactIcon("CHAR_STRETCH"); } }
        ///<summary>StripperChastity</summary>
        public static ContactIcon StripperChastity { get { return new ContactIcon("CHAR_STRIPPER_CHASTITY"); } }
        ///<summary>StripperCheetah</summary>
        public static ContactIcon StripperCheetah { get { return new ContactIcon("CHAR_STRIPPER_CHEETAH"); } }
        ///<summary>StripperFufu</summary>
        public static ContactIcon StripperFufu { get { return new ContactIcon("CHAR_STRIPPER_FUFU"); } }
        ///<summary>StripperInfernus</summary>
        public static ContactIcon StripperInfernus { get { return new ContactIcon("CHAR_STRIPPER_INFERNUS"); } }
        ///<summary>StripperJuliet</summary>
        public static ContactIcon StripperJuliet { get { return new ContactIcon("CHAR_STRIPPER_JULIET"); } }
        ///<summary>StripperNikki</summary>
        public static ContactIcon StripperNikki { get { return new ContactIcon("CHAR_STRIPPER_NIKKI"); } }
        ///<summary>StripperPeach</summary>
        public static ContactIcon StripperPeach { get { return new ContactIcon("CHAR_STRIPPER_PEACH"); } }
        ///<summary>StripperSapphire</summary>
        public static ContactIcon StripperSapphire { get { return new ContactIcon("CHAR_STRIPPER_SAPPHIRE"); } }
        ///<summary>Tanisha</summary>
        public static ContactIcon Tanisha { get { return new ContactIcon("CHAR_TANISHA"); } }
        ///<summary>Taxi</summary>
        public static ContactIcon Taxi { get { return new ContactIcon("CHAR_TAXI"); } }
        ///<summary>TaxiLiz</summary>
        public static ContactIcon TaxiLiz { get { return new ContactIcon("CHAR_TAXI_LIZ"); } }
        ///<summary>TennisCoach</summary>
        public static ContactIcon TennisCoach { get { return new ContactIcon("CHAR_TENNIS_COACH"); } }
        ///<summary>Tonya</summary>
        public static ContactIcon Tonya { get { return new ContactIcon("CHAR_TOW_TONYA"); } }
        ///<summary>Tracey</summary>
        public static ContactIcon Tracey { get { return new ContactIcon("CHAR_TRACEY"); } }
        ///<summary>Trevor</summary>
        public static ContactIcon Trevor { get { return new ContactIcon("CHAR_TREVOR"); } }
        ///<summary>Wade</summary>
        public static ContactIcon Wade { get { return new ContactIcon("CHAR_WADE"); } }
        ///<summary>Youtube</summary>
        public static ContactIcon Youtube { get { return new ContactIcon("CHAR_YOUTUBE"); } }
    }
}
