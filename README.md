# DDWRTBinReader
C# training code that reads bin file from DD-WRT and parse to .txt files.

This small project is just a personal practice on learning development in C#. After 15 years of Java coding, I need to stay "sharp" with other languages as well. ;-)

This code allows reading .bin files, generated by DD-WRT routers, versions v23 and v24. This .bin files is the backup generated
by the routers. However, sometimes the router for some reason cannot recognize the bin file properly even when created and loaded
from the very same version.

I hate when it happens, so I decided to create this flyweight tool to help me reading the file and setup the router manually.
