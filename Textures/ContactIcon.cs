
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
        //
        public static ContactIcon Generic { get { return new ContactIcon("CHAR_DEFAULT"); } }
        public static ContactIcon Abigail { get { return new ContactIcon("CHAR_ABIGAIL"); } }
        public static ContactIcon AllCharacters { get { return new ContactIcon("CHAR_ALL_PLAYERS_CONF"); } }
        public static ContactIcon Amanda { get { return new ContactIcon("CHAR_AMANDA"); } }
        public static ContactIcon Ammunation { get { return new ContactIcon("CHAR_AMMUNATION"); } }
        public static ContactIcon Andreas { get { return new ContactIcon("CHAR_ANDREAS"); } }
        public static ContactIcon Antonia { get { return new ContactIcon("CHAR_ANTONIA"); } }
        public static ContactIcon Arthur { get { return new ContactIcon("CHAR_ARTHUR"); } }
        public static ContactIcon Ashley { get { return new ContactIcon("CHAR_ASHLEY"); } }
        public static ContactIcon BankOfLiberty { get { return new ContactIcon("CHAR_BANK_BOL"); } }
        public static ContactIcon FleecaBank { get { return new ContactIcon("CHAR_BANK_FLEECA"); } }
        public static ContactIcon MazeBank { get { return new ContactIcon("CHAR_BANK_MAZE"); } }
        public static ContactIcon Barry { get { return new ContactIcon("CHAR_BARRY"); } }
        public static ContactIcon Beverly { get { return new ContactIcon("CHAR_BEVERLY"); } }
        public static ContactIcon Bikesite { get { return new ContactIcon("CHAR_BIKESITE"); } }
        public static ContactIcon Blank { get { return new ContactIcon("CHAR_BLANK_ENTRY"); } }
        public static ContactIcon Blimp { get { return new ContactIcon("CHAR_BLIMP"); } }
        public static ContactIcon Blocked { get { return new ContactIcon("CHAR_BLOCKED"); } }
        public static ContactIcon Boatsite { get { return new ContactIcon("CHAR_BOATSITE"); } }
        public static ContactIcon BrokenDownGirl { get { return new ContactIcon("CHAR_BROKEN_DOWN_GIRL"); } }
        public static ContactIcon Bugstars { get { return new ContactIcon("CHAR_BUGSTARS"); } }
        public static ContactIcon Emergency { get { return new ContactIcon("CHAR_CALL911"); } }
        public static ContactIcon LegendaryMotorsport { get { return new ContactIcon("CHAR_CARSITE"); } }
        public static ContactIcon SSASuperAutos { get { return new ContactIcon("CHAR_CARSITE2"); } }
        public static ContactIcon Castro { get { return new ContactIcon("CHAR_CASTRO"); } }
        public static ContactIcon ChatIcon { get { return new ContactIcon("CHAR_CHAT_CALL"); } }
        public static ContactIcon Chef { get { return new ContactIcon("CHAR_CHEF"); } }
        public static ContactIcon Cheng { get { return new ContactIcon("CHAR_CHENG"); } }
        public static ContactIcon ChengSr { get { return new ContactIcon("CHAR_CHENGSR"); } }
        public static ContactIcon Chop { get { return new ContactIcon("CHAR_CHOP"); } }
        public static ContactIcon CreatorPortraits { get { return new ContactIcon("CHAR_CREATOR_PORTRAITS"); } }
        public static ContactIcon Cris { get { return new ContactIcon("CHAR_CRIS"); } }
        public static ContactIcon Dave { get { return new ContactIcon("CHAR_DAVE"); } }
        public static ContactIcon Denise { get { return new ContactIcon("CHAR_DENISE"); } }
        public static ContactIcon DetonateBomb { get { return new ContactIcon("CHAR_DETONATEBOMB"); } }
        public static ContactIcon DetonatePhone { get { return new ContactIcon("CHAR_DETONATEPHONE"); } }
        public static ContactIcon Devin { get { return new ContactIcon("CHAR_DEVIN"); } }
        public static ContactIcon DialASub { get { return new ContactIcon("CHAR_DIAL_A_SUB"); } }
        public static ContactIcon Dom { get { return new ContactIcon("CHAR_DOM"); } }
        public static ContactIcon DomesticGirl { get { return new ContactIcon("CHAR_DOMESTIC_GIRL"); } }
        public static ContactIcon Dreyfuss { get { return new ContactIcon("CHAR_DREYFUSS"); } }
        public static ContactIcon DrFriedlander { get { return new ContactIcon("CHAR_DR_FRIEDLANDER"); } }
        public static ContactIcon Epsilon { get { return new ContactIcon("CHAR_EPSILON"); } }
        public static ContactIcon EstateAgent { get { return new ContactIcon("CHAR_ESTATE_AGENT"); } }
        public static ContactIcon Facebook { get { return new ContactIcon("CHAR_FACEBOOK"); } }
        public static ContactIcon Filmnoir { get { return new ContactIcon("CHAR_FILMNOIR"); } }
        public static ContactIcon Floyd { get { return new ContactIcon("CHAR_FLOYD"); } }
        public static ContactIcon Franklin { get { return new ContactIcon("CHAR_FRANKLIN"); } }
        public static ContactIcon FranklinTrevor { get { return new ContactIcon("CHAR_FRANK_TREV_CONF"); } }
        public static ContactIcon GayMilitary { get { return new ContactIcon("CHAR_GAYMILITARY"); } }
        public static ContactIcon Hao { get { return new ContactIcon("CHAR_HAO"); } }
        public static ContactIcon HitcherGirl { get { return new ContactIcon("CHAR_HITCHER_GIRL"); } }
        public static ContactIcon Human { get { return new ContactIcon("CHAR_HUMANDEFAULT"); } }
        public static ContactIcon Hunter { get { return new ContactIcon("CHAR_HUNTER"); } }
        public static ContactIcon Jimmy { get { return new ContactIcon("CHAR_JIMMY"); } }
        public static ContactIcon JimmyBoston { get { return new ContactIcon("CHAR_JIMMY_BOSTON"); } }
        public static ContactIcon Joe { get { return new ContactIcon("CHAR_JOE"); } }
        public static ContactIcon Josef { get { return new ContactIcon("CHAR_JOSEF"); } }
        public static ContactIcon Josh { get { return new ContactIcon("CHAR_JOSH"); } }
        public static ContactIcon Lamar { get { return new ContactIcon("CHAR_LAMAR"); } }
        public static ContactIcon Lazlow { get { return new ContactIcon("CHAR_LAZLOW"); } }
        public static ContactIcon Lester { get { return new ContactIcon("CHAR_LESTER"); } }
        public static ContactIcon Skull { get { return new ContactIcon("CHAR_LESTER_DEATHWISH"); } }
        public static ContactIcon LesterFranklin { get { return new ContactIcon("CHAR_LEST_FRANK_CONF"); } }
        public static ContactIcon LesterMichael { get { return new ContactIcon("CHAR_LEST_MIKE_CONF"); } }
        public static ContactIcon Lifeinvader { get { return new ContactIcon("CHAR_LIFEINVADER"); } }
        public static ContactIcon LSCustoms { get { return new ContactIcon("CHAR_LS_CUSTOMS"); } }
        public static ContactIcon LSTouristBoard { get { return new ContactIcon("CHAR_LS_TOURIST_BOARD"); } }
        public static ContactIcon Manuel { get { return new ContactIcon("CHAR_MANUEL"); } }
        public static ContactIcon Marnie { get { return new ContactIcon("CHAR_MARNIE"); } }
        public static ContactIcon Martin { get { return new ContactIcon("CHAR_MARTIN"); } }
        public static ContactIcon MaryAnn { get { return new ContactIcon("CHAR_MARY_ANN"); } }
        public static ContactIcon Maude { get { return new ContactIcon("CHAR_MAUDE"); } }
        public static ContactIcon Mechanic { get { return new ContactIcon("CHAR_MECHANIC"); } }
        public static ContactIcon Michael { get { return new ContactIcon("CHAR_MICHAEL"); } }
        public static ContactIcon MichaelFranklin { get { return new ContactIcon("CHAR_MIKE_FRANK_CONF"); } }
        public static ContactIcon MichaelTrevor { get { return new ContactIcon("CHAR_MIKE_TREV_CONF"); } }
        public static ContactIcon Milsite { get { return new ContactIcon("CHAR_MILSITE"); } }
        public static ContactIcon Minotaur { get { return new ContactIcon("CHAR_MINOTAUR"); } }
        public static ContactIcon Molly { get { return new ContactIcon("CHAR_MOLLY"); } }
        public static ContactIcon MP_ArmyContact { get { return new ContactIcon("CHAR_MP_ARMY_CONTACT"); } }
        public static ContactIcon MP_BikerBoss { get { return new ContactIcon("CHAR_MP_BIKER_BOSS"); } }
        public static ContactIcon MP_BikerMechanic { get { return new ContactIcon("CHAR_MP_BIKER_MECHANIC"); } }
        public static ContactIcon MP_Brucie { get { return new ContactIcon("CHAR_MP_BRUCIE"); } }
        public static ContactIcon MP_Detonatephone { get { return new ContactIcon("CHAR_MP_DETONATEPHONE"); } }
        public static ContactIcon MP_FamBoss { get { return new ContactIcon("CHAR_MP_FAM_BOSS"); } }
        public static ContactIcon MP_FibContact { get { return new ContactIcon("CHAR_MP_FIB_CONTACT"); } }
        public static ContactIcon MP_FmContact { get { return new ContactIcon("CHAR_MP_FM_CONTACT"); } }
        public static ContactIcon MP_Gerald { get { return new ContactIcon("CHAR_MP_GERALD"); } }
        public static ContactIcon MP_Julio { get { return new ContactIcon("CHAR_MP_JULIO"); } }
        public static ContactIcon MP_Mechanic { get { return new ContactIcon("CHAR_MP_MECHANIC"); } }
        public static ContactIcon MP_Merryweather { get { return new ContactIcon("CHAR_MP_MERRYWEATHER"); } }
        public static ContactIcon MP_MexBoss { get { return new ContactIcon("CHAR_MP_MEX_BOSS"); } }
        public static ContactIcon MP_MexDocks { get { return new ContactIcon("CHAR_MP_MEX_DOCKS"); } }
        public static ContactIcon MP_MexLt { get { return new ContactIcon("CHAR_MP_MEX_LT"); } }
        public static ContactIcon MP_MorsMutual { get { return new ContactIcon("CHAR_MP_MORS_MUTUAL"); } }
        public static ContactIcon MP_ProfBoss { get { return new ContactIcon("CHAR_MP_PROF_BOSS"); } }
        public static ContactIcon MP_RayLavoy { get { return new ContactIcon("CHAR_MP_RAY_LAVOY"); } }
        public static ContactIcon MP_Roberto { get { return new ContactIcon("CHAR_MP_ROBERTO"); } }
        public static ContactIcon MP_Snitch { get { return new ContactIcon("CHAR_MP_SNITCH"); } }
        public static ContactIcon MP_Stretch { get { return new ContactIcon("CHAR_MP_STRETCH"); } }
        public static ContactIcon MP_StripclubPr { get { return new ContactIcon("CHAR_MP_STRIPCLUB_PR"); } }
        public static ContactIcon MrsThornhill { get { return new ContactIcon("CHAR_MRS_THORNHILL"); } }
        public static ContactIcon Multiplayer { get { return new ContactIcon("CHAR_MULTIPLAYER"); } }
        public static ContactIcon Nigel { get { return new ContactIcon("CHAR_NIGEL"); } }
        public static ContactIcon Omega { get { return new ContactIcon("CHAR_OMEGA"); } }
        public static ContactIcon Oneil { get { return new ContactIcon("CHAR_ONEIL"); } }
        public static ContactIcon Ortega { get { return new ContactIcon("CHAR_ORTEGA"); } }
        public static ContactIcon Oscar { get { return new ContactIcon("CHAR_OSCAR"); } }
        public static ContactIcon Patricia { get { return new ContactIcon("CHAR_PATRICIA"); } }
        public static ContactIcon Pegasus { get { return new ContactIcon("CHAR_PEGASUS_DELIVERY"); } }
        public static ContactIcon Planesite { get { return new ContactIcon("CHAR_PLANESITE"); } }
        public static ContactIcon Property_ArmsTrafficking { get { return new ContactIcon("CHAR_PROPERTY_ARMS_TRAFFICKING"); } }
        public static ContactIcon Property_BarAirport { get { return new ContactIcon("CHAR_PROPERTY_BAR_AIRPORT"); } }
        public static ContactIcon Property_BarBayview { get { return new ContactIcon("CHAR_PROPERTY_BAR_BAYVIEW"); } }
        public static ContactIcon Property_BarCafeRojo { get { return new ContactIcon("CHAR_PROPERTY_BAR_CAFE_ROJO"); } }
        public static ContactIcon Property_BarCockotoos { get { return new ContactIcon("CHAR_PROPERTY_BAR_COCKOTOOS"); } }
        public static ContactIcon Property_BarEclipse { get { return new ContactIcon("CHAR_PROPERTY_BAR_ECLIPSE"); } }
        public static ContactIcon Property_BarFes { get { return new ContactIcon("CHAR_PROPERTY_BAR_FES"); } }
        public static ContactIcon Property_BarHenHouse { get { return new ContactIcon("CHAR_PROPERTY_BAR_HEN_HOUSE"); } }
        public static ContactIcon Property_BarHiMen { get { return new ContactIcon("CHAR_PROPERTY_BAR_HI_MEN"); } }
        public static ContactIcon Property_BarHookies { get { return new ContactIcon("CHAR_PROPERTY_BAR_HOOKIES"); } }
        public static ContactIcon Property_BarIrish { get { return new ContactIcon("CHAR_PROPERTY_BAR_IRISH"); } }
        public static ContactIcon Property_BarLesBianco { get { return new ContactIcon("CHAR_PROPERTY_BAR_LES_BIANCO"); } }
        public static ContactIcon Property_BarMirrorPark { get { return new ContactIcon("CHAR_PROPERTY_BAR_MIRROR_PARK"); } }
        public static ContactIcon Property_BarPitchers { get { return new ContactIcon("CHAR_PROPERTY_BAR_PITCHERS"); } }
        public static ContactIcon Property_BarSingletons { get { return new ContactIcon("CHAR_PROPERTY_BAR_SINGLETONS"); } }
        public static ContactIcon Property_BarTequilala { get { return new ContactIcon("CHAR_PROPERTY_BAR_TEQUILALA"); } }
        public static ContactIcon Property_BarUnbranded { get { return new ContactIcon("CHAR_PROPERTY_BAR_UNBRANDED"); } }
        public static ContactIcon Property_CarModShop { get { return new ContactIcon("CHAR_PROPERTY_CAR_MOD_SHOP"); } }
        public static ContactIcon Property_CarScrapYard { get { return new ContactIcon("CHAR_PROPERTY_CAR_SCRAP_YARD"); } }
        public static ContactIcon Property_CinemaDowntown { get { return new ContactIcon("CHAR_PROPERTY_CINEMA_DOWNTOWN"); } }
        public static ContactIcon Property_CinemaMorningwood { get { return new ContactIcon("CHAR_PROPERTY_CINEMA_MORNINGWOOD"); } }
        public static ContactIcon Property_CinemaVinewood { get { return new ContactIcon("CHAR_PROPERTY_CINEMA_VINEWOOD"); } }
        public static ContactIcon Property_GolfClub { get { return new ContactIcon("CHAR_PROPERTY_GOLF_CLUB"); } }
        public static ContactIcon Property_PlaneScrapYard { get { return new ContactIcon("CHAR_PROPERTY_PLANE_SCRAP_YARD"); } }
        public static ContactIcon Property_SonarCollections { get { return new ContactIcon("CHAR_PROPERTY_SONAR_COLLECTIONS"); } }
        public static ContactIcon Property_TaxiLot { get { return new ContactIcon("CHAR_PROPERTY_TAXI_LOT"); } }
        public static ContactIcon Property_TowingImpound { get { return new ContactIcon("CHAR_PROPERTY_TOWING_IMPOUND"); } }
        public static ContactIcon Property_WeedShop { get { return new ContactIcon("CHAR_PROPERTY_WEED_SHOP"); } }
        public static ContactIcon Ron { get { return new ContactIcon("CHAR_RON"); } }
        public static ContactIcon Saeeda { get { return new ContactIcon("CHAR_SAEEDA"); } }
        public static ContactIcon Sasquatch { get { return new ContactIcon("CHAR_SASQUATCH"); } }
        public static ContactIcon Simeon { get { return new ContactIcon("CHAR_SIMEON"); } }
        public static ContactIcon SocialClub { get { return new ContactIcon("CHAR_SOCIAL_CLUB"); } }
        public static ContactIcon Solomon { get { return new ContactIcon("CHAR_SOLOMON"); } }
        public static ContactIcon Steve { get { return new ContactIcon("CHAR_STEVE"); } }
        public static ContactIcon SteveMichael { get { return new ContactIcon("CHAR_STEVE_MIKE_CONF"); } }
        public static ContactIcon SteveTrevor { get { return new ContactIcon("CHAR_STEVE_TREV_CONF"); } }
        public static ContactIcon Stretch { get { return new ContactIcon("CHAR_STRETCH"); } }
        public static ContactIcon StripperChastity { get { return new ContactIcon("CHAR_STRIPPER_CHASTITY"); } }
        public static ContactIcon StripperCheetah { get { return new ContactIcon("CHAR_STRIPPER_CHEETAH"); } }
        public static ContactIcon StripperFufu { get { return new ContactIcon("CHAR_STRIPPER_FUFU"); } }
        public static ContactIcon StripperInfernus { get { return new ContactIcon("CHAR_STRIPPER_INFERNUS"); } }
        public static ContactIcon StripperJuliet { get { return new ContactIcon("CHAR_STRIPPER_JULIET"); } }
        public static ContactIcon StripperNikki { get { return new ContactIcon("CHAR_STRIPPER_NIKKI"); } }
        public static ContactIcon StripperPeach { get { return new ContactIcon("CHAR_STRIPPER_PEACH"); } }
        public static ContactIcon StripperSapphire { get { return new ContactIcon("CHAR_STRIPPER_SAPPHIRE"); } }
        public static ContactIcon Tanisha { get { return new ContactIcon("CHAR_TANISHA"); } }
        public static ContactIcon Taxi { get { return new ContactIcon("CHAR_TAXI"); } }
        public static ContactIcon TaxiLiz { get { return new ContactIcon("CHAR_TAXI_LIZ"); } }
        public static ContactIcon TennisCoach { get { return new ContactIcon("CHAR_TENNIS_COACH"); } }
        public static ContactIcon Tonya { get { return new ContactIcon("CHAR_TOW_TONYA"); } }
        public static ContactIcon Tracey { get { return new ContactIcon("CHAR_TRACEY"); } }
        public static ContactIcon Trevor { get { return new ContactIcon("CHAR_TREVOR"); } }
        public static ContactIcon Wade { get { return new ContactIcon("CHAR_WADE"); } }
        public static ContactIcon Youtube { get { return new ContactIcon("CHAR_YOUTUBE"); } }
    }
}
