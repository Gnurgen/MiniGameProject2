/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID AMBIENCE_PLAY = 1496310610U;
        static const AkUniqueID AMBIENCE_STOP = 3166394572U;
        static const AkUniqueID BREATH = 1326786195U;
        static const AkUniqueID ENDINGCOFFIN = 3113955711U;
        static const AkUniqueID FOOTSTEP = 1866025847U;
        static const AkUniqueID IDLE_SWITCH = 2274660714U;
        static const AkUniqueID MENU_BUTTON = 938529747U;
        static const AkUniqueID MONSTER_GROWL_PLAY = 2074283912U;
        static const AkUniqueID MONSTER_GROWL_STOP = 156883962U;
        static const AkUniqueID MONSTERAGGRO = 2653952097U;
        static const AkUniqueID MONSTERATTACK = 2621508965U;
        static const AkUniqueID MONSTERATTACKHIT = 2015956512U;
        static const AkUniqueID MONSTERSTEP = 1363742247U;
        static const AkUniqueID MUSICBOX_BROKEN_SWITCH = 2451362146U;
        static const AkUniqueID MUSICBOX_PAUSE = 2302208614U;
        static const AkUniqueID MUSICBOX_PLAY = 2089708342U;
        static const AkUniqueID MUSICBOX_RESUME = 3719125665U;
        static const AkUniqueID MUSICBOX_REWIND_PLAY = 672851034U;
        static const AkUniqueID MUSICBOX_REWIND_STOP = 2071830116U;
        static const AkUniqueID MUSICBOX_STOP = 2820245704U;
        static const AkUniqueID MUSICBOX_UNBROKEN_SWITCH = 1298383181U;
        static const AkUniqueID PUFF = 2076776060U;
        static const AkUniqueID RUN_SWITCH = 899311691U;
        static const AkUniqueID SET_STATE_FOREST = 1652873695U;
        static const AkUniqueID SET_STATE_GAME = 4207344442U;
        static const AkUniqueID SET_STATE_MENU = 2302270969U;
        static const AkUniqueID SET_STATE_VOID = 2075652242U;
        static const AkUniqueID WALK_SWITCH = 2857728357U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace ENDING
        {
            static const AkUniqueID GROUP = 3966194980U;

            namespace STATE
            {
                static const AkUniqueID FOREST = 491961918U;
                static const AkUniqueID VOID = 3370470011U;
            } // namespace STATE
        } // namespace ENDING

        namespace MENUS
        {
            static const AkUniqueID GROUP = 2604644515U;

            namespace STATE
            {
                static const AkUniqueID IN_GAME = 2967546505U;
                static const AkUniqueID IN_MENU = 1631528850U;
            } // namespace STATE
        } // namespace MENUS

    } // namespace STATES

    namespace SWITCHES
    {
        namespace MUSIC_BOX_MELODY
        {
            static const AkUniqueID GROUP = 3940572963U;

            namespace SWITCH
            {
                static const AkUniqueID BROKEN = 231230354U;
                static const AkUniqueID UNBROKEN = 2997862023U;
            } // namespace SWITCH
        } // namespace MUSIC_BOX_MELODY

        namespace STEPSWITCH
        {
            static const AkUniqueID GROUP = 2287157699U;

            namespace SWITCH
            {
                static const AkUniqueID IDLE = 1874288895U;
                static const AkUniqueID RUN = 712161704U;
                static const AkUniqueID WALK = 2108779966U;
            } // namespace SWITCH
        } // namespace STEPSWITCH

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID SS_AIR_FEAR = 1351367891U;
        static const AkUniqueID SS_AIR_FREEFALL = 3002758120U;
        static const AkUniqueID SS_AIR_FURY = 1029930033U;
        static const AkUniqueID SS_AIR_MONTH = 2648548617U;
        static const AkUniqueID SS_AIR_PRESENCE = 3847924954U;
        static const AkUniqueID SS_AIR_RPM = 822163944U;
        static const AkUniqueID SS_AIR_SIZE = 3074696722U;
        static const AkUniqueID SS_AIR_STORM = 3715662592U;
        static const AkUniqueID SS_AIR_TIMEOFDAY = 3203397129U;
        static const AkUniqueID SS_AIR_TURBULENCE = 4160247818U;
        static const AkUniqueID STAMINAPAR = 99298381U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID AMBIENCE = 85412153U;
        static const AkUniqueID ENVIRONMENTAL = 1973600711U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MASTER_SECONDARY_BUS = 805203703U;
        static const AkUniqueID MUSIC_BOX = 2758854753U;
        static const AkUniqueID SFX = 393239870U;
        static const AkUniqueID UI = 1551306167U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID FOREST_REVERB = 920301845U;
        static const AkUniqueID VOID_REVERB = 3356433602U;
    } // namespace AUX_BUSSES

}// namespace AK

#endif // __WWISE_IDS_H__
