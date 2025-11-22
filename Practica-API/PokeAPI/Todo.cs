//  BERRIES
using System.Text.Json.Serialization;

public class Berry
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("growth_time")]
    public int GrowthTime { get; set; }

    [JsonPropertyName("max_harvest")]
    public int MaxHarvest { get; set; }

    [JsonPropertyName("natural_gift_power")]
    public int NaturalGiftPower { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("smoothness")]
    public int Smoothness { get; set; }

    [JsonPropertyName("soil_dryness")]
    public int SoilDryness { get; set; }

    [JsonPropertyName("firmness")]
    public required Firmness Firmness { get; set; }

    [JsonPropertyName("flavors")]
    public required FlavorWrapper[] Flavors { get; set; }
    [JsonPropertyName("item")]
    public required Item Item { get; set; }

    [JsonPropertyName("natural_gift_type")]
    public required NaturalGiftType NaturalGiftType { get; set; }
}
public class BerryListResponse
{
    public List<NamedResource> Results { get; set; } = new();
}

public class NamedResource
{
    public string Name { get; set; } = "";
    public string Url { get; set; } = "";
}
public class Firmness
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class FlavorWrapper
{
    [JsonPropertyName("potency")]
    public int Potency { get; set; }

    [JsonPropertyName("flavor")]
    public required Flavor Flavor { get; set; }
}

public class BerryColorResponse
{
    public required BerryReference[] Berries { get; set; }
}

public class Flavor
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class Item
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class NaturalGiftType
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}
public class BerryFlavorResponse
{
    [JsonPropertyName("berries")]
    public required BerryReference[] Berries { get; set; }
}

public class BerryReference
{
    [JsonPropertyName("berry")]
    public required BerryUrl Berry { get; set; }
}

public class BerryUrl
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

//  POKEMON
public class PokemonData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("is_main_series")]
    public bool IsMainSeries { get; set; }

    [JsonPropertyName("generation")]
    public required Generation Generation { get; set; }

    [JsonPropertyName("names")]
    public required NameEntry[] Names { get; set; }

    [JsonPropertyName("effect_entries")]
    public required EffectEntry[] EffectEntries { get; set; }

    [JsonPropertyName("effect_changes")]
    public required EffectChange[] EffectChanges { get; set; }

    [JsonPropertyName("flavor_text_entries")]
    public required FlavorTextEntry[] FlavorTextEntries { get; set; }

    [JsonPropertyName("pokemon")]
    public required PokemonEntry[] Pokemon { get; set; }
}

public class PokemonColorResponse
{
    public string Name { get; set; } = ""; // El color
    public List<PokemonSpeciesInfo> PokemonSpecies { get; set; } = new();
    public List<PokemonInfo> PokemonInfo { get; set; } = new();
}

public class PokemonSpeciesInfo
{
    public string Name { get; set; } = "";
    public string Url { get; set; } = ""; // URL para obtener más info del Pokémon
}

public class PokemonInfo
{
    public int DexNumber { get; set; }
    public string Name { get; set; } = "";
    public string Color { get; set; } = "";
    public List<string> Types { get; set; } = new();
    public string EvolutionStage { get; set; } = "";
}
public class Generation
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class NameEntry
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("language")]
    public required Language Language { get; set; }
}

public class Language
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class EffectEntry
{
    [JsonPropertyName("effect")]
    public required string Effect { get; set; }

    [JsonPropertyName("short_effect")]
    public required string ShortEffect { get; set; }

    [JsonPropertyName("language")]
    public required Language Language { get; set; }
}

public class EffectChange
{
    [JsonPropertyName("version_group")]
    public required VersionGroup VersionGroup { get; set; }

    [JsonPropertyName("effect_entries")]
    public required EffectEntry[] EffectEntries { get; set; }
}

public class VersionGroup
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class FlavorTextEntry
{
    [JsonPropertyName("flavor_text")]
    public required string FlavorText { get; set; }

    [JsonPropertyName("language")]
    public required Language Language { get; set; }

    [JsonPropertyName("version_group")]
    public required VersionGroup VersionGroup { get; set; }
}

public class PokemonEntry
{
    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }

    [JsonPropertyName("slot")]
    public int Slot { get; set; }

    [JsonPropertyName("pokemon")]
    public required PokemonType PokemonType { get; set; }
}

public class PokemonType
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

// POKEMON CHARACTERISTICS

public class Characteristic
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("gene_modulo")]
    public int GeneModulo { get; set; }

    [JsonPropertyName("possible_values")]
    public required int[] PossibleValues { get; set; }

    [JsonPropertyName("highest_stat")]
    public required HighestStat[] HighestStat { get; set; }

    [JsonPropertyName("descriptions")]
    public required Description[] Descriptions { get; set; }
}

public class HighestStat
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class Description
{
    [JsonPropertyName("description")]
    public required string Text { get; set; }

    [JsonPropertyName("language")]
    public required Language Language { get; set; }
}


//  POKEMON TYPES

public class DamageRelations
{
    [JsonPropertyName("no_damage_to")]
    public required NamedAPIResource[] NoDamageTo { get; set; }

    [JsonPropertyName("half_damage_to")]
    public required NamedAPIResource[] HalfDamageTo { get; set; }

    [JsonPropertyName("double_damage_to")]
    public required NamedAPIResource[] DoubleDamageTo { get; set; }

    [JsonPropertyName("no_damage_from")]
    public required NamedAPIResource[] NoDamageFrom { get; set; }

    [JsonPropertyName("half_damage_from")]
    public required NamedAPIResource[] HalfDamageFrom { get; set; }

    [JsonPropertyName("double_damage_from")]
    public required NamedAPIResource[] DoubleDamageFrom { get; set; }
}

public class NamedAPIResource
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

public class PastDamageRelation
{
    [JsonPropertyName("generation")]
    public required Generation Generation { get; set; }

    [JsonPropertyName("damage_relations")]
    public required DamageRelations DamageRelations { get; set; }
}

public class GameIndex
{
    [JsonPropertyName("game_index")]
    public int GameIndexValue { get; set; }

    [JsonPropertyName("generation")]
    public required Generation Generation { get; set; }
}

public class Move
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

// POKEMON STATS

public class Stat
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("game_index")]
    public int GameIndex { get; set; }

    [JsonPropertyName("is_battle_only")]
    public bool IsBattleOnly { get; set; }

    [JsonPropertyName("affecting_moves")]
    public required AffectingMoves AffectingMoves { get; set; }

    [JsonPropertyName("affecting_natures")]
    public required AffectingNatures AffectingNatures { get; set; }

    [JsonPropertyName("characteristics")]
    public required Characteristic Characteristic { get; set; }

    [JsonPropertyName("move_damage_class")]
    public required MoveDamageClass MoveDamageClass { get; set; }

    [JsonPropertyName("names")]
    public required NameEntry[] Names { get; set; }
}

public class AffectingMoves
{
    [JsonPropertyName("increase")]
    public required StatMove[] Increase { get; set; }

    [JsonPropertyName("decrease")]
    public required StatMove[] Decrease { get; set; }
}

public class StatMove
{
    [JsonPropertyName("move")]
    public required NamedAPIResource Move { get; set; }

    [JsonPropertyName("change")]
    public int Change { get; set; }
}

public class AffectingNatures
{
    [JsonPropertyName("increase")]
    public required NamedAPIResource[] Increase { get; set; }

    [JsonPropertyName("decrease")]
    public required NamedAPIResource[] Decrease { get; set; }
}

public class MoveDamageClass
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

// EVOLUTIONS 

public class EvolutionChain
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("baby_trigger_item")]
    public NamedAPIResource? BabyTriggerItem { get; set; }

    [JsonPropertyName("chain")]
    public required ChainLink Chain { get; set; }
}

public class ChainLink
{
    [JsonPropertyName("is_baby")]
    public bool IsBaby { get; set; }

    [JsonPropertyName("species")]
    public required NamedAPIResource Species { get; set; }

    [JsonPropertyName("evolution_details")]
    public EvolutionDetail[] EvolutionDetails { get; set; } = Array.Empty<EvolutionDetail>();

    [JsonPropertyName("evolves_to")]
    public ChainLink[] EvolvesTo { get; set; } = Array.Empty<ChainLink>();
}

public class EvolutionDetail
{
    [JsonPropertyName("item")]
    public NamedAPIResource? Item { get; set; }

    [JsonPropertyName("trigger")]
    public required NamedAPIResource Trigger { get; set; }

    [JsonPropertyName("gender")]
    public int? Gender { get; set; }

    [JsonPropertyName("held_item")]
    public NamedAPIResource? HeldItem { get; set; }

    [JsonPropertyName("known_move")]
    public NamedAPIResource? KnownMove { get; set; }

    [JsonPropertyName("known_move_type")]
    public NamedAPIResource? KnownMoveType { get; set; }

    [JsonPropertyName("min_level")]
    public int? MinLevel { get; set; }

    [JsonPropertyName("min_happiness")]
    public int? MinHappiness { get; set; }

    [JsonPropertyName("min_beauty")]
    public int? MinBeauty { get; set; }

    [JsonPropertyName("min_affection")]
    public int? MinAffection { get; set; }

    [JsonPropertyName("needs_overworld_rain")]
    public bool NeedsOverworldRain { get; set; }

    [JsonPropertyName("party_species")]
    public NamedAPIResource? PartySpecies { get; set; }

    [JsonPropertyName("party_type")]
    public NamedAPIResource? PartyType { get; set; }

    [JsonPropertyName("relative_physical_stats")]
    public int? RelativePhysicalStats { get; set; }

    [JsonPropertyName("time_of_day")]
    public string TimeOfDay { get; set; } = "";

    [JsonPropertyName("trade_species")]
    public NamedAPIResource? TradeSpecies { get; set; }

    [JsonPropertyName("turn_upside_down")]
    public bool TurnUpsideDown { get; set; }
}

public class EvolutionTrigger
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("names")]
    public NameEntry[] Names { get; set; } = Array.Empty<NameEntry>();

    [JsonPropertyName("pokemon_species")]
    public NamedAPIResource[] PokemonSpecies { get; set; } = Array.Empty<NamedAPIResource>();
}


// GAMES

public class Pokedex
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("is_main_series")]
    public bool IsMainSeries { get; set; }

    [JsonPropertyName("descriptions")]
    public Description[] Descriptions { get; set; } = Array.Empty<Description>();

    [JsonPropertyName("names")]
    public NameEntry[] Names { get; set; } = Array.Empty<NameEntry>();

    [JsonPropertyName("pokemon_entries")]
    public PokemonEntry[] PokemonEntries { get; set; } = Array.Empty<PokemonEntry>();

    [JsonPropertyName("region")]
    public NamedAPIResource Region { get; set; } = new NamedAPIResource();

    [JsonPropertyName("version_groups")]
    public NamedAPIResource[] VersionGroups { get; set; } = Array.Empty<NamedAPIResource>();
}

