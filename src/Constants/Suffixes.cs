namespace SsiGroup.ProjectUsNormalizer.Constants;

/// <summary>
///   Street suffixes constants.
/// </summary>
internal static class Suffixes
{
  /// <summary>
  ///   Street suffix abbreviations.
  /// </summary>
  /// <remarks>
  ///   Taken from Project US@ technical specification:
  ///   <a href="https://oncprojectracking.healthit.gov/wiki/pages/viewpage.action?pageId=180486153" />.
  ///   Version 1.0. APPENDIX B. STREET SUFFIX ABBREVIATIONS. Pages 43-56.
  /// </remarks>
  internal static IReadOnlyDictionary<string, string> Abbreviations = new Dictionary<string, string>
  {
    { "ALLEE", "ALY" },
    { "ALLEY", "ALY" },
    { "ALLY", "ALY" },
    { "ALY", "ALY" },
    { "ANEX", "ANX" },
    { "ANNEX", "ANX" },
    { "ANNX", "ANX" },
    { "ANX", "ANX" },
    { "ARCADE", "ARC" },
    { "ARC", "ARC" },
    { "AV", "AVE" },
    { "AVE", "AVE" },
    { "AVEN", "AVE" },
    { "AVENU", "AVE" },
    { "AVENUE", "AVE" },
    { "AVN", "AVE" },
    { "AVNUE", "AVE" },
    { "BAYOO", "BYU" },
    { "BAYOU", "BYU" },
    { "BYU", "BYU" },
    { "BCH", "BCH" },
    { "BEACH", "BCH" },
    { "BEND", "BND" },
    { "BND", "BND" },
    { "BLF", "BLF" },
    { "BLUF", "BLF" },
    { "BLUFF", "BLF" },
    { "BLUFFS", "BLFS" },
    { "BLFS", "BLFS" },
    { "BOT", "BTM" },
    { "BTM", "BTM" },
    { "BOTTM", "BTM" },
    { "BOTTOM", "BTM" },
    { "BLVD", "BLVD" },
    { "BOUL", "BLVD" },
    { "BOULEVARD", "BLVD" },
    { "BOULV", "BLVD" },
    { "BR", "BR" },
    { "BRNCH", "BR" },
    { "BRANCH", "BR" },
    { "BRDGE", "BRG" },
    { "BRG", "BRG" },
    { "BRIDGE", "BRG" },
    { "BRK", "BRK" },
    { "BROOK", "BRK" },
    { "BROOKS", "BRKS" },
    { "BRKS", "BRKS" },
    { "BURG", "BG" },
    { "BG", "BG" },
    { "BURGS", "BGS" },
    { "BGS", "BGS" },
    { "BYP", "BYP" },
    { "BYPA", "BYP" },
    { "BYPAS", "BYP" },
    { "BYPASS", "BYP" },
    { "BYPS", "BYP" },
    { "CAMP", "CP" },
    { "CP", "CP" },
    { "CMP", "CP" },
    { "CANYN", "CYN" },
    { "CANYON", "CYN" },
    { "CNYN", "CYN" },
    { "CYN", "CYN" },
    { "CAPE", "CPE" },
    { "CPE", "CPE" },
    { "CAUSEWAY", "CSWY" },
    { "CAUSWA", "CSWY" },
    { "CSWY", "CSWY" },
    { "CEN", "CTR" },
    { "CENT", "CTR" },
    { "CENTER", "CTR" },
    { "CENTR", "CTR" },
    { "CENTRE", "CTR" },
    { "CNTER", "CTR" },
    { "CNTR", "CTR" },
    { "CTR", "CTR" },
    { "CENTERS", "CTRS" },
    { "CTRS", "CTRS" },
    { "CIR", "CIR" },
    { "CIRC", "CIR" },
    { "CIRCL", "CIR" },
    { "CIRCLE", "CIR" },
    { "CRCL", "CIR" },
    { "CRCLE", "CIR" },
    { "CIRCLES", "CIRS" },
    { "CIRS", "CIRS" },
    { "CLR", "CLR" },
    { "CLIFF", "CLF" },
    { "CLF", "CLF" },
    { "CLFS", "CLFS" },
    { "CLIFFS", "CLFS" },
    { "CLB", "CLB" },
    { "CLUB", "CLB" },
    { "COMMON", "CMN" },
    { "CMN", "CMN" },
    { "COMMONS", "CMNS" },
    { "CMNS", "CMNS" },
    { "COR", "COR" },
    { "CORNER", "COR" },
    { "CORNERS", "CORS" },
    { "CORS", "CORS" },
    { "COURSE", "CRSE" },
    { "CRSE", "CRSE" },
    { "COURT", "CT" },
    { "CT", "CT" },
    { "COURTS", "CTS" },
    { "CTS", "CTS" },
    { "COVE", "CV" },
    { "CV", "CV" },
    { "COVES", "CVS" },
    { "CVS", "CVS" },
    { "CREEK", "CRK" },
    { "CRK", "CRK" },
    { "CRESCENT", "CRES" },
    { "CRES", "CRES" },
    { "CRSNT", "CRES" },
    { "CREST", "CRST" },
    { "CRST", "CRST" },
    { "CROSSING", "XING" },
    { "CRSSING", "XING" },
    { "XING", "XING" },
    { "CROSSROAD", "XRD" },
    { "XRD", "XRD" },
    { "CROSSROADS", "XRDS" },
    { "XRDS", "XRDS" },
    { "CURVE", "CURV" },
    { "CURV", "CURV" },
    { "DALE", "DL" },
    { "DL", "DL" },
    { "DAM", "DM" },
    { "DM", "DM" },
    { "DIV", "DV" },
    { "DIVIDE", "DV" },
    { "DV", "DV" },
    { "DVD", "DV" },
    { "DR", "DR" },
    { "DRIV", "DR" },
    { "DRIVE", "DR" },
    { "DRV", "DR" },
    { "DRIVES", "DRS" },
    { "DRS", "DRS" },
    { "EST", "EST" },
    { "ESTATE", "EST" },
    { "ESTATES", "ESTS" },
    { "ESTS", "ESTS" },
    { "EXP", "EXPY" },
    { "EXPR", "EXPY" },
    { "EXPRESS", "EXPY" },
    { "EXPRESSWAY", "EXPY" },
    { "EXPW", "EXPY" },
    { "EXPY", "EXPY" },
    { "EXT", "EXT" },
    { "EXTENSION", "EXT" },
    { "EXTN", "EXT" },
    { "EXTNSN", "EXT" },
    { "EXTENSIONS", "EXTS" },
    { "EXTS", "EXTS" },
    { "FALL", "FALL" },
    { "FALLS", "FLS" },
    { "FLS", "FLS" },
    { "FERRY", "FRY" },
    { "FRRY", "FRY" },
    { "FRY", "FRY" },
    { "FIELD", "FLD" },
    { "FLD", "FLD" },
    { "FIELDS", "FLDS" },
    { "FLDS", "FLDS" },
    { "FLAT", "FLT" },
    { "FLT", "FLT" },
    { "FLATS", "FLTS" },
    { "FLTS", "FLTS" },
    { "FORD", "FRD" },
    { "FRD", "FRD" },
    { "FORDS", "FRDS" },
    { "FRDS", "FRDS" },
    { "FOREST", "FRST" },
    { "FORESTS", "FRST" },
    { "FRST", "FRST" },
    { "FORG", "FRG" },
    { "FORGE", "FRG" },
    { "FRG", "FRG" },
    { "FORGES", "FRGS" },
    { "FRGS", "FRGS" },
    { "FORK", "FRK" },
    { "FRK", "FRK" },
    { "FORKS", "FRKS" },
    { "FRKS", "FRKS" },
    { "FORT", "FT" },
    { "FRT", "FT" },
    { "FT", "FT" },
    { "FREEWAY", "FWY" },
    { "FREEWY", "FWY" },
    { "FRWAY", "FWY" },
    { "FRWY", "FWY" },
    { "FWY", "FWY" },
    { "GARDEN", "GDN" },
    { "GARDN", "GDN" },
    { "GRDEN", "GDN" },
    { "GRDN", "GDN" },
    { "GDN", "GDN" },
    { "GARDENS", "GDNS" },
    { "GDNS", "GDNS" },
    { "GRDNS", "GDNS" },
    { "GATEWAY", "GTWY" },
    { "GATEWY", "GTWY" },
    { "GATWAY", "GTWY" },
    { "GTWAY", "GTWY" },
    { "GTWY", "GTWY" },
    { "GLEN", "GLN" },
    { "GLN", "GLN" },
    { "GLENS", "GLNS" },
    { "GLNS", "GLNS" },
    { "GREEN", "GRN" },
    { "GRN", "GRN" },
    { "GREENS", "GRNS" },
    { "GRNS", "GRNS" },
    { "GROV", "GRV" },
    { "GROVE", "GRV" },
    { "GRV", "GRV" },
    { "GROVES", "GRVS" },
    { "GRVS", "GRVS" },
    { "HARB", "HBR" },
    { "HARBOR", "HBR" },
    { "HARBR", "HBR" },
    { "HBR", "HBR" },
    { "HRBOR", "HBR" },
    { "HARBORS", "HBRS" },
    { "HBRS", "HBRS" },
    { "HAVEN", "HVN" },
    { "HVN", "HVN" },
    { "HEIGHTS", "HTS" },
    { "HT", "HTS" },
    { "HTS", "HTS" },
    { "HIGHWAY", "HWY" },
    { "HIGHWY", "HWY" },
    { "HIWAY", "HWY" },
    { "HIWY", "HWY" },
    { "HWAY", "HWY" },
    { "HWY", "HWY" },
    { "HILL", "HL" },
    { "HL", "HL" },
    { "HILLS", "HLS" },
    { "HLS", "HLS" },
    { "HLLW", "HOLW" },
    { "HOLLOW", "HOLW" },
    { "HOLLOWS", "HOLW" },
    { "HOLW", "HOLW" },
    { "HOLWS", "HOLW" },
    { "INLET", "INLT" },
    { "INLT", "INLT" },
    { "IS", "IS" },
    { "ISLAND", "IS" },
    { "ISLND", "IS" },
    { "ISLANDS", "ISS" },
    { "ISLNDS", "ISS" },
    { "ISS", "ISS" },
    { "ISLE", "ISLE" },
    { "ISLES", "ISLE" },
    { "JCT", "JCT" },
    { "JCTION", "JCT" },
    { "JCTN", "JCT" },
    { "JUNCTION", "JCT" },
    { "JUNCTN", "JCT" },
    { "JUNCTON", "JCT" },
    { "JCTNS", "JCTS" },
    { "JCTS", "JCTS" },
    { "JUNCTIONS", "JCTS" },
    { "KEY", "KY" },
    { "KY", "KY" },
    { "KEYS", "KYS" },
    { "KYS", "KYS" },
    { "KNL", "KNL" },
    { "KNOL", "KNL" },
    { "KNOLL", "KNL" },
    { "KNLS", "KNLS" },
    { "KNOLLS", "KNLS" },
    { "LK", "LK" },
    { "LAKE", "LK" },
    { "LKS", "LKS" },
    { "LAKES", "LKS" },
    { "LAND", "LAND" },
    { "LANDING", "LNDG" },
    { "LNDG", "LNDG" },
    { "LNDNG", "LNDG" },
    { "LANE", "LN" },
    { "LN", "LN" },
    { "LGT", "LGT" },
    { "LIGHT", "LGT" },
    { "LIGHTS", "LGTS" },
    { "LGTS", "LGTS" },
    { "LF", "LF" },
    { "LOAF", "LF" },
    { "LCK", "LCK" },
    { "LOCK", "LCK" },
    { "LCKS", "LCKS" },
    { "LOCKS", "LCKS" },
    { "LDG", "LDG" },
    { "LDGE", "LDG" },
    { "LODG", "LDG" },
    { "LODGE", "LDG" },
    { "LOOP", "LOOP" },
    { "LOOPS", "LOOP" },
    { "MALL", "MALL" },
    { "MNR", "MNR" },
    { "MANOR", "MNR" },
    { "MANORS", "MNRS" },
    { "MNRS", "MNRS" },
    { "MEADOW", "MDW" },
    { "MDW", "MDW" },
    { "MDWS", "MDWS" },
    { "MEADOWS", "MDWS" },
    { "MEDOWS", "MDWS" },
    { "MEWS", "MEWS" },
    { "MILL", "ML" },
    { "ML", "ML" },
    { "MILLS", "MLS" },
    { "MLS", "MLS" },
    { "MISSN", "MSN" },
    { "MSSN", "MSN" },
    { "MSN", "MSN" },
    { "MOTORWAY", "MTWY" },
    { "MTWY", "MTWY" },
    { "MNT", "MT" },
    { "MT", "MT" },
    { "MOUNT", "MT" },
    { "MNTAIN", "MTN" },
    { "MNTN", "MTN" },
    { "MOUNTAIN", "MTN" },
    { "MOUNTIN", "MTN" },
    { "MTIN", "MTN" },
    { "MTN", "MTN" },
    { "MNTNS", "MTNS" },
    { "MTNS", "MTNS" },
    { "MOUNTAINS", "MTNS" },
    { "NCK", "NCK" },
    { "NECK", "NCK" },
    { "ORCH", "ORCH" },
    { "ORCHARD", "ORCH" },
    { "ORCHRD", "ORCH" },
    { "OVAL", "OVAL" },
    { "OVL", "OVAL" },
    { "OVERPASS", "OPAS" },
    { "OPAS", "OPAS" },
    { "PARK", "PARK" },
    { "PRK", "PARK" },
    { "PARKS", "PARK" },
    { "PARKWAY", "PKWY" },
    { "PARKWY", "PKWY" },
    { "PKWAY", "PKWY" },
    { "PKWY", "PKWY" },
    { "PKY", "PKWY" },
    { "PARKWAYS", "PKWY" },
    { "PKWYS", "PKWY" },
    { "PASS", "PASS" },
    { "PASSAGE", "PSGE" },
    { "PSGE", "PSGE" },
    { "PATH", "PATH" },
    { "PATHS", "PATH" },
    { "PIKE", "PIKE" },
    { "PIKES", "PIKE" },
    { "PINE", "PNE" },
    { "PNE", "PNE" },
    { "PINES", "PNES" },
    { "PNES", "PNES" },
    { "PLACE", "PL" },
    { "PL", "PL" },
    { "PLAIN", "PLN" },
    { "PLN", "PLN" },
    { "PLAINS", "PLNS" },
    { "PLNS", "PLNS" },
    { "PLAZA", "PLZ" },
    { "PLZ", "PLZ" },
    { "PLZA", "PLZ" },
    { "POINT", "PT" },
    { "PT", "PT" },
    { "POINTS", "PTS" },
    { "PTS", "PTS" },
    { "PORT", "PRT" },
    { "PRT", "PRT" },
    { "PORTS", "PRTS" },
    { "PRTS", "PRTS" },
    { "PR", "PR" },
    { "PRAIRIE", "PR" },
    { "PRR", "PR" },
    { "RAD", "RADL" },
    { "RADIAL", "RADL" },
    { "RADIEL", "RADL" },
    { "RADL", "RADL" },
    { "RAMP", "RAMP" },
    { "RANCH", "RNCH" },
    { "RANCHES", "RNCH" },
    { "RNCH", "RNCH" },
    { "RNCHS", "RNCH" },
    { "RAPID", "RPD" },
    { "RPD", "RPD" },
    { "RAPIDS", "RPDS" },
    { "RPDS", "RPDS" },
    { "REST", "RST" },
    { "RST", "RST" },
    { "RDG", "RDG" },
    { "RDGE", "RDG" },
    { "RIDGE", "RDG" },
    { "RDGS", "RDGS" },
    { "RIDGES", "RDGS" },
    { "RIV", "RIV" },
    { "RIVER", "RIV" },
    { "RVR", "RIV" },
    { "RIVR", "RIV" },
    { "RD", "RD" },
    { "ROAD", "RD" },
    { "ROADS", "RDS" },
    { "RDS", "RDS" },
    { "ROUTE", "RTE" },
    { "RTE", "RTE" },
    { "ROW", "ROW" },
    { "RUE", "RUE" },
    { "RUN", "RUN" },
    { "SHL", "SHL" },
    { "SHOAL", "SHL" },
    { "SHLS", "SHLS" },
    { "SHOALS", "SHLS" },
    { "SHOAR", "SHR" },
    { "SHORE", "SHR" },
    { "SHR", "SHR" },
    { "SHOARS", "SHRS" },
    { "SHORES", "SHRS" },
    { "SHRS", "SHRS" },
    { "SKYWAY", "SKWY" },
    { "SKWY", "SKWY" },
    { "SPG", "SPG" },
    { "SPNG", "SPG" },
    { "SPRING", "SPG" },
    { "SPRNG", "SPG" },
    { "SPGS", "SPGS" },
    { "SPNGS", "SPGS" },
    { "SPRINGS", "SPGS" },
    { "SPRNGS", "SPGS" },
    { "SPUR", "SPUR" },
    { "SPURS", "SPUR" },
    { "SQ", "SQ" },
    { "SQR", "SQ" },
    { "SQRE", "SQ" },
    { "SQU", "SQ" },
    { "SQUARE", "SQ" },
    { "SQRS", "SQS" },
    { "SQS", "SQS" },
    { "SQUARES", "SQS" },
    { "STA", "STA" },
    { "STATION", "STA" },
    { "STATN", "STA" },
    { "STN", "STA" },
    { "STRA", "STRA" },
    { "STRAV", "STRA" },
    { "STRAVEN", "STRA" },
    { "STRAVENUE", "STRA" },
    { "STRAVN", "STRA" },
    { "STRVN", "STRA" },
    { "STRVNUE", "STRA" },
    { "STREAM", "STRM" },
    { "STREME", "STRM" },
    { "STRM", "STRM" },
    { "STREET", "ST" },
    { "STRT", "ST" },
    { "ST", "ST" },
    { "STR", "ST" },
    { "STREETS", "STS" },
    { "STS", "STS" },
    { "SMT", "SMT" },
    { "SUMIT", "SMT" },
    { "SUMITT", "SMT" },
    { "SUMMIT", "SMT" },
    { "TER", "TER" },
    { "TERR", "TER" },
    { "TERRACE", "TER" },
    { "THROUGHWAY", "TRWY" },
    { "TRWY", "TRWY" },
    { "TRACE", "TRCE" },
    { "TRACES", "TRCE" },
    { "TRCE", "TRCE" },
    { "TRACK", "TRAK" },
    { "TRACKS", "TRAK" },
    { "TRAK", "TRAK" },
    { "TRK", "TRAK" },
    { "TRKS", "TRAK" },
    { "TRAFFICWAY", "TRFY" },
    { "TRFY", "TRFY" },
    { "TRAIL", "TRL" },
    { "TRAILS", "TRL" },
    { "TRL", "TRL" },
    { "TRLS", "TRL" },
    { "TRAILER", "TRLR" },
    { "TRLR", "TRLR" },
    { "TRLRS", "TRLR" },
    { "TUNEL", "TUNL" },
    { "TUNL", "TUNL" },
    { "TUNLS", "TUNL" },
    { "TUNNEL", "TUNL" },
    { "TUNNELS", "TUNL" },
    { "TUNNL", "TUNL" },
    { "TPKE", "TPKE" },
    { "TRNPK", "TPKE" },
    { "TURNPIKE", "TPKE" },
    { "TURNPK", "TPKE" },
    { "UNDERPASS", "UPAS" },
    { "UPAS", "UPAS" },
    { "UN", "UN" },
    { "UNION", "UN" },
    { "UNIONS", "UNS" },
    { "UNS", "UNS" },
    { "VALLEY", "VLY" },
    { "VALLY", "VLY" },
    { "VLLY", "VLY" },
    { "VLY", "VLY" },
    { "VALLEYS", "VLYS" },
    { "VLYS", "VLYS" },
    { "VDCT", "VIA" },
    { "VIA", "VIA" },
    { "VIADCT", "VIA" },
    { "VIADUCT", "VIA" },
    { "VIEW", "VW" },
    { "VW", "VW" },
    { "VIEWS", "VWS" },
    { "VWS", "VWS" },
    { "VILL", "VLG" },
    { "VILLAG", "VLG" },
    { "VILLAGE", "VLG" },
    { "VILLG", "VLG" },
    { "VILLIAGE", "VLG" },
    { "VLG", "VLG" },
    { "VILLAGES", "VLGS" },
    { "VLGS", "VLGS" },
    { "VILLE", "VL" },
    { "VL", "VL" },
    { "VIS", "VIS" },
    { "VIST", "VIS" },
    { "VISTA", "VIS" },
    { "VST", "VIS" },
    { "VSTA", "VIS" },
    { "WALK", "WALK" },
    { "WALKS", "WALK" },
    { "WALL", "WALL" },
    { "WY", "WAY" },
    { "WAY", "WAY" },
    { "WAYS", "WAYS" },
    { "WELL", "WL" },
    { "WL", "WL" },
    { "WELLS", "WLS" },
    { "WLS", "WLS" }
  };

  /// <summary>
  ///   Street suffixes fully spelled out.
  /// </summary>
  /// <remarks>
  ///   Taken from Project US@ technical specification:
  ///   <a href="https://oncprojectracking.healthit.gov/wiki/pages/viewpage.action?pageId=180486153" />.
  ///   Version 1.0. APPENDIX B. STREET SUFFIX ABBREVIATIONS. Pages 43-56.
  /// </remarks>
  internal static IReadOnlyDictionary<string, string> FullySpelledOut = new Dictionary<string, string>
  {
    { "ALLEE", "ALLEY" },
    { "ALLEY", "ALLEY" },
    { "ALLY", "ALLEY" },
    { "ALY", "ALLEY" },
    { "ANEX", "ANEX" },
    { "ANNEX", "ANEX" },
    { "ANNX", "ANEX" },
    { "ANX", "ANEX" },
    { "ARCADE", "ARCADE" },
    { "ARC", "ARCADE" },
    { "AV", "AVENUE" },
    { "AVE", "AVENUE" },
    { "AVEN", "AVENUE" },
    { "AVENU", "AVENUE" },
    { "AVENUE", "AVENUE" },
    { "AVN", "AVENUE" },
    { "AVNUE", "AVENUE" },
    { "BAYOO", "BAYOU" },
    { "BAYOU", "BAYOU" },
    { "BYU", "BAYOU" },
    { "BCH", "BEACH" },
    { "BEACH", "BEACH" },
    { "BEND", "BEND" },
    { "BND", "BEND" },
    { "BLF", "BLUFF" },
    { "BLUF", "BLUFF" },
    { "BLUFF", "BLUFF" },
    { "BLFS", "BLUFFS" },
    { "BLUFFS", "BLUFFS" },
    { "BOT", "BOTTOM" },
    { "BTM", "BOTTOM" },
    { "BOTTM", "BOTTOM" },
    { "BOTTOM", "BOTTOM" },
    { "BLVD", "BOULEVARD" },
    { "BOUL", "BOULEVARD" },
    { "BOULEVARD", "BOULEVARD" },
    { "BOULV", "BOULEVARD" },
    { "BR", "BRANCH" },
    { "BRNCH", "BRANCH" },
    { "BRANCH", "BRANCH" },
    { "BRDGE", "BRIDGE" },
    { "BRG", "BRIDGE" },
    { "BRIDGE", "BRIDGE" },
    { "BRK", "BROOK" },
    { "BROOK", "BROOK" },
    { "BROOKS", "BROOKS" },
    { "BG", "BURG" },
    { "BURG", "BURG" },
    { "BGS", "BURGS" },
    { "BURGS", "BURGS" },
    { "BYP", "BYPASS" },
    { "BYPA", "BYPASS" },
    { "BYPAS", "BYPASS" },
    { "BYPASS", "BYPASS" },
    { "BYPS", "BYPASS" },
    { "CAMP", "CAMP" },
    { "CP", "CAMP" },
    { "CMP", "CAMP" },
    { "CANYN", "CANYON" },
    { "CANYON", "CANYON" },
    { "CNYN", "CANYON" },
    { "CYN", "CANYON" },
    { "CAPE", "CAPE" },
    { "CPE", "CAPE" },
    { "CAUSEWAY", "CAUSEWAY" },
    { "CAUSWA", "CAUSEWAY" },
    { "CSWY", "CAUSEWAY" },
    { "CEN", "CENTER" },
    { "CENT", "CENTER" },
    { "CENTER", "CENTER" },
    { "CENTR", "CENTER" },
    { "CENTRE", "CENTER" },
    { "CNTER", "CENTER" },
    { "CNTR", "CENTER" },
    { "CTR", "CENTER" },
    { "CENTERS", "CENTERS" },
    { "CTRS", "CENTERS" },
    { "CIR", "CIRCLE" },
    { "CIRC", "CIRCLE" },
    { "CIRCL", "CIRCLE" },
    { "CIRCLE", "CIRCLE" },
    { "CRCL", "CIRCLE" },
    { "CRCLE", "CIRCLE" },
    { "CIRS", "CIRCLES" },
    { "CIRCLES", "CIRCLES" },
    { "CLF", "CLIFF" },
    { "CLIFF", "CLIFF" },
    { "CLFS", "CLIFFS" },
    { "CLIFFS", "CLIFFS" },
    { "CLB", "CLUB" },
    { "CLUB", "CLUB" },
    { "CMN", "COMMON" },
    { "COMMON", "COMMON" },
    { "CMNS", "COMMONS" },
    { "COMMONS", "COMMONS" },
    { "COR", "CORNER" },
    { "CORNER", "CORNER" },
    { "CORNERS", "CORNERS" },
    { "CORS", "CORNERS" },
    { "COURSE", "COURSE" },
    { "CRSE", "COURSE" },
    { "COURT", "COURT" },
    { "CT", "COURT" },
    { "COURTS", "COURTS" },
    { "CTS", "COURTS" },
    { "COVE", "COVE" },
    { "CV", "COVE" },
    { "CVS", "CVS" },
    { "COVES", "COVES" },
    { "CREEK", "CREEK" },
    { "CRK", "CREEK" },
    { "CRESCENT", "CRESCENT" },
    { "CRES", "CRESCENT" },
    { "CRSNT", "CRESCENT" },
    { "CRSENT", "CRESCENT" },
    { "CRST", "CREST" },
    { "CREST", "CREST" },
    { "CROSSING", "CROSSING" },
    { "CRSSNG", "CROSSING" },
    { "XING", "CROSSING" },
    { "CROSSROAD", "CROSSROAD" },
    { "XRD", "CROSSROAD" },
    { "CROSSROADS", "CROSSROADS" },
    { "XRDS", "CROSSROADS" },
    { "CURVE", "CURVE" },
    { "CURV", "CURVE" },
    { "DALE", "DALE" },
    { "DL", "DALE" },
    { "DAM", "DAM" },
    { "DM", "DAM" },
    { "DIV", "DIVIDE" },
    { "DIVIDE", "DIVIDE" },
    { "DV", "DIVIDE" },
    { "DVD", "DIVIDE" },
    { "DR", "DRIVE" },
    { "DRIV", "DRIVE" },
    { "DRIVE", "DRIVE" },
    { "DRV", "DRIVE" },
    { "DRIVES", "DRIVES" },
    { "DRS", "DRIVES" },
    { "EST", "ESTATE" },
    { "ESTATE", "ESTATE" },
    { "ESTATES", "ESTATES" },
    { "ESTS", "ESTATES" },
    { "EXP", "EXPRESSWAY" },
    { "EXPR", "EXPRESSWAY" },
    { "EXPRESS", "EXPRESSWAY" },
    { "EXPRESSWAY", "EXPRESSWAY" },
    { "EXPW", "EXPRESSWAY" },
    { "EXPY", "EXPRESSWAY" },
    { "EXT", "EXTENSION" },
    { "EXTENSION", "EXTENSION" },
    { "EXTN", "EXTENSION" },
    { "EXTNSN", "EXTENSION" },
    { "EXTS", "EXTENSIONS" },
    { "EXTENSIONS", "EXTENSIONS" },
    { "FALL", "FALL" },
    { "FALLS", "FALLS" },
    { "FLS", "FALLS" },
    { "FERRY", "FERRY" },
    { "FRRY", "FERRY" },
    { "FRY", "FERRY" },
    { "FIELD", "FIELD" },
    { "FLD", "FIELD" },
    { "FIELDS", "FIELDS" },
    { "FLDS", "FIELDS" },
    { "FLAT", "FLAT" },
    { "FLT", "FLAT" },
    { "FLATS", "FLATS" },
    { "FLTS", "FLATS" },
    { "FORD", "FORD" },
    { "FRD", "FORD" },
    { "FORDS", "FORDS" },
    { "FRDS", "FORDS" },
    { "FOREST", "FOREST" },
    { "FORESTS", "FOREST" },
    { "FRST", "FOREST" },
    { "FORG", "FORGE" },
    { "FORGE", "FORGE" },
    { "FRG", "FORGE" },
    { "FORGES", "FORGES" },
    { "FRGS", "FORGES" },
    { "FORK", "FORK" },
    { "FRK", "FORK" },
    { "FORKS", "FORKS" },
    { "FRKS", "FORKS" },
    { "FORT", "FORT" },
    { "FRT", "FORT" },
    { "FT", "FORT" },
    { "FREEWAY", "FREEWAY" },
    { "FREEWY", "FREEWAY" },
    { "FRWAY", "FREEWAY" },
    { "FRWY", "FREEWAY" },
    { "FWY", "FREEWAY" },
    { "GARDEN", "GARDEN" },
    { "GARDN", "GARDEN" },
    { "GRDEN", "GARDEN" },
    { "GRDN", "GARDEN" },
    { "GDN", "GARDEN" },
    { "GARDENS", "GARDENS" },
    { "GDNS", "GARDENS" },
    { "GRDNS", "GARDENS" },
    { "GATEWAY", "GATEWAY" },
    { "GATEWY", "GATEWAY" },
    { "GATWAY", "GATEWAY" },
    { "GTWAY", "GATEWAY" },
    { "GTWY", "GATEWAY" },
    { "GLEN", "GLEN" },
    { "GLN", "GLEN" },
    { "GLENS", "GLENS" },
    { "GLNS", "GLENS" },
    { "GREEN", "GREEN" },
    { "GRN", "GREEN" },
    { "GREENS", "GREENS" },
    { "GRNS", "GREENS" },
    { "GROV", "GROVE" },
    { "GROVE", "GROVE" },
    { "GRV", "GROVE" },
    { "GROVES", "GROVES" },
    { "GRVS", "GROVES" },
    { "HARB", "HARBOR" },
    { "HARBOR", "HARBOR" },
    { "HARBR", "HARBOR" },
    { "HBR", "HARBOR" },
    { "HRBOR", "HARBOR" },
    { "HARBORS", "HARBORS" },
    { "HBRS", "HARBORS" },
    { "HAVEN", "HAVEN" },
    { "HVN", "HAVEN" },
    { "HEIGHTS", "HEIGHTS" },
    { "HTS", "HEIGHTS" },
    { "HT", "HEIGHTS" },
    { "HIGHWAY", "HIGHWAY" },
    { "HIGHWY", "HIGHWAY" },
    { "HIWAY", "HIGHWAY" },
    { "HIWY", "HIGHWAY" },
    { "HWAY", "HIGHWAY" },
    { "HWY", "HIGHWAY" },
    { "HILL", "HILL" },
    { "HL", "HILL" },
    { "HILLS", "HILLS" },
    { "HLS", "HILLS" },
    { "HLLW", "HOLLOW" },
    { "HOLLOW", "HOLLOW" },
    { "HOLLOWS", "HOLLOW" },
    { "HOLW", "HOLLOW" },
    { "HOLWS", "HOLLOW" },
    { "INLET", "INLET" },
    { "INLT", "INLET" },
    { "IS", "ISLAND" },
    { "ISLAND", "ISLAND" },
    { "ISLND", "ISLAND" },
    { "ISLANDS", "ISLANDS" },
    { "ISLNDS", "ISLANDS" },
    { "ISS", "ISLANDS" },
    { "ISLE", "ISLE" },
    { "ISLES", "ISLE" },
    { "JCT", "JUNCTION" },
    { "JCTION", "JUNCTION" },
    { "JCTN", "JUNCTION" },
    { "JUNCTION", "JUNCTION" },
    { "JUNCTN", "JUNCTION" },
    { "JUNCTON", "JUNCTION" },
    { "JCTNS", "JUNCTIONS" },
    { "JCTS", "JUNCTIONS" },
    { "JUNCTIONS", "JUNCTIONS" },
    { "KEY", "KEY" },
    { "KY", "KEY" },
    { "KEYS", "KEYS" },
    { "KYS", "KEYS" },
    { "KNL", "KNOLL" },
    { "KNOL", "KNOLL" },
    { "KNOLL", "KNOLL" },
    { "KNLS", "KNOLLS" },
    { "KNOLLS", "KNOLLS" },
    { "LK", "LAKE" },
    { "LAKE", "LAKE" },
    { "LKS", "LAKES" },
    { "LAKES", "LAKES" },
    { "LAND", "LAND" },
    { "LANDING", "LANDING" },
    { "LNDG", "LANDING" },
    { "LNDNG", "LANDING" },
    { "LANE", "LANE" },
    { "LN", "LANE" },
    { "LGT", "LIGHT" },
    { "LIGHT", "LIGHT" },
    { "LIGHTS", "LIGHTS" },
    { "LGTS", "LIGHTS" },
    { "LF", "LOAF" },
    { "LOAF", "LOAF" },
    { "LCK", "LOCK" },
    { "LOCK", "LOCK" },
    { "LCKS", "LOCKS" },
    { "LOCKS", "LOCKS" },
    { "LDG", "LODGE" },
    { "LDGE", "LODGE" },
    { "LODG", "LODGE" },
    { "LODGE", "LODGE" },
    { "LOOP", "LOOP" },
    { "LOOPS", "LOOP" },
    { "MALL", "MALL" },
    { "MNR", "MANOR" },
    { "MANOR", "MANOR" },
    { "MANORS", "MANORS" },
    { "MNRS", "MANORS" },
    { "MEADOW", "MEADOW" },
    { "MDW", "MEADOW" },
    { "MDWS", "MEADOWS" },
    { "MEADOWS", "MEADOWS" },
    { "MEDOWS", "MEADOWS" },
    { "MEWS", "MEWS" },
    { "MILL", "MILL" },
    { "ML", "MILL" },
    { "MILLS", "MILLS" },
    { "MLS", "MILLS" },
    { "MISSION", "MISSION" },
    { "MISSN", "MISSION" },
    { "MSSN", "MISSION" },
    { "MOTORWAY", "MOTORWAY" },
    { "MTWY", "MOTORWAY" },
    { "MNT", "MOUNT" },
    { "MT", "MOUNT" },
    { "MOUNT", "MOUNT" },
    { "MNTAIN", "MOUNTAIN" },
    { "MNTN", "MOUNTAIN" },
    { "MOUNTAIN", "MOUNTAIN" },
    { "MOUNTIN", "MOUNTAIN" },
    { "MTIN", "MOUNTAIN" },
    { "MTN", "MOUNTAIN" },
    { "MNTNS", "MOUNTAINS" },
    { "MTNS", "MOUNTAINS" },
    { "MOUNTAINS", "MOUNTAINS" },
    { "NCK", "NECK" },
    { "NECK", "NECK" },
    { "ORCH", "ORCHARD" },
    { "ORCHARD", "ORCHARD" },
    { "ORCHRD", "ORCHARD" },
    { "OVAL", "OVAL" },
    { "OVL", "OVAL" },
    { "OVERPASS", "OVERPASS" },
    { "OPAS", "OVERPASS" },
    { "PARK", "PARK" },
    { "PRK", "PARK" },
    { "PARKS", "PARK" },
    { "PARKWAY", "PARKWAY" },
    { "PARKWY", "PARKWAY" },
    { "PKWAY", "PARKWAY" },
    { "PKWY", "PARKWAY" },
    { "PKY", "PARKWAY" },
    { "PARKWAYS", "PARKWAYS" },
    { "PKWYS", "PARKWAYS" },
    { "PASS", "PASS" },
    { "PASSAGE", "PASSAGE" },
    { "PSGE", "PASSAGE" },
    { "PATH", "PATH" },
    { "PATHS", "PATH" },
    { "PIKE", "PIKE" },
    { "PIKES", "PIKE" },
    { "PINE", "PINE" },
    { "PNE", "PINE" },
    { "PINES", "PINES" },
    { "PNES", "PINES" },
    { "PLACE", "PLACE" },
    { "PL", "PLACE" },
    { "PLAIN", "PLAIN" },
    { "PLN", "PLAIN" },
    { "PLAINS", "PLAINS" },
    { "PLNS", "PLAINS" },
    { "PLAZA", "PLAZA" },
    { "PLZ", "PLAZA" },
    { "PLZA", "PLAZA" },
    { "POINT", "POINT" },
    { "PT", "POINT" },
    { "POINTS", "POINTS" },
    { "PTS", "POINTS" },
    { "PORT", "PORT" },
    { "PRT", "PORT" },
    { "PORTS", "PORTS" },
    { "PRTS", "PORTS" },
    { "PR", "PRAIRIE" },
    { "PRAIRIE", "PRAIRIE" },
    { "PRR", "PRAIRIE" },
    { "RAD", "RADIAL" },
    { "RADIAL", "RADIAL" },
    { "RADIEL", "RADIAL" },
    { "RADL", "RADIAL" },
    { "RAMP", "RAMP" },
    { "RANCH", "RANCH" },
    { "RANCHES", "RANCH" },
    { "RNCH", "RANCH" },
    { "RNCHS", "RANCH" },
    { "RAPID", "RAPID" },
    { "RPD", "RAPID" },
    { "RAPIDS", "RAPIDS" },
    { "RPDS", "RAPIDS" },
    { "REST", "REST" },
    { "RST", "REST" },
    { "RDG", "RIDGE" },
    { "RDGE", "RIDGE" },
    { "RIDGE", "RIDGE" },
    { "RDGS", "RIDGES" },
    { "RIDGES", "RIDGES" },
    { "RIV", "RIVER" },
    { "RIVER", "RIVER" },
    { "RVR", "RIVER" },
    { "RIVR", "RIVER" },
    { "RD", "ROAD" },
    { "ROAD", "ROAD" },
    { "ROADS", "ROADS" },
    { "RDS", "ROADS" },
    { "ROUTE", "ROUTE" },
    { "RTE", "ROUTE" },
    { "ROW", "ROW" },
    { "RUE", "RUE" },
    { "RUN", "RUN" },
    { "SHL", "SHOAL" },
    { "SHOAL", "SHOAL" },
    { "SHLS", "SHOALS" },
    { "SHOALS", "SHOALS" },
    { "SHOAR", "SHORE" },
    { "SHORE", "SHORE" },
    { "SHR", "SHORE" },
    { "SHOARS", "SHORES" },
    { "SHORES", "SHORES" },
    { "SHRS", "SHORES" },
    { "SKYWAY", "SKYWAY" },
    { "SKWY", "SKYWAY" },
    { "SPG", "SPRING" },
    { "SPNG", "SPRING" },
    { "SPRING", "SPRING" },
    { "SPRNG", "SPRING" },
    { "SPGS", "SPRINGS" },
    { "SPNGS", "SPRINGS" },
    { "SPRINGS", "SPRINGS" },
    { "SPRNGS", "SPRINGS" },
    { "SPUR", "SPUR" },
    { "SPURS", "SPUR" },
    { "SQ", "SQUARE" },
    { "SQR", "SQUARE" },
    { "SQRE", "SQUARE" },
    { "SQU", "SQUARE" },
    { "SQUARE", "SQUARE" },
    { "SQRS", "SQUARES" },
    { "SQUARES", "SQUARES" },
    { "STA", "STATION" },
    { "STATION", "STATION" },
    { "STATN", "STATION" },
    { "STN", "STATION" },
    { "STRA", "STRAVENUE" },
    { "STRAV", "STRAVENUE" },
    { "STRAVEN", "STRAVENUE" },
    { "STRAVENUE", "STRAVENUE" },
    { "STRAVN", "STRAVENUE" },
    { "STRVN", "STRAVENUE" },
    { "STRVNUE", "STRAVENUE" },
    { "STREAM", "STREAM" },
    { "STREME", "STREAM" },
    { "STRM", "STREAM" },
    { "STREET", "STREET" },
    { "STRT", "STREET" },
    { "ST", "STREET" },
    { "STR", "STREET" },
    { "STREETS", "STREETS" },
    { "STS", "STREETS" },
    { "SMT", "SUMMIT" },
    { "SUMIT", "SUMMIT" },
    { "SUMITT", "SUMMIT" },
    { "SUMMIT", "SUMMIT" },
    { "TER", "TERRACE" },
    { "TERR", "TERRACE" },
    { "TERRACE", "TERRACE" },
    { "THROUGHWAY", "THROUGHWAY" },
    { "TRWY", "THROUGHWAY" },
    { "TRACE", "TRACE" },
    { "TRACES", "TRACE" },
    { "TRCE", "TRACE" },
    { "TRACK", "TRACK" },
    { "TRACKS", "TRACK" },
    { "TRAK", "TRACK" },
    { "TRK", "TRACK" },
    { "TRKS", "TRACK" },
    { "TRAFFICWAY", "TRAFFICWAY" },
    { "TRFY", "TRAFFICWAY" },
    { "TRAIL", "TRAIL" },
    { "TRAILS", "TRAIL" },
    { "TRL", "TRAIL" },
    { "TRLS", "TRAIL" },
    { "TRAILER", "TRAILER" },
    { "TRLR", "TRAILER" },
    { "TRLRS", "TRAILER" },
    { "TUNEL", "TUNNEL" },
    { "TUNL", "TUNNEL" },
    { "TUNLS", "TUNNEL" },
    { "TUNNEL", "TUNNEL" },
    { "TUNNELS", "TUNNEL" },
    { "TUNNL", "TUNNEL" },
    { "TPKE", "TURNPIKE" },
    { "TRNPK", "TURNPIKE" },
    { "TURNPIKE", "TURNPIKE" },
    { "TURNPK", "TURNPIKE" },
    { "UNDERPASS", "UNDERPASS" },
    { "UPAS", "UNDERPASS" },
    { "UN", "UNION" },
    { "UNION", "UNION" },
    { "UNIONS", "UNIONS" },
    { "UNS", "UNIONS" },
    { "VALLEY", "VALLEY" },
    { "VALLY", "VALLEY" },
    { "VLLY", "VALLEY" },
    { "VLY", "VALLEY" },
    { "VALLEYS", "VALLEYS" },
    { "VLYS", "VALLEYS" },
    { "VDCT", "VIADUCT" },
    { "VIA", "VIADUCT" },
    { "VIADCT", "VIADUCT" },
    { "VIADUCT", "VIADUCT" },
    { "VIEW", "VIEW" },
    { "VW", "VIEW" },
    { "VIEWS", "VIEWS" },
    { "VWS", "VIEWS" },
    { "VILL", "VILLAGE" },
    { "VILLAG", "VILLAGE" },
    { "VILLAGE", "VILLAGE" },
    { "VILLG", "VILLAGE" },
    { "VILLIAGE", "VILLAGE" },
    { "VLG", "VILLAGE" },
    { "VILLAGES", "VILLAGES" },
    { "VLGS", "VILLAGES" },
    { "VILLE", "VILLE" },
    { "VL", "VILLE" },
    { "VIS", "VISTA" },
    { "VIST", "VISTA" },
    { "VISTA", "VISTA" },
    { "VST", "VISTA" },
    { "VSTA", "VISTA" },
    { "WALK", "WALK" },
    { "WALKS", "WALK" },
    { "WALL", "WALL" },
    { "WY", "WAY" },
    { "WAY", "WAY" },
    { "WAYS", "WAYS" },
    { "WELL", "WELL" },
    { "WL", "WL" },
    { "WELLS", "WELLS" },
    { "WLS", "WELLS" }
  };
}
