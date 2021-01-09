asmInfo = NET.addAssembly("C:\Users\Song Jim\Desktop\CropModelMKS\Platform\Core.dll");
simulator = CropModelMKS.Simulator();
%simulator.Configurate("C:\Users\Song Jim\Desktop\CropModelMKS\Platform\Projects\Two True\project.XML");
path = "C:\Users\Song Jim\Documents\CropModelMKS\Projects\Simulation\Test for the Analysis.XML";
config = "C:\Users\Song Jim\Documents\CropModelMKS\Projects\Analysis\Test For Analysis.XML" ;
Configurate(config);
simulator.Configurate(path);
fun = @(x) Cost(x, simulator);

nvars = 6;
A =[];
b =[];
ub = [30; 60; 90; 50; 50; 50];
lb = [ 1; 31; 61; 10; 10; 10];
nonlcon = [];
IntCon = [1,2,3];
options = optimoptions('ga','PlotFcn', @gaplotbestf);
%options = optimoptions('ga');
x = ga(fun,nvars,A,b,[],[],lb,ub,nonlcon,IntCon,options);

