# VonNeumann_NET_Maui_Simulator
Application developed in C# .NET Maui wich implements a simple Von Neumann architecture simulator.
## Description
John von Neumann defined a first design of computer architectures. It has some complexity but is perfect for introducing to the knowledge of modern computers.
There is a lot of information about this computer and multiple simulators to understand how it works. However, the objective of this small project is
develop a simulator with .NET Maui wich works for multiple platforms (Windows, Android, IOs...) and of course, have fun!

## Diagram
<p align="center">
  <img src="../main/Diagram.png">
</p>

## Von Nuemann Computer 
It is the core of the project. It is made up of the CPU, ALU and Memory.
First of all, the program that has to be executed is read. When the CPU instance is created, it generates memory of the size necessary to store all instructions.
The memory is made up of 8-bit cells.
CPU is the responsible for reading the instructions in memory, decoding them, determining what type of operation must be performed and ordering the ALU to execute said operation.
It is also responsible for updating the different typical registers in this architecture: Accumulator, Program Counter or Instruction Register.
<p align="center">
  <img src="../main/VonNeumann.png">
</p>

## Console Application
This is a small console application that is used to quickly execute a program on the Von Neumann computer.
<p align="center">
  <img src="../main/Console.png">
</p>

## .NET Maui Application
Similar to console, this application offers a rich user interface where you can select a file with the instructions to execute and run the program automatically (1 instruction/sec) or step by step.
The information contained in the memory and in the registers is updated in real time. The content is displayed in binary, decimal and hexadecimal formats.
Using the same source code, .NET Maui allows you to generate the application for multiple platforms: Windows, Android, iOS...
<p align="center">
  <img src="../main/NETMaui.png">
</p>

## Unit Testing Layer
There is not much to comment, it is a set of Unit Tests to guarantee the integrity and quality of the software.
The framework used is MSTests.
<p align="center">
  <img src="../main/UnitTest.png">
</p>

## Sample
A file "Instructions.txt" has been added that contains the following program:
00000100 //ADD:  ACC = ACC + MEM[4]  --> ACC  = 7
00010101 //SUB:  ACC = ACC - MEM[5]  --> ACC  = 6
01100111 //MEM:  MEM[7] = ACC        --> MEM[7] = 6
01110000 //HALT: Stop the program
00000111
00000001
00000000
00000000




