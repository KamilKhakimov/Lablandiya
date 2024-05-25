Разработчик Хакимов Камиль, группа АВТ-114
Программа: Компилятор, реализующий грамматику приведенную ниже.


Для грамматики G[begin-stmt] разработать и реализовать алгоритм
анализа на основе метода рекурсивного спуска.
G[begin-stmt]:
1. begin-stmt → begin stmt-list end
2. stmt-list → stmt | stmt ; stmt-list
3. stmt → if-stmt | while-stmt | begin-stmt | assg-stmt
4. if-stmt → if bool-expr then stmt else stmt
5. while-stmt → while bool-expr do stmt
6. assg-stmt → VAR := arith-expr
7. bool-expr → arith-expr compare-op arith-expr
8. arith-expr → VAR | NUM | ( arith-expr ) | arith-expr + arith-expr |
arith-expr * arith-expr
VAR – переменная Б{Б|Ц}, Б – {a, b, c, ...z, A, B, …, Z}, NUM – {0, 1,
…, 9}, compare-op – ”==” | ”<” | ”<=” | ”>” | ”>=” | ”!=”
