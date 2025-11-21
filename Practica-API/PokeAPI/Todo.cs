//  BERRIES
using System.Text.Json.Serialization;

public class Berry
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Growth_time { get; set; }
    public int Max_harvest { get; set; }
    public int Natural_gift_power { get; set; }
    public int Size { get; set; }
    public int Smoothness { get; set; }
    public int Soul_dryness { get; set; }
    public required Firmness Firmness { get; set; }
    public required Flavors[] Flavors { get; set; }
    public required Item Item { get; set; }
    public required Natural_gift_type Natural_Gift_Type { get; set; }
}

public class Firmness
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Flavors
{
    public int Potency { get; set; }
    public required Flavor Flavor { get; set; }
}

public class Flavor
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Item
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Natural_gift_type
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

//  POKEMON
public class PokemonData
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool Is_main_series { get; set; }
    public required Generation Generation { get; set; }
    public required Names[] Names { get; set; }
    public required Effect_entries[] Effect_Entries { get; set; }
    public required Effect_changes[] Effect_changes { get; set; }
    public required Flavor_text_entries[] Flavor_Text_Entries { get; set; }
    public required Pokemon[] Pokemon { get; set; }

}

public class Generation
{
    public required string Name { get; set; }
    public required string Url { get; set; }
    public required Abilities[] Abilities { get; set; }
    public required Main_region Main_region { get; set; }
    public required Moves[] Moves { get; set; }
    public required Names[] Names { get; set; }
    public required Pokemon_Species[] Pokemon_Species { get; set; }
    public required Types[] Types { get; set; }
    public required Version_groups[] Version_groups { get; set; }
}

public class Version_groups{
    public required string Name { get; set; }
    public required string Url{ get; set; }
}

public class Main_region{
    public required string Name { get; set; }
    public required string Url{ get; set; }
}

public class Names
{
    public required string Name { get; set; }
    public required Language Language { get; set; }
    public required int[] Past_Values{ get; set; }
    public required int[] Stat_Changes{ get; set; }
}

public class Abilities {
    public int Id { get; set; }
    public required string Name { get; set; }
}

public class Language
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Effect_entries
{
    public required string Effect { get; set; }
    public required string Short_effect { get; set; }
    public required Language Language { get; set; }
}

public class Effect_changes
{
    public required Version_group Version_group { get; set; }
    public required Effect_entries[] Effect_Entries { get; set; }
}

public class Version_group
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Flavor_text_entries
{
    public char Flavor_text { get; set; }
    public required Language Language { get; set; }
    public required Version_group Version_Group { get; set; }
}

public class Pokemon
{
    public bool is_hidden { get; set; }
    public int slot { get; set; }
    [JsonPropertyName("Pokemon")]
    public required PokemonType PokemonType { get; set; }
}

public class PokemonType
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

// POKEMON CHARACTERISTICS

public class Characteristcs
{
    public int Id { get; set; }
    public int Gene_modulo { get; set; }
    public required int[] Possible_values { get; set; }
    public required Highest_stat[] Highest_Stat { get; set; }
    public required Descriptions[] Descriptions { get; set; }
}

public class Highest_stat
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Descriptions
{
    public required string Description { get; set; }
    public required Language Language { get; set; }
}

//  POKEMON TYPES

public class Types
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Damage_Relations Damage_relations { get; set; }
    public required Past_Damage_Relations Past_damage_relations { get; set; }
    public required Game_Indices Game_indices { get; set; }
    public required Generation Generation { get; set; }
    public required Names Names { get; set; }
    public required Language Language { get; set; }
    public required Pokemon Pokemon { get; set; }
    public required Moves[] Moves { get; set; }
}

public class Damage_Relations
{
    public required No_Damage_To[] No_damage_to { get; set; }
    public required Half_Damage_To[] Half_damage_to { get; set; }
    public required Double_Damage_To[] Double_damage_to { get; set; }
    public required No_Damage_From[] No_damage_from { get; set; }
    public required Half_Damage_To[] Half_damage_from { get; set; }
    public required Double_Damage_To[] Double_damage_from { get; set; }
}

public class No_Damage_To
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Half_Damage_To
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Double_Damage_To
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class No_Damage_From
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Half_Damage_From
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Double_Damage_From
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Past_Damage_Relations
{
    public required Generation Generation { get; set; }
    public required Damage_Relations damage_Relations { get; set; }
}

public class Game_Indices
{
    public int Game_index { get; set; }
    public required Generation Generation { get; set; }
}

public class Moves
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

// POKEMON STATS

public class Stats
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Game_index { get; set; }
    public bool Is_battle_only { get; set; }
    public required Affecting_Moves Affecting_moves { get; set; }
    public required Affecting_Natures Affecting_natures { get; set; }
    public required Characteristcs Characteristcs { get; set; }
    public required Move_Damage_Class Move_damage_class { get; set; }
    public required Names Names { get; set; }
}

public class Affecting_Moves
{
    public required Increase[] Increase { get; set; }
    public required Decrease[] Descrease { get; set; }
}

public class Increase
{
    public required string Name { get; set; }
    public required string Url { get; set; }
    public int Change { get; set; }
    public required Move Move { get; set; }
}

public class Decrease
{
    public required string Name { get; set; }
    public required string Url { get; set; }
    public int Change { get; set; }
    public required Move Move { get; set; }
}

public class Move
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Affecting_Natures
{
    public required Increase[] Increase { get; set; }
    public required Decrease[] Decrease { get; set; }
}

public class Move_Damage_Class
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

// EVOLUTIONS 

public class Evolution_Chains {
    public required string Id { get; set; }
    public required string Baby_trigger_item { get; set; }
    public required Chain Chain { get; set; }
}

public class Chain {
    public bool Is_baby { get; set; }
    public required Species Species { get; set; }
    public required string Evolution_details { get; set; }
    public required Evolves_to[] Evolves_to { get; set; }
}

public class Species {
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Evolves_to{
    public bool Is_baby { get; set; }
    public required Species Species { get; set; }
    public required Evolution_details[] Evolution_details { get; set; }
    public required Evolves_to[] Evolves_to_pokemon { get; set; }
}

public class Evolution_details
{
    public required string Item { get; set; }
    public required Trigger Trigger { get; set; }
    public required string Gender { get; set; }
    public required string Held_Item { get; set; }
    public required string Known_Move { get; set; }
    public required string Known_Move_Type { get; set; }
    public int Min_Level { get; set; }
    public int Min_Happiness { get; set; }
    public int Min_Beauty { get; set; }
    public int Min_Affection { get; set; }
    public bool Need_Overworld_Rain { get; set; }
    public required string Party_Species { get; set; }
    public required string Party_Type { get; set; }
    public int Relative_Physical_Stats { get; set; }
    public required string Time_Of_Day { get; set; }
    public required string Trade_Species { get; set; }
    public bool Turn_Upside_Down { get; set; }

}

public class Trigger
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Evolution_Triggers {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Names Names { get; set; }
    public required Pokemon_Species[] Pokemon_Species { get; set; } 
}

public class Pokemon_Species {
    public required string Name { get; set; }
    public required string Url { get; set; }
}

// GAMES

public class Pokedex {
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool Is_main_series { get; set; }
    public required Descriptions[] Descriptions { get; set; }
    public required Names[] Names { get; set; }
    public required Pokemon_entries[] Pokemon_entries { get; set; }
    public required Region Region { get; set; }
    public required Version_groups[] Version_groups { get; set; }
}

public class  Pokemon_entries {
    public int Entry_number { get; set; }
    public required Pokemon_Species Pokemon_Species { get; set; }
}

public class Region{
    public required string Name { get; set; }
    public required string Url { get; set; }
}
