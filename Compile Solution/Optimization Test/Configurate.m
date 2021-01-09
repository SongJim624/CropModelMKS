function Configurate(path)
global configuration;

doc = xmlread(path);
parameters = doc.getElementsByTagName('Parameters').item(0).getElementsByTagName('Parameter');

configuration.water_price = str2double(...
    parameters.item(0).getElementsByTagName('value').item(0).getTextContent());

configuration.food_price = str2double(...
    parameters.item(1).getElementsByTagName('value').item(0).getTextContent());

inputs = doc.getElementsByTagName('Inputs').item(0);
parameters = inputs.getElementsByTagName("Parameter");

configuration.date.ProgID = parameters.item(0).getAttribute("ProgID");
configuration.date.index = str2double(parameters.item(0).getAttribute("index"));

configuration.ub = str2num(parameters.item(0).getElementsByTagName("upper").item(0).getTextContent());
configuration.lb = str2num(parameters.item(0).getElementsByTagName("lower").item(0).getTextContent());

configuration.IntCon = 1 : length(configuration.ub);

configuration.amount.ProgID = parameters.item(1).getAttribute("ProgID");
configuration.amount.index = str2double(parameters.item(1).getAttribute("index"));

configuration.ub = [configuration.ub, ...
    str2num(parameters.item(0).getElementsByTagName("upper").item(0).getTextContent())];

configuration.lb = [configuration.lb, ...
    str2num(parameters.item(0).getElementsByTagName("lower").item(0).getTextContent())];

end

