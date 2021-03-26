public class DialogueOption
{
    private int id;
    private string button_text;
    private string player_dialogue;
    private string alison_dialogue;
    private int option1_id;
    private int option2_id;
    private string mood;

    public DialogueOption(int id, string button_text, string player_dialogue, string alison_dialogue, int option1, int option2, string mood)
    {
        this.id = id;
        this.button_text = button_text;
        this.player_dialogue = player_dialogue;
        this.alison_dialogue = alison_dialogue;
        this.option1_id = option1;
        this.option2_id = option2;
        this.mood = mood;
    }

    public int get_id()
    {
        return this.id;
    }

    public string get_button_text()
    {
        return this.button_text;
    }

    public string get_player_dialogue()
    {
        return this.player_dialogue;
    }

    public string get_alison_dialogue()
    {
        return this.alison_dialogue;
    }

    public int get_option_1()
    {
        return this.option1_id;
    }

    public int get_option_2()
    {
        return this.option2_id;
    }

    public string get_mood()
    {
        return this.mood;
    }

}
