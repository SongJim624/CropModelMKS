function Description(path)
%DESCRIPTION 此处显示有关此函数的摘要
%   此处显示详细说明
doc = com.mathworks.xml.XMLUtils.createDocument('Description');
root = doc.getDocumentElement();

parameters = doc.createElement('Parameters');
root.appendChild(parameters);

item = doc.createElement("item");
item.setAttribute("type", "double");
item.setAttribute("size", "single");
item.setAttribute("name", "water price");
parameters.appendChild(item);

item = doc.createElement("item");
item.setAttribute("type", "double");
item.setAttribute("size", "single");
item.setAttribute("name", "food price");
parameters.appendChild(item);

xmlwrite(path ,doc);
end

