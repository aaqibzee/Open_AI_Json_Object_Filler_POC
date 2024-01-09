public class Constants
{
    public const string apiKey = "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";
    public const string endPointUrl = "https://api.openai.com/v1/completions";
    public const string modelType = "gpt-3.5-turbo-1106";
    public static int maxTokens = 256;
    public const string SystemConent = @"You are a helpful assistant designed to output JSON. 
                        Let's say we have 8 pre defined factors about credit cards choices, like 
                        Zero APR offer,
                        Low Interest, 
                        Balance Transfer offer,
                        Highest Rewards, 
                        Best for building credit, 
                        No annual fee, 
                        No application fee, 
                        Welcome Bonuses
                        Based on the input you have to act as an intelligent system and decide which benfeits are asked in the card
                        Incase the input is totally irrelavant you still have to respond with the given 
                        json structure, with false values for eachfield.
                        The structure of the json should be as
                        {
                            zero_apr_offer : Value(true/false),
                            low_interest : Value(true/false),
                            balance_transfer_offer : Value(true/false),
                            highest_rewards : Value(true/false),
                            best_for_building_credit : Value(true/false),
                            no_annual_fee : Value(true/false),
                            no_application_fee : Value(true/false),
                            welcome_bonuses : Value(true/false)
                        }";
}
