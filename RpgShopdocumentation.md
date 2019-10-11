| Reid Eastin
| :-
| s198012
| Intro to c# assement
|Rpg shop simulator

## I. Requirements

1. Description of problem

    - **Name**: Rpg Shop Simulator

    - **Problem Statement** : The Program must have a inventory for both the store and the player. The player can buy items from the store inventory and the items will be added to their inventory and it will be removed from the store. The player can sell items from their inventory and it will be added to shop inventory and removed from the players inventory. The game must also save and load gold for both player and shop and be able to save and load both inventorys.



2. Input information
        - The player uses the keyboard to pick a option

3. Output Information
    The program will do diferent things based on which options the player picks
    The player can see the shop inventory by picking the buy/sell option. They also see both shop and player gold in this menu
    

4. User Interface Information

    

## II. Design

1. System Architecture

|Game Diagram
|:-
| ![Game Diagram](https://i.imgur.com/0TvQVWJ.jpg)
The game opens up on the menu. The player can pick to save, load or buy/sell, or close the program. The shop memu will open if the player picks buy/sell. If the player has a save they can pick load.

|shop menu diagram
|:-
| ![Shop menu diagram](https://i.imgur.com/l7fCLgt.jpg)
In the shop menu the player can pick to buy or sell. If the store does not have enough gold the player can sell. If the player does not have enough gold they cant buy the item




3. ### Object Information

    **File** : Shop.cs

    Description: Holds most of the code for them menus used in the game. It also hold gold.

    **Attributes**

        Name: choice
            Description: used to know what the player picks in most of the menues
            Type: string

        Name: _shopgold
            Description: used to store the shops gold
            Type: int

        Name: _playergold
            Description: used to store player gold
            Type: int

        Name: shop
            description: Used for program to know if it should end the while loop
            type: bool

        Name: shopchoice
            Description: Used for picking a weapon in the weapon buy menu
            Type: int

        

        Name: ValidChoice
            Description: used with while loops to see if the choice is valid
            Type: bool

    **Operations**

        Name: PlayerGold
            Description: This is a property that allows other classes to get and set the player gold
            Type: Property

        Name: ShopGold
            Description: This property allows other classes to change the gold
            Type: Property

        Name: Cheats
            Description: This function is a hidden function for adding weapons to the shop or player. You can also add gold using this.
            Type: Function

    **File**: Inventory

    Description: Used to for both the players and stores inventory. It has functions that allow things to be added and removed

        **Operations**
            Name: Remove
                Description: Used to remove things from the array used for the inventory used by the player and shop
                Type: Function

            Name: Add
                Description: Used to add items to the array for both player and the shop
                Type: Function

            Name: Clear
                Description: Used to clear the player or the store inventory before loading the save
                Type: Function

            Name: Saving
                Description: This is the function that saves the game. It is run twice and saves each inventory in its own text file.
                Type: Function

            Name: Loading
                Description: This loads the game. It uses the save files path to know if the gold is for the shop or the player
                Type Function

            Name: OpenInventory
                Description: This shows a list of the items in the inventory that you want
                Type: Function

            Name: GetCost
                Description: returns the cost of the selected item by using the getcost function in item class
                Type: Function

            Name: GetItem
                Description: Used to get the item from the array for use with a temp item in the shop class

            Name: GetLength
                Description: Function used to get the lengtht of the array
                Type: function

            Name: Inventory
                Description: Constructor used for making inventories for both the player and the shop
                Type: Constructor

    **File**: Item

        Description: Holds consturctor for items in the game and holds variables and functions used for the game
        
        
            **Operations**

                Name: Print Item
                    Description: This virtual function is used to print info about the items for the inventory
                    Type: function

                Name: Item
                    Description: Constructor that is used for making items
                    Type: Constructor

                Name: GetCost
                    Description: Gets the cost of the item for use with the get cost function
                    Type: function 

                Name: GetName
                    Description: Gets the name of the item
                    Type: Function

                Name: GetitemType
                    Description: virtual function used in saving to see if it is armor or sword
                    Type: Function

                Name: GetStats
                    Description: Virtual function that gets the damage if it is a sword and gets defense if it is armor
                    Type: Function

                Name: getdescription
                    Description: gets the description of the item
                    Type: Function
            **Attributes**

                Name: _cost
                    Description: holds the value for cost of each item
                    Type: Int

                Name: _name
                    Description: Used for storing the name of each item
                    Type: String

                Name: _description
                    Description: holds the description for each weapon

    **File**: Weapon
        Description: This class hold variables and functions for weapons

            **Operations**
                Name: GetDamage
                    Description: Used to return damage for use with the save function
                    Type: Function

                Name: Weapons
                    Description: This is the constructor for weapons
                    Type: Constructor

                Name: Print Item
                    Description: This is used for printing the iten to show it in the store and player inventory
                    Type: Function

                Name: GetItemType
                    Description: This is used for saving so when loading the program can see if it is a weapon or armor
                    Type: Function
                    
                Name: Getstats
                    Description: This is used to get the damage from weapons for use with saving
                    Type: Function

            **Atributs** 
            
                Name: _damage
                Description: Used to show weapons damage
                Type: Int

    **File**: Armor
        Description: This class is used for variables and fucntions for armor

            **Operations**
                Name: Getdefense
                    Description: Used to return defense for use with the save function
                    Type: Function

                Name: Armor
                    Description: This is the constructor for armor
                    Type: Constructor

                Name: Print Item
                    Description: This is used for printing the iten to show it in the store and player inventory
                    Type: Function

                Name: GetItemType
                    Description: This is used for saving so when loading the program can see if it is a weapon or armor
                    Type: Function
                    
                Name: Getstats
                    Description: This is used to get the defense from armor for use with saving
                    Type: Function

            **Atributs** 
            
                Name: _defense
                Description: Used to show armors defense
                Type: Int
