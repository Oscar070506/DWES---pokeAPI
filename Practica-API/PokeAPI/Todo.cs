//  BERRIES
using System.Text.Json.Serialization;

public class Berry
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Growth_time { get; set; }
    public int Max_harvest { get; set; }
    public int Natural_gift_power { get; set; }
    public int Size { get; set; }
    public int Smoothness { get; set; }
    public int Soul_dryness { get; set; }
    public Firmness Firmness { get; set; }
    public Flavors[] Flavors { get; set; }
    public Item Item { get; set; }
    public Natural_gift_type Natural_Gift_Type { get; set; }
}

public class Firmness
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Flavors
{
    public int Potency { get; set; }
    public Flavor Flavor { get; set; }
}

public class Flavor
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Item
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Natural_gift_type
{
    public string Name { get; set; }
    public string Url { get; set; }
}

//  POKEMON
public class PokemonData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Is_main_series { get; set; }
    public Generation Generation { get; set; }
    public Names[] Names { get; set; }
    public Effect_entries[] Effect_Entries { get; set; }
    public Effect_changes[] Effect_changes { get; set; }
    public Flavor_text_entries[] Flavor_Text_Entries { get; set; }
    public Pokemon[] Pokemon { get; set; }

}

public class Generation
{
    public string Name { get; set; }
    public string Url { get; set; }
    public Abilities[] Abilities { get; set; }
    public Main_region Main_region { get; set; }
    public Moves[] Moves { get; set; }
    public Names[] Names { get; set; }
    public Pokemon_Species[] Pokemon_Species { get; set; }
    public Types[] Types { get; set; }
    public Version_groups[] Version_groups { get; set; }
}

public class Version_groups{
    public string Name { get; set; }
    public string Url{ get; set; }
}

public class Main_region{
    public string Name { get; set; }
    public string Url{ get; set; }
}

public class Names
{
    public string Name { get; set; }
    public Language Language { get; set; }
    public int[] Past_Values{ get; set; }
    public int[] Stat_Changes{ get; set; }
}

public class Abilites {
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Language
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Effect_entries
{
    public string Effect { get; set; }
    public string Short_effect { get; set; }
    public Language Language { get; set; }
}

public class Effect_changes
{
    public Version_group Version_group { get; set; }
    public Effect_entries[] Effect_Entries { get; set; }
}

public class Version_group
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Flavor_text_entries
{
    public char Flavor_text { get; set; }
    public Language Language { get; set; }
    public Version_group Version_Group { get; set; }
}

public class Pokemon
{
    public bool is_hidden { get; set; }
    public int slot { get; set; }
    [JsonPropertyName("Pokemon")]
    public PokemonType PokemonType { get; set; }
}

public class PokemonType
{
    public string Name { get; set; }
    public string Url { get; set; }
}

// POKEMON CHARACTERISTICS

public class Characteristcs
{
    public int Id { get; set; }
    public int Gene_modulo { get; set; }
    public int[] Possible_values { get; set; }
    public Highest_stat[] Highest_Stat { get; set; }
    public Descriptions[] Descriptions { get; set; }
}

public class Highest_stat
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Descriptions
{
    public string Description { get; set; }
    public Language Language { get; set; }
}

//  POKEMON TYPES

public class Types
{
    public int Id { get; set; }
    public string Dame { get; set; }
    public Damage_Relations Damage_relations { get; set; }
    public Past_Damage_Relations Past_damage_relations { get; set; }
    public Game_Indices Game_indices { get; set; }
    public Generation Generation { get; set; }
    public Names Names { get; set; }
    public Language Language { get; set; }
    public Pokemon Pokemon { get; set; }
    public Moves[] Moves { get; set; }
}

public class Damage_Relations
{
    public No_Damage_To[] No_damage_to { get; set; }
    public Half_Damage_To[] Half_damage_to { get; set; }
    public Double_Damage_To[] Double_damage_to { get; set; }
    public No_Damage_From[] No_damage_from { get; set; }
    public Half_Damage_To[] Half_damage_from { get; set; }
    public Double_Damage_To[] Double_damage_from { get; set; }
}

public class No_Damage_To
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Half_Damage_To
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Double_Damage_To
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class No_Damage_From
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Half_Damage_From
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Double_Damage_From
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Past_Damage_Relations
{
    public Generation generation { get; set; }
    public Damage_Relations damage_Relations { get; set; }
}

public class Game_Indices
{
    public int Game_index { get; set; }
    public Generation Generation { get; set; }
}

public class Moves
{
    public string Name { get; set; }
    public string Url { get; set; }
}

// POKEMON STATS

public class Stats
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Game_index { get; set; }
    public bool Is_battle_only { get; set; }
    public Affecting_Moves Affecting_moves { get; set; }
    public Affecting_Natures Affecting_natures { get; set; }
    public Characteristcs Characteristcs { get; set; }
    public Move_Damage_Class Move_damage_class { get; set; }
    public Names Names { get; set; }
}

public class Affecting_Moves
{
    public Increase[] Increase { get; set; }
    public Decrease[] Descrease { get; set; }
}

public class Increase
{
    public string Name { get; set; }
    public string Url { get; set; }
    public int Change { get; set; }
    public Move Move { get; set; }
}

public class Decrease
{
    public string Name { get; set; }
    public string Url { get; set; }
    public int Change { get; set; }
    public Move Move { get; set; }
}

public class Move
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Affecting_Natures
{
    public Increase[] Increase { get; set; }
    public Decrease[] Decrease { get; set; }
}

public class Move_Damage_Class
{
    public string Name { get; set; }
    public string Url { get; set; }
}

// EVOLUTIONS 

public class Evolution_Chains {
    public string Id { get; set; }
    public string Baby_trigger_item { get; set; }
    public Chain Chain { get; set; }
}

public class Chain {
    public bool Is_baby { get; set; }
    public Species Species { get; set; }
    public string Evolution_details { get; set; }
    public Evolves_to[] Evolves_to { get; set; }
}

public class Species {
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Evolves_to{
    public bool Is_baby { get; set; }
    public Species Species { get; set; }
    public Evolution_details[] Evolution_details { get; set; }
    public Evolves_to[] Evolves_to_pokemon { get; set; }
}

public class Evolution_details
{
    public string Item { get; set; }
    public Trigger Trigger { get; set; }
    public string Gender { get; set; }
    public string Held_Item { get; set; }
    public string Known_Move { get; set; }
    public string Known_Move_Type { get; set; }
    public int Min_Level { get; set; }
    public int Min_Happiness { get; set; }
    public int Min_Beauty { get; set; }
    public int Min_Affection { get; set; }
    public bool Need_Overworld_Rain { get; set; }
    public string Party_Species { get; set; }
    public string Party_Type { get; set; }
    public int Relative_Physical_Stats { get; set; }
    public string Time_Of_Day { get; set; }
    public string Trade_Species { get; set; }
    public bool Turn_Upside_Down { get; set; }

}

public class Trigger
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Evolution_Triggers {
    public int Id { get; set; }
    public string Name { get; set; }
    public Names Names { get; set; }
    public Pokemon_Species[] Pokemon_Species { get; set; } 
}

public class Pokemon_Species {
    public string Name { get; set; }
    public string Url { get; set; }
}

// GAMES

public class Pokedex {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Is_main_series { get; set; }
    public Descriptions[] Descriptions { get; set; }
    public Names[] Names { get; set; }
    public Pokemon_entries[] Pokemon_entries { get; set; }
    public Region Region { get; set; }
    public Version_groups[] Version_groups { get; set; }
}

public class  Pokemon_entries {
    public int Entry_number { get; set; }
    public Pokemon_Species Pokemon_Species { get; set; }
}

public class Region{
    public string Name { get; set; }
    public string Url { get; set; }
}
