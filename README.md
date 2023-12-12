# VonNeumann_NET_Maui_Simulator
Application developed in C# .NET Maui wich implements a simple Von Neumann architecture simulator.
## Description
John Von Neumann defined a first design of computer architectures. It has some complexity but is perfect for introducing to the knowledge of modern computers.<br>
There is a lot of information about this computer and multiple simulators to understand how it works. However, the objective of this small project is
develop a simulator with .NET Maui wich works for multiple platforms (Windows, Android, IOs...) and of course, have fun!

## Diagram
<p align="center">
  <img src="../main/Diagram.png">
</p>
The logic of the architecture is completely decoupled. This allows different types of applications to be developed using the same core.

## Von Neumann Computer 
The core of the project. It is made up of the CPU, ALU and Memory.<br>
First of all, the program that has to be executed is read. When the CPU instance is created, it generates memory of the size necessary to store all instructions.
The memory is made up of 8-bit cells.<br>
CPU is the responsible for reading the instructions in memory, decoding them, determining what type of operation must be performed and ordering the ALU to execute said operation.<br>
It is also responsible for updating the different typical registers in this architecture: Accumulator, Program Counter or Instruction Register.
<p align="center">
  <img src="../main/Neumann.png">
</p>

## Console Application
This is a small console application that is used to quickly execute a program on the Von Neumann computer.

## .NET Maui Application
Similar to console, this application offers a rich user interface where you can select a file with the instructions to execute and run the program automatically (1 instruction/sec) or step by step.<br>
The information contained in the memory and in the registers is updated in real time. The content is displayed in binary, decimal and hexadecimal formats.<br>
Using the same source code, .NET Maui allows you to generate the application for multiple platforms: Windows, Android, iOS...<br>
According .NET Maui best practices, this component is developed under the MVVM pattern. It contains some items specific to this methodology, for example: converters, databindings, viewmodels or template selectors.<br>
<p align="center">
  <img src="../main/NeumannMaui.png">
</p>

## Unit Testing Layer
There is not much to comment, it is a set of Unit Tests to guarantee the integrity and quality of the software.<br>
The framework used is MSTests.

## Sample
A file "Instructions.txt" has been added that contains the following program:
00000100 //ADD:  ACC = ACC + MEM[4]  --> ACC  = 7<br>
00010101 //SUB:  ACC = ACC - MEM[5]  --> ACC  = 6<br>
01100111 //MEM:  MEM[7] = ACC        --> MEM[7] = 6<br>
01110000 //HALT: Stop the program<br>
00000111<br>
00000001<br>
00000000<br>
00000000<br>

1. Read the memory postion [4] and save it in the Accumulator register. 
2. Content of memory position five is subtracted. The result is stored in the Accumulator register again.
3. The content of the Accumulator is stored in memory position [7].
4. Program stops.


