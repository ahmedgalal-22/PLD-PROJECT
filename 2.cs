
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                      =  0, // (EOF)
        SYMBOL_ERROR                    =  1, // (Error)
        SYMBOL_WHITESPACE               =  2, // Whitespace
        SYMBOL_APOST                    =  3, // ''
        SYMBOL_MINUS                    =  4, // '-'
        SYMBOL_MINUSMINUS               =  5, // '--'
        SYMBOL_EXCLAMEQ                 =  6, // '!='
        SYMBOL_PERCENT                  =  7, // '%'
        SYMBOL_LPAREN                   =  8, // '('
        SYMBOL_RPAREN                   =  9, // ')'
        SYMBOL_TIMES                    = 10, // '*'
        SYMBOL_COMMA                    = 11, // ','
        SYMBOL_DIV                      = 12, // '/'
        SYMBOL_SEMI                     = 13, // ';'
        SYMBOL_LBRACE                   = 14, // '{'
        SYMBOL_RBRACE                   = 15, // '}'
        SYMBOL_PLUS                     = 16, // '+'
        SYMBOL_PLUSPLUS                 = 17, // '++'
        SYMBOL_LT                       = 18, // '<'
        SYMBOL_EQ                       = 19, // '='
        SYMBOL_EQEQ                     = 20, // '=='
        SYMBOL_GT                       = 21, // '>'
        SYMBOL_CALL                     = 22, // Call
        SYMBOL_DIGIT                    = 23, // Digit
        SYMBOL_DOUBLE                   = 24, // double
        SYMBOL_ELSE                     = 25, // else
        SYMBOL_ENDSYMBOL                = 26, // EndSymbol
        SYMBOL_FLOAT                    = 27, // float
        SYMBOL_FOR                      = 28, // For
        SYMBOL_FUNCTION                 = 29, // Function
        SYMBOL_ID                       = 30, // Id
        SYMBOL_IF                       = 31, // if
        SYMBOL_INT                      = 32, // int
        SYMBOL_STARTSYMBOL              = 33, // StartSymbol
        SYMBOL_STRING                   = 34, // string
        SYMBOL_ARGUMENT                 = 35, // <argument>
        SYMBOL_ARGUMENTS                = 36, // <arguments>
        SYMBOL_ASSIGNMENT               = 37, // <assignment>
        SYMBOL_CONDITION                = 38, // <condition>
        SYMBOL_DATATYPE                 = 39, // <datatype>
        SYMBOL_DECL                     = 40, // <decl>
        SYMBOL_EXPRESSION               = 41, // <expression>
        SYMBOL_FACTOR_EXPRESSION        = 42, // <factor_expression>
        SYMBOL_FOR_STATEMENT            = 43, // <for_statement>
        SYMBOL_FUNCTION_CALL            = 44, // <function_call>
        SYMBOL_FUNCTION_DEFINITION      = 45, // <function_definition>
        SYMBOL_IDENTIFIER               = 46, // <identifier>
        SYMBOL_IF_STATEMENT             = 47, // <if_statement>
        SYMBOL_INCREMENT_DECREMENT      = 48, // <increment_decrement>
        SYMBOL_NUMERIC_DIGIT            = 49, // <numeric_digit>
        SYMBOL_OPERATOR                 = 50, // <operator>
        SYMBOL_PARAMETER                = 51, // <parameter>
        SYMBOL_PARAMETERS               = 52, // <parameters>
        SYMBOL_PARENTHESIZED_EXPRESSION = 53, // <parenthesized_expression>
        SYMBOL_START_SYMBOL             = 54, // <start_symbol>
        SYMBOL_STATEMENT                = 55, // <statement>
        SYMBOL_STATEMENT_LIST           = 56, // <statement_list>
        SYMBOL_TERM_EXPRESSION          = 57  // <term_expression>
    };

    enum RuleConstants : int
    {
        RULE_START_SYMBOL_STARTSYMBOL_ENDSYMBOL                                                                 =  0, // <start_symbol> ::= StartSymbol <statement_list> EndSymbol
        RULE_STATEMENT_LIST                                                                                     =  1, // <statement_list> ::= <statement>
        RULE_STATEMENT_LIST2                                                                                    =  2, // <statement_list> ::= <statement> <statement_list>
        RULE_STATEMENT                                                                                          =  3, // <statement> ::= <assignment>
        RULE_STATEMENT2                                                                                         =  4, // <statement> ::= <if_statement>
        RULE_STATEMENT3                                                                                         =  5, // <statement> ::= <for_statement>
        RULE_STATEMENT4                                                                                         =  6, // <statement> ::= <function_definition>
        RULE_STATEMENT5                                                                                         =  7, // <statement> ::= <function_call>
        RULE_DECL                                                                                               =  8, // <decl> ::= <datatype> <identifier>
        RULE_DECL2                                                                                              =  9, // <decl> ::= <datatype> <assignment>
        RULE_ASSIGNMENT_EQ_SEMI                                                                                 = 10, // <assignment> ::= <identifier> '=' <expression> ';'
        RULE_IDENTIFIER_ID                                                                                      = 11, // <identifier> ::= Id
        RULE_EXPRESSION_PLUS                                                                                    = 12, // <expression> ::= <term_expression> '+' <expression>
        RULE_EXPRESSION_MINUS                                                                                   = 13, // <expression> ::= <term_expression> '-' <expression>
        RULE_EXPRESSION                                                                                         = 14, // <expression> ::= <term_expression>
        RULE_TERM_EXPRESSION_TIMES                                                                              = 15, // <term_expression> ::= <factor_expression> '*' <term_expression>
        RULE_TERM_EXPRESSION_DIV                                                                                = 16, // <term_expression> ::= <factor_expression> '/' <term_expression>
        RULE_TERM_EXPRESSION_PERCENT                                                                            = 17, // <term_expression> ::= <factor_expression> '%' <term_expression>
        RULE_TERM_EXPRESSION                                                                                    = 18, // <term_expression> ::= <factor_expression>
        RULE_FACTOR_EXPRESSION_APOST                                                                            = 19, // <factor_expression> ::= <parenthesized_expression> '' <factor_expression>
        RULE_FACTOR_EXPRESSION                                                                                  = 20, // <factor_expression> ::= <parenthesized_expression>
        RULE_PARENTHESIZED_EXPRESSION_LPAREN_RPAREN                                                             = 21, // <parenthesized_expression> ::= '(' <expression> ')'
        RULE_PARENTHESIZED_EXPRESSION                                                                           = 22, // <parenthesized_expression> ::= <identifier>
        RULE_PARENTHESIZED_EXPRESSION2                                                                          = 23, // <parenthesized_expression> ::= <numeric_digit>
        RULE_NUMERIC_DIGIT_DIGIT                                                                                = 24, // <numeric_digit> ::= Digit
        RULE_IF_STATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE                                                        = 25, // <if_statement> ::= if '(' <condition> ')' '{' <statement_list> '}'
        RULE_IF_STATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE                                     = 26, // <if_statement> ::= if '(' <condition> ')' '{' <statement_list> '}' else '{' <statement_list> '}'
        RULE_IF_STATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_IF_LPAREN_RPAREN_LBRACE_RBRACE                    = 27, // <if_statement> ::= if '(' <condition> ')' '{' <statement_list> '}' else if '(' <condition> ')' '{' <statement_list> '}'
        RULE_IF_STATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE = 28, // <if_statement> ::= if '(' <condition> ')' '{' <statement_list> '}' else if '(' <condition> ')' '{' <statement_list> '}' else '{' <statement_list> '}'
        RULE_CONDITION                                                                                          = 29, // <condition> ::= <expression> <operator> <expression>
        RULE_OPERATOR_EXCLAMEQ                                                                                  = 30, // <operator> ::= '!='
        RULE_OPERATOR_EQEQ                                                                                      = 31, // <operator> ::= '=='
        RULE_OPERATOR_LT                                                                                        = 32, // <operator> ::= '<'
        RULE_OPERATOR_GT                                                                                        = 33, // <operator> ::= '>'
        RULE_FOR_STATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE                                            = 34, // <for_statement> ::= For '(' <datatype> <assignment> ';' <condition> ';' <increment_decrement> ')' '{' <statement_list> '}'
        RULE_DATATYPE_INT                                                                                       = 35, // <datatype> ::= int
        RULE_DATATYPE_FLOAT                                                                                     = 36, // <datatype> ::= float
        RULE_DATATYPE_DOUBLE                                                                                    = 37, // <datatype> ::= double
        RULE_DATATYPE_STRING                                                                                    = 38, // <datatype> ::= string
        RULE_INCREMENT_DECREMENT_MINUSMINUS                                                                     = 39, // <increment_decrement> ::= '--' <identifier>
        RULE_INCREMENT_DECREMENT_PLUSPLUS                                                                       = 40, // <increment_decrement> ::= '++' <identifier>
        RULE_INCREMENT_DECREMENT_MINUSMINUS2                                                                    = 41, // <increment_decrement> ::= <identifier> '--'
        RULE_INCREMENT_DECREMENT_PLUSPLUS2                                                                      = 42, // <increment_decrement> ::= <identifier> '++'
        RULE_INCREMENT_DECREMENT                                                                                = 43, // <increment_decrement> ::= <assignment>
        RULE_FUNCTION_DEFINITION_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE                                           = 44, // <function_definition> ::= Function <identifier> '(' <parameters> ')' '{' <statement_list> '}'
        RULE_PARAMETERS                                                                                         = 45, // <parameters> ::= <parameter>
        RULE_PARAMETERS_COMMA                                                                                   = 46, // <parameters> ::= <parameter> ',' <parameters>
        RULE_PARAMETER                                                                                          = 47, // <parameter> ::= <identifier>
        RULE_FUNCTION_CALL_CALL_LPAREN_RPAREN_SEMI                                                              = 48, // <function_call> ::= Call <identifier> '(' <arguments> ')' ';'
        RULE_ARGUMENTS                                                                                          = 49, // <arguments> ::= <argument>
        RULE_ARGUMENTS_COMMA                                                                                    = 50, // <arguments> ::= <argument> ',' <arguments>
        RULE_ARGUMENT                                                                                           = 51  // <argument> ::= <expression>
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_APOST :
                //''
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CALL :
                //Call
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENDSYMBOL :
                //EndSymbol
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //For
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //Function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STARTSYMBOL :
                //StartSymbol
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENT :
                //<argument>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTS :
                //<arguments>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATATYPE :
                //<datatype>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECL :
                //<decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR_EXPRESSION :
                //<factor_expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STATEMENT :
                //<for_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_CALL :
                //<function_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_DEFINITION :
                //<function_definition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //<identifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STATEMENT :
                //<if_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INCREMENT_DECREMENT :
                //<increment_decrement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMERIC_DIGIT :
                //<numeric_digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPERATOR :
                //<operator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER :
                //<parameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERS :
                //<parameters>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARENTHESIZED_EXPRESSION :
                //<parenthesized_expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START_SYMBOL :
                //<start_symbol>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT_LIST :
                //<statement_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM_EXPRESSION :
                //<term_expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_START_SYMBOL_STARTSYMBOL_ENDSYMBOL :
                //<start_symbol> ::= StartSymbol <statement_list> EndSymbol
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LIST :
                //<statement_list> ::= <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LIST2 :
                //<statement_list> ::= <statement> <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<statement> ::= <assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<statement> ::= <if_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<statement> ::= <for_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<statement> ::= <function_definition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<statement> ::= <function_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECL :
                //<decl> ::= <datatype> <identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECL2 :
                //<decl> ::= <datatype> <assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_EQ_SEMI :
                //<assignment> ::= <identifier> '=' <expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDENTIFIER_ID :
                //<identifier> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PLUS :
                //<expression> ::= <term_expression> '+' <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUS :
                //<expression> ::= <term_expression> '-' <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<expression> ::= <term_expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_EXPRESSION_TIMES :
                //<term_expression> ::= <factor_expression> '*' <term_expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_EXPRESSION_DIV :
                //<term_expression> ::= <factor_expression> '/' <term_expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_EXPRESSION_PERCENT :
                //<term_expression> ::= <factor_expression> '%' <term_expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_EXPRESSION :
                //<term_expression> ::= <factor_expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_EXPRESSION_APOST :
                //<factor_expression> ::= <parenthesized_expression> '' <factor_expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_EXPRESSION :
                //<factor_expression> ::= <parenthesized_expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARENTHESIZED_EXPRESSION_LPAREN_RPAREN :
                //<parenthesized_expression> ::= '(' <expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARENTHESIZED_EXPRESSION :
                //<parenthesized_expression> ::= <identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARENTHESIZED_EXPRESSION2 :
                //<parenthesized_expression> ::= <numeric_digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUMERIC_DIGIT_DIGIT :
                //<numeric_digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<if_statement> ::= if '(' <condition> ')' '{' <statement_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<if_statement> ::= if '(' <condition> ')' '{' <statement_list> '}' else '{' <statement_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_IF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<if_statement> ::= if '(' <condition> ')' '{' <statement_list> '}' else if '(' <condition> ')' '{' <statement_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<if_statement> ::= if '(' <condition> ')' '{' <statement_list> '}' else if '(' <condition> ')' '{' <statement_list> '}' else '{' <statement_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<condition> ::= <expression> <operator> <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPERATOR_EXCLAMEQ :
                //<operator> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPERATOR_EQEQ :
                //<operator> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPERATOR_LT :
                //<operator> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPERATOR_GT :
                //<operator> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<for_statement> ::= For '(' <datatype> <assignment> ';' <condition> ';' <increment_decrement> ')' '{' <statement_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_INT :
                //<datatype> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_FLOAT :
                //<datatype> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_DOUBLE :
                //<datatype> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_STRING :
                //<datatype> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCREMENT_DECREMENT_MINUSMINUS :
                //<increment_decrement> ::= '--' <identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCREMENT_DECREMENT_PLUSPLUS :
                //<increment_decrement> ::= '++' <identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCREMENT_DECREMENT_MINUSMINUS2 :
                //<increment_decrement> ::= <identifier> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCREMENT_DECREMENT_PLUSPLUS2 :
                //<increment_decrement> ::= <identifier> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCREMENT_DECREMENT :
                //<increment_decrement> ::= <assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_DEFINITION_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE :
                //<function_definition> ::= Function <identifier> '(' <parameters> ')' '{' <statement_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS :
                //<parameters> ::= <parameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_COMMA :
                //<parameters> ::= <parameter> ',' <parameters>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER :
                //<parameter> ::= <identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CALL_CALL_LPAREN_RPAREN_SEMI :
                //<function_call> ::= Call <identifier> '(' <arguments> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS :
                //<arguments> ::= <argument>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS_COMMA :
                //<arguments> ::= <argument> ',' <arguments>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT :
                //<argument> ::= <expression>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
