Разработчик Хакимов Камиль, группа АВТ-114
Программа: Интерфейс Компилятора, с реализованными некими функциями. 

![Диграмма] (./Lablandiya/Картинки/Диаграмма.png)


Создание функции языка JavaScript

function (number, num) {
  		return number * num;
};
function (number) {
  		return number * 4;
};
function () {
  		return 4;
};
 function (number, num) {
  		return number * 4 – 15 / num + 18;
};      

G[<function>]; P:
1.	<function> -> ‘function’ <OPEN>
2.	<OPEN> -> ‘(’ <ARGUMENTS>
3.	<ARGS> -> |{|} CLOSE | ‘<ARGS>’
4.	CLOSE -> ‘)’ OPENFUNC
5.	OPENFUNC -> ‘{‘ RETURN
6.	RETURN -> ‘return’ ARITHEXPR ‘;’  CLOSEFUNC
7.	ARTTHEXPR -> TA
8.	A -> E | +TA | -TA
9.	T -> OB
10.	 B -> E |*OB| / OB
11.	 O -> num |id| ‘(’ <ARITHEXPR> ‘)’ 
12.	 ‘CLOSEFUNC’ -> ‘}’ END
13.	 END -> ‘;’

![тест1] (Картинки/тест-1.png)
![тест2] (Картинки/тест-3.png)
![тест3] (Картинки/тест-4.png)

