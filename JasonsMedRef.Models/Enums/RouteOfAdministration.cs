using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.Enums
{
    public enum RouteOfAdministration
    {
        [EnumImportValue(new string[] { "AURICULAR (OTIC)" })]
        AuricularOtic,
        [EnumImportValue(new string[] { "BUCCAL" })]
        Buccal,
        [EnumImportValue(new string[] { "CONJUNCTIVAL" })]
        Conjunctival,
        [EnumImportValue(new string[] { "CUTANEOUS" })]
        Cutaneous,
        [EnumImportValue(new string[] { "DENTAL" })]
        Gental,
        [EnumImportValue(new string[] { "ELECTRO-OSMOSIS" })]
        ElectorOsmosis,
        [EnumImportValue(new string[] { "ENDOCERVICAL" })]
        Endocervical,
        [EnumImportValue(new string[] { "ENDOSINUSIAL" })]
        Endosinusial,
        [EnumImportValue(new string[] { "ENDOTRACHEAL" })]
        Endotracheal,
        [EnumImportValue(new string[] { "ENTERAL" })]
        Enteral,
        [EnumImportValue(new string[] { "EPIDURAL" })]
        Epidural,
        [EnumImportValue(new string[] { "EXTRA-AMNIOTIC" })]
        ExtraAmniotic,
        [EnumImportValue(new string[] { "EXTRACORPOREAL" })]
        Extracorporeal,
        [EnumImportValue(new string[] { "HEMODIALYSIS" })]
        Hemodialysis,
        [EnumImportValue(new string[] { "INFILTRATION" })]
        Infiltration,
        [EnumImportValue(new string[] { "INTERSTITIAL" })]
        Interstitial,
        [EnumImportValue(new string[] { "INTRA-ABDOMINAL" })]
        IntraAbdominal,
        [EnumImportValue(new string[] { "INTRA-AMNIOTIC" })]
        IntraAmniotic,
        [EnumImportValue(new string[] { "INTRA-ARTERIAL" })]
        IntraArterial,
        [EnumImportValue(new string[] { "INTRA-ARTICULAR" })]
        IntraArticular,
        [EnumImportValue(new string[] { "INTRABILIARY" })]
        Intrabiliary,
        [EnumImportValue(new string[] { "INTRABRONCHIAL" })]
        Intrabronchial,
        [EnumImportValue(new string[] { "INTRABURSAL" })]
        Intrabursal,
        [EnumImportValue(new string[] { "INTRACANALICULAR" })]
        Intracanalicular,
        [EnumImportValue(new string[] { "INTRACARDIAC" })]
        Intracardiac,
        [EnumImportValue(new string[] { "INTRACARTILAGINOUS" })]
        Intracartilaginous,
        [EnumImportValue(new string[] { "INTRACAUDAL" })]
        Intracaudal,
        [EnumImportValue(new string[] { "INTRACAVERNOUS" })]
        Intracavernous,
        [EnumImportValue(new string[] { "INTRACAVITARY" })]
        Intracavity,
        [EnumImportValue(new string[] { "INTRACEREBRAL" })]
        Intracerebral,
        [EnumImportValue(new string[] { "INTRACISTERNAL" })]
        Intracisternal,
        [EnumImportValue(new string[] { "INTRACORNEAL" })]
        Intracorneal,
        [EnumImportValue(new string[] { "INTRACORONAL, DENTAL" })]
        IntracoronalDental,
        [EnumImportValue(new string[] { "INTRACORONARY" })]
        IntraCorony,
        [EnumImportValue(new string[] { "INTRACORPORUS CAVERNOSUM" })]
        IntracorporusCavernosum,
        [EnumImportValue(new string[] { "INTRACRANIAL" })]
        Intracranial,
        [EnumImportValue(new string[] { "INTRADERMAL" })]
        Intradermal,
        [EnumImportValue(new string[] { "INTRADISCAL" })]
        Intradiscal,
        [EnumImportValue(new string[] { "INTRADUCTAL" })]
        Intraductal,
        [EnumImportValue(new string[] { "INTRADUODENAL" })]
        Intraduodenal,
        [EnumImportValue(new string[] { "INTRADURAL" })]
        Intradural,
        [EnumImportValue(new string[] { "INTRAEPICARDIAL" })]
        Intraepicardial,
        [EnumImportValue(new string[] { "INTRAEPIDERMAL" })]
        Intraepidermal,
        [EnumImportValue(new string[] { "INTRAESOPHAGEAL" })]
        Intraesophageal,
        [EnumImportValue(new string[] { "INTRAGASTRIC" })]
        Intragastric,
        [EnumImportValue(new string[] { "INTRAGINGIVAL" })]
        Intravaginal,
        [EnumImportValue(new string[] { "INTRAHEPATIC" })]
        Intrahepatic,
        [EnumImportValue(new string[] { "INTRAILEAL" })]
        Intraileal,
        [EnumImportValue(new string[] { "INTRALESIONAL" })]
        Intralesional,
        [EnumImportValue(new string[] { "INTRALINGUAL" })]
        Intralingual,
        [EnumImportValue(new string[] { "INTRALUMINAL" })]
        Intraluminal,
        [EnumImportValue(new string[] { "INTRALYMPHATIC" })]
        Intralymphatic,
        [EnumImportValue(new string[] { "INTRAMAMMARY" })]
        Intramammary,
        [EnumImportValue(new string[] { "INTRAMEDULLARY" })]
        Intramedullary,
        [EnumImportValue(new string[] { "INTRAMENINGEAL" })]
        Intrameningeal,
        [EnumImportValue(new string[] { "INTRAMUSCULAR" })]
        Intramuscular,
        [EnumImportValue(new string[] { "INTRANODAL" })]
        Intranodal,
        [EnumImportValue(new string[] { "INTRAOCULAR" })]
        Intraocular,
        [EnumImportValue(new string[] { "INTRAOMENTUM" })]
        Intraomentum,
        [EnumImportValue(new string[] { "INTRAOVARIAN" })]
        Intraovarian,
        [EnumImportValue(new string[] { "INTRAPERICARDIAL" })]
        Intrapericardial,
        [EnumImportValue(new string[] { "INTRAPERITONEAL" })]
        Intraperitoneal,
        [EnumImportValue(new string[] { "INTRAPLEURAL" })]
        Intrapleural,
        [EnumImportValue(new string[] { "INTRAPROSTATIC" })]
        Intraprostatic,
        [EnumImportValue(new string[] { "INTRAPULMONARY" })]
        Intrapulmonary,
        [EnumImportValue(new string[] { "INTRARUMINAL" })]
        Intraruminal,
        [EnumImportValue(new string[] { "INTRASINAL" })]
        INtrasinal,
        [EnumImportValue(new string[] { "INTRASPINAL" })]
        Intraspinal,
        [EnumImportValue(new string[] { "INTRASYNOVIAL" })]
        Intrasynovial,
        [EnumImportValue(new string[] { "INTRATENDINOUS" })]
        Intratendinous,
        [EnumImportValue(new string[] { "INTRATESTICULAR" })]
        Intratesticular,
        [EnumImportValue(new string[] { "INTRATHECAL" })]
        Intrathecal,
        [EnumImportValue(new string[] { "INTRATHORACIC" })]
        Intrathoracic,
        [EnumImportValue(new string[] { "INTRATUBULAR" })]
        Intratubular,
        [EnumImportValue(new string[] { "INTRATUMOR" })]
        Intratuor,
        [EnumImportValue(new string[] { "INTRATYMPANIC" })]
        Intratympanic,
        [EnumImportValue(new string[] { "INTRAUTERINE" })]
        Intrauterine,
        [EnumImportValue(new string[] { "INTRAVASCULAR" })]
        Intravascular,
        [EnumImportValue(new string[] { "INTRAVENOUS" })]
        Intravenous,
        [EnumImportValue(new string[] { "INTRAVENTRICULAR" })]
        Intraventricular,
        [EnumImportValue(new string[] { "INTRAVESICAL" })]
        Intravesical,
        [EnumImportValue(new string[] { "INTRAVITREAL" })]
        Intravitreal,
        [EnumImportValue(new string[] { "IONTOPHORESIS" })]
        Iontophoresis,
        [EnumImportValue(new string[] { "IRRIGATION" })]
        Irrigation,
        [EnumImportValue(new string[] { "LARYNGEAL" })]
        Laryngeal,
        [EnumImportValue(new string[] { "NASAL" })]
        Nasal,
        [EnumImportValue(new string[] { "NASOGASTRIC" })]
        Nasogastric,
        [EnumImportValue(new string[] { "NOT APPLICABLE" })]
        NotApplicable,
        [EnumImportValue(new string[] { "OCCLUSIVE DRESSING TECHNIQUE" })]
        OcclusiveDressingTechnique,
        [EnumImportValue(new string[] { "OPHTHALMIC" })]
        Opthalmic,
        [EnumImportValue(new string[] { "ORAL" })]
        Oral,
        [EnumImportValue(new string[] { "OROPHARYNGEAL" })]
        Orpharyngeal,
        [EnumImportValue(new string[] { "PARENTERAL" })]
        Parenteral,
        [EnumImportValue(new string[] { "PERCUTANEOUS" })]
        Percutaneous,
        [EnumImportValue(new string[] { "PERIARTICULAR" })]
        Periarticular,
        [EnumImportValue(new string[] { "PERIDURAL" })]
        Peridural,
        [EnumImportValue(new string[] { "PERINEURAL" })]
        Perineural,
        [EnumImportValue(new string[] { "PERIODONTAL" })]
        Periodontal,
        [EnumImportValue(new string[] { "RECTAL" })]
        Rectal,
        [EnumImportValue(new string[] { "RESPIRATORY (INHALATION)" })]
        RespiratoryInhalation,
        [EnumImportValue(new string[] { "RETROBULBAR" })]
        Retrobulbar,
        [EnumImportValue(new string[] { "SOFT TISSUE" })]
        SoftTissue,
        [EnumImportValue(new string[] { "SUBARACHNOID" })]
        Subarachnoid,
        [EnumImportValue(new string[] { "SUBCONJUNCTIVAL" })]
        Subconjunctival,
        [EnumImportValue(new string[] { "SUBCUTANEOUS" })]
        Subcutaneous,
        [EnumImportValue(new string[] { "SUBGINGIVAL" })]
        Sublgingival,
        [EnumImportValue(new string[] { "SUBLINGUAL" })]
        Sublingual,
        [EnumImportValue(new string[] { "SUBMUCOSAL" })]
        Submucosal,
        [EnumImportValue(new string[] { "SUBRETINAL" })]
        Subretinal,
        [EnumImportValue(new string[] { "TOPICAL" })]
        Topical,
        [EnumImportValue(new string[] { "TRANSDERMAL" })]
        Transdermal,
        [EnumImportValue(new string[] { "TRANSENDOCARDIAL" })]
        Transendocardial,
        [EnumImportValue(new string[] { "TRANSMUCOSAL" })]
        Transmucusal,
        [EnumImportValue(new string[] { "TRANSPLACENTAL" })]
        Transplacental,
        [EnumImportValue(new string[] { "TRANSTRACHEAL" })]
        Transtracheal,
        [EnumImportValue(new string[] { "TRANSTYMPANIC" })]
        Transtympatic,
        [EnumImportValue(new string[] { "URETERAL" })]
        Ureteral,
        [EnumImportValue(new string[] { "URETHRAL" })]
        Urethral,
        [EnumImportValue(new string[] { "VAGINAL" })]
        Vaginal
    }
}
