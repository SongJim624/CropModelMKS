function cost = Cost(x, simulator)
global configuration;

simulator.Change(string(configuration.date.ProgID), configuration.date.index,...
    "irrigation date", x(1 : length(x) / 2));

simulator.Change(string(configuration.amount.ProgID), configuration.amount.index,...
    "irrigation amount", x(length(x) / 2 : end));

simulator.Simulate();

yield = simulator.Inquire("yield", 0);
amount = simulator.Inquire("accumulated irrigation amount", 0);
cost = amount * configuration.water_price -...
    yield * configuration.food_price;

end