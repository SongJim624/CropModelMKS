function  Analyze(simulator)
global configuration;

fun = @(x) Cost(x, simulator);

nvars = 6;
A =[];
b =[];
ub = [30; 60; 90; 50; 50; 50];
lb = [ 1; 31; 61; 10; 10; 10];
nonlcon = [];
IntCon = [1,2,3];
options = optimoptions('ga','PlotFcn', @gaplotbestf);
x = ga(fun,nvars, A, b, [], [], configuration.lb, configuration.ub, ...
    nonlcon, configuration.IntCon, options);
save Result.txt x -ascii;

end

