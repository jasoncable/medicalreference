using System;

namespace Jaxosoft.TestData
{
    public enum DosageForm
    {
        [EnumImportValue(new string[] { "AEROSOL" })]
        Aerosol,
        [EnumImportValue(new string[] { "AEROSOL, FOAM" })]
        AerosolFoam,
        [EnumImportValue(new string[] { "AEROSOL, METERED" })]
        AerosolMetered,
        [EnumImportValue(new string[] { "AEROSOL, POWDER" })]
        AerosolPowder,
        [EnumImportValue(new string[] { "AEROSOL, SPRAY" })]
        AerosolSpray,
        [EnumImportValue(new string[] { "BAR, CHEWABLE" })]
        BarChewable,
        [EnumImportValue(new string[] { "BEAD" })]
        Bead,
        [EnumImportValue(new string[] { "CAPSULE" })]
        Capsule,
        [EnumImportValue(new string[] { "CAPSULE, COATED" })]
        CapsuleCoated,
        [EnumImportValue(new string[] { "CAPSULE, COATED PELLETS" })]
        CapsuleCoatedPellets,
        [EnumImportValue(new string[] { "CAPSULE, COATED, EXTENDED RELEASE" })]
        CapsuleCoatedExtendedRelease,
        [EnumImportValue(new string[] { "CAPSULE, DELAYED RELEASE" })]
        CapsuleDelayedRelease,
        [EnumImportValue(new string[] { "CAPSULE, DELAYED RELEASE PELLETS" })]
        CapsuleDelayedReleasePellets,
        [EnumImportValue(new string[] { "CAPSULE, EXTENDED RELEASE" })]
        CapsuleExtendedRelease,
        [EnumImportValue(new string[] { "CAPSULE, FILM COATED, EXTENDED RELEASE" })]
        CapsuleFilmCoatedExtendedRelease,
        [EnumImportValue(new string[] { "CAPSULE, GELATIN COATED" })]
        CapsuleGelatinCoated,
        [EnumImportValue(new string[] { "CAPSULE, LIQUID FILLED" })]
        CapsuleLiquidFilled,
        [EnumImportValue(new string[] { "CELLULAR SHEET" })]
        CellularSheet,
        [EnumImportValue(new string[] { "CHEWABLE GEL" })]
        ChewableGel,
        [EnumImportValue(new string[] { "CLOTH" })]
        Cloth,
        [EnumImportValue(new string[] { "CONCENTRATE" })]
        Concentrate,
        [EnumImportValue(new string[] { "CREAM" })]
        Cream,
        [EnumImportValue(new string[] { "CREAM, AUGMENTED" })]
        CreamAugmented,
        [EnumImportValue(new string[] { "CRYSTAL" })]
        Crystal,
        [EnumImportValue(new string[] { "DISC" })]
        Disc,
        [EnumImportValue(new string[] { "DOUCHE" })]
        Douche,
        [EnumImportValue(new string[] { "DRESSING" })]
        Dressing,
        [EnumImportValue(new string[] { "ELIXIR" })]
        Elixir,
        [EnumImportValue(new string[] { "EMULSION" })]
        Emulsion,
        [EnumImportValue(new string[] { "ENEMA" })]
        Enema,
        [EnumImportValue(new string[] { "EXTRACT" })]
        Extract,
        [EnumImportValue(new string[] { "FIBER, EXTENDED RELEASE" })]
        FiberExtendedRelease,
        [EnumImportValue(new string[] { "FILM" })]
        Film,
        [EnumImportValue(new string[] { "FILM, EXTENDED RELEASE" })]
        FilmExtendedRelease,
        [EnumImportValue(new string[] { "FILM, SOLUBLE" })]
        FilmSoluable,
        [EnumImportValue(new string[] { "FOR SOLUTION" })]
        ForSolution,
        [EnumImportValue(new string[] { "FOR SUSPENSION" })]
        ForSuspension,
        [EnumImportValue(new string[] { "FOR SUSPENSION, EXTENDED RELEASE" })]
        ForSuspensionExtendedRelease,
        [EnumImportValue(new string[] { "GAS" })]
        Gas,
        [EnumImportValue(new string[] { "GEL" })]
        Gel,
        [EnumImportValue(new string[] { "GEL, DENTIFRICE" })]
        GelDentifrice,
        [EnumImportValue(new string[] { "GEL, METERED" })]
        GelMetered,
        [EnumImportValue(new string[] { "GLOBULE" })]
        Globule,
        [EnumImportValue(new string[] { "GRANULE" })]
        Granule,
        [EnumImportValue(new string[] { "GRANULE, DELAYED RELEASE" })]
        GranuleDelayedRelease,
        [EnumImportValue(new string[] { "GRANULE, EFFERVESCENT" })]
        GranuleEffervescent,
        [EnumImportValue(new string[] { "GRANULE, FOR SOLUTION" })]
        GranuleForSolution,
        [EnumImportValue(new string[] { "GRANULE, FOR SUSPENSION" })]
        GranuleForSuspension,
        [EnumImportValue(new string[] { "GRANULE, FOR SUSPENSION, EXTENDED RELEASE" })]
        GranuleForSuspensionExtendedRelease,
        [EnumImportValue(new string[] { "GUM, CHEWING" })]
        GumChewing,
        [EnumImportValue(new string[] { "IMPLANT" })]
        Implant,
        [EnumImportValue(new string[] { "INHALANT" })]
        Inhalant,
        [EnumImportValue(new string[] { "INJECTABLE FOAM" })]
        InjectableFoam,
        [EnumImportValue(new string[] { "INJECTABLE, LIPOSOMAL" })]
        InjectableLiposomal,
        [EnumImportValue(new string[] { "INJECTION" })]
        Injection,
        [EnumImportValue(new string[] { "INJECTION, EMULSION" })]
        InjectionEmulsion,
        [EnumImportValue(new string[] { "INJECTION, LIPID COMPLEX" })]
        InjectionLipidComplex,
        [EnumImportValue(new string[] { "INJECTION, POWDER, FOR SOLUTION" })]
        InjectionPowerForSolution,
        [EnumImportValue(new string[] { "INJECTION, POWDER, FOR SUSPENSION" })]
        InjectionPowerForSuspension,
        [EnumImportValue(new string[] { "INJECTION, POWDER, FOR SUSPENSION, EXTENDED RELEASE" })]
        InjectionPowderForSuspensionExtendedRelease,
        [EnumImportValue(new string[] { "INJECTION, POWDER, LYOPHILIZED, FOR LIPOSOMAL SUSPENSION" })]
        InjectionPowderLyophilizedForLiposomalSuspension,
        [EnumImportValue(new string[] { "INJECTION, POWDER, LYOPHILIZED, FOR SOLUTION" })]
        InjectionPowderLyophilizedForSolution,
        [EnumImportValue(new string[] { "INJECTION, POWDER, LYOPHILIZED, FOR SUSPENSION" })]
        InjectionPowderLyophilizedForSuspension,
        [EnumImportValue(new string[] { "INJECTION, POWDER, LYOPHILIZED, FOR SUSPENSION, EXTENDED RELEASE" })]
        InjectionPowderLyophilizedForSuspensionExtendedRelease,
        [EnumImportValue(new string[] { "INJECTION, SOLUTION" })]
        InjectionSolution,
        [EnumImportValue(new string[] { "INJECTION, SOLUTION, CONCENTRATE" })]
        InjectionSolutionConcentrate,
        [EnumImportValue(new string[] { "INJECTION, SUSPENSION" })]
        InjectionSuspension,
        [EnumImportValue(new string[] { "INJECTION, SUSPENSION, EXTENDED RELEASE" })]
        InjectionSuspensionExtendedRelease,
        [EnumImportValue(new string[] { "INJECTION, SUSPENSION, LIPOSOMAL" })]
        InjectionSuspensionLiposomal,
        [EnumImportValue(new string[] { "INJECTION, SUSPENSION, SONICATED" })]
        InjectionSuspensionSonicated,
        [EnumImportValue(new string[] { "INSERT" })]
        Insert,
        [EnumImportValue(new string[] { "INSERT, EXTENDED RELEASE" })]
        InsertExtendedRelease,
        [EnumImportValue(new string[] { "INTRAUTERINE DEVICE" })]
        IntrauterineDevice,
        [EnumImportValue(new string[] { "IRRIGANT" })]
        Irrigant,
        [EnumImportValue(new string[] { "JELLY" })]
        Jelly,
        [EnumImportValue(new string[] { "KIT" })]
        Kit,
        [EnumImportValue(new string[] { "LINIMENT" })]
        Liniment,
        [EnumImportValue(new string[] { "LIPSTICK" })]
        Lipstick,
        [EnumImportValue(new string[] { "LIQUID" })]
        Liquid,
        [EnumImportValue(new string[] { "LIQUID, EXTENDED RELEASE" })]
        LiquidExtendedRelease,
        [EnumImportValue(new string[] { "LOTION" })]
        Lotion,
        [EnumImportValue(new string[] { "LOTION, AUGMENTED" })]
        LotionAugmented,
        [EnumImportValue(new string[] { "LOTION/SHAMPOO" })]
        LotionShampoo,
        [EnumImportValue(new string[] { "LOZENGE" })]
        Lozenge,
        [EnumImportValue(new string[] { "MOUTHWASH" })]
        Mouthwash,
        [EnumImportValue(new string[] { "NOT APPLICABLE" })]
        NotApplicable,
        [EnumImportValue(new string[] { "OIL" })]
        Oil,
        [EnumImportValue(new string[] { "OINTMENT" })]
        Ointment,
        [EnumImportValue(new string[] { "OINTMENT, AUGMENTED" })]
        OintmentAugmented,
        [EnumImportValue(new string[] { "PASTE" })]
        Paste,
        [EnumImportValue(new string[] { "PASTE, DENTIFRICE" })]
        PasteDentifrice,
        [EnumImportValue(new string[] { "PASTILLE" })]
        Pastille,
        [EnumImportValue(new string[] { "PATCH" })]
        Patch,
        [EnumImportValue(new string[] { "PATCH, EXTENDED RELEASE" })]
        PatchExtendedRelease,
        [EnumImportValue(new string[] { "PATCH, EXTENDED RELEASE, ELECTRICALLY CONTROLLED" })]
        PatchExtendedReleaseElectronicallyControlled,
        [EnumImportValue(new string[] { "PELLET" })]
        Pellet,
        [EnumImportValue(new string[] { "PELLET, IMPLANTABLE" })]
        PelletImplantable,
        [EnumImportValue(new string[] { "PELLETS, COATED, EXTENDED RELEASE" })]
        PelletsCoatedExtendedRelease,
        [EnumImportValue(new string[] { "PILL" })]
        Pill,
        [EnumImportValue(new string[] { "PLASTER" })]
        Plaster,
        [EnumImportValue(new string[] { "POULTICE" })]
        Poultice,
        [EnumImportValue(new string[] { "POWDER" })]
        Powder,
        [EnumImportValue(new string[] { "POWDER, DENTIFRICE" })]
        PowderDentifrice,
        [EnumImportValue(new string[] { "POWDER, FOR SOLUTION" })]
        PowderForSolution,
        [EnumImportValue(new string[] { "POWDER, FOR SUSPENSION" })]
        PowderForSuspension,
        [EnumImportValue(new string[] { "POWDER, METERED" })]
        PowderMetered,
        [EnumImportValue(new string[] { "RING" })]
        Ring,
        [EnumImportValue(new string[] { "RINSE" })]
        Rinse,
        [EnumImportValue(new string[] { "SALVE" })]
        Salve,
        [EnumImportValue(new string[] { "SHAMPOO" })]
        Shampoo,
        [EnumImportValue(new string[] { "SHAMPOO, SUSPENSION" })]
        ShampooSuspension,
        [EnumImportValue(new string[] { "SOAP" })]
        Soap,
        [EnumImportValue(new string[] { "SOLUTION" })]
        Solution,
        [EnumImportValue(new string[] { "SOLUTION, CONCENTRATE" })]
        SolutionConcentrate,
        [EnumImportValue(new string[] { "SOLUTION, FOR SLUSH" })]
        SolutionForSlush,
        [EnumImportValue(new string[] { "SOLUTION, GEL FORMING / DROPS", "SOLUTION, GEL FORMING/DROPS" })]
        SolutionGelFormingDrops,
        [EnumImportValue(new string[] { "SOLUTION, GEL FORMING, EXTENDED RELEASE" })]
        SolutionGelFormingExtendedRelease,
        [EnumImportValue(new string[] { "SOLUTION/ DROPS", "SOLUTION/DROPS","SOLUTION / DROPS" })]
        SolutionDrops,
        [EnumImportValue(new string[] { "SPONGE" })]
        Sponge,
        [EnumImportValue(new string[] { "SPRAY" })]
        Spray,
        [EnumImportValue(new string[] { "SPRAY, METERED" })]
        SprayMetered,
        [EnumImportValue(new string[] { "SPRAY, SUSPENSION" })]
        SpraySuspension,
        [EnumImportValue(new string[] { "STICK" })]
        Stick,
        [EnumImportValue(new string[] { "STRIP" })]
        Strip,
        [EnumImportValue(new string[] { "SUPPOSITORY" })]
        Suppository,
        [EnumImportValue(new string[] { "SUPPOSITORY, EXTENDED RELEASE" })]
        SuppositoryExtendedRelease,
        [EnumImportValue(new string[] { "SUSPENSION" })]
        Suspension,
        [EnumImportValue(new string[] { "SUSPENSION, EXTENDED RELEASE" })]
        SuspensionExtendedRelease,
        [EnumImportValue(new string[] { "SUSPENSION/ DROPS", "SUSPENSION/DROPS", "SUSPENSION / DROPS" })]
        SuspensionDrops,
        [EnumImportValue(new string[] { "SWAB" })]
        Swab,
        [EnumImportValue(new string[] { "SYRUP" })]
        Syrup,
        // merging these due to mismatches between OrangeBook and NDC
        // ... I don't know if we have the same problem with the different capsule types, for sure with tablets
        [EnumImportValue(new string[] { "TABLET", "TABLET, COATED", "TABLET, FILM COATED" })]
        Tablet,
        [EnumImportValue(new string[] { "TABLET, CHEWABLE" })]
        TabletChewable,
        [EnumImportValue(new string[] { "TABLET, CHEWABLE, EXTENDED RELEASE" })]
        TabletChewableExtendedRelease,
        //[EnumImportValue(new string[] { "TABLET, COATED" })]
        //TabletCoated,
        [EnumImportValue(new string[] { "TABLET, COATED PARTICLES" })]
        TabletCoatedParticles,
        [EnumImportValue(new string[] { "TABLET, DELAYED RELEASE" })]
        TabletDelayedRelease,
        [EnumImportValue(new string[] { "TABLET, DELAYED RELEASE PARTICLES" })]
        TabletDelayedReleaseParticles,
        [EnumImportValue(new string[] { "TABLET, EFFERVESCENT" })]
        TabletEffervescent,
        [EnumImportValue(new string[] { "TABLET, EXTENDED RELEASE" })]
        TabletExtendedRelease,
        //[EnumImportValue(new string[] { "TABLET, FILM COATED" })]
        //TabletFilmCoated,
        [EnumImportValue(new string[] { "TABLET, FILM COATED, EXTENDED RELEASE" })]
        TabletFilmCoatedExtendedRelease,
        [EnumImportValue(new string[] { "TABLET, FOR SOLUTION" })]
        TabletForSolution,
        [EnumImportValue(new string[] { "TABLET, FOR SUSPENSION" })]
        TabletForSuspension,
        [EnumImportValue(new string[] { "TABLET, MULTILAYER" })]
        TabletMultilayer,
        [EnumImportValue(new string[] { "TABLET, MULTILAYER, EXTENDED RELEASE" })]
        TabletMultilayerExtendedRelease,
        [EnumImportValue(new string[] { "TABLET, ORALLY DISINTEGRATING" })]
        TabletOrallyDisintegrating,
        [EnumImportValue(new string[] { "TABLET, ORALLY DISINTEGRATING, DELAYED RELEASE" })]
        TabletOrallyDisintegratingDelayedRelease,
        [EnumImportValue(new string[] { "TABLET, SOLUBLE" })]
        TabletSoluble,
        [EnumImportValue(new string[] { "TABLET, SUGAR COATED" })]
        TabletSugarCoated,
        [EnumImportValue(new string[] { "TABLET WITH SENSOR" })]
        TabletWithSensor,
        [EnumImportValue(new string[] { "TAMPON" })]
        Tampon,
        [EnumImportValue(new string[] { "TAPE" })]
        Tape,
        [EnumImportValue(new string[] { "TINCTURE" })]
        Tincture,
        [EnumImportValue(new string[] { "TROCHE" })]
        Troche,
        [EnumImportValue(new string[] { "WAFER" })]
        Wafer
    }
}
