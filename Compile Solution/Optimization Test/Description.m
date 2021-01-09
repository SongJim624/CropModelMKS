function Description(path)
%DESCRIPTION �˴���ʾ�йش˺�����ժҪ
%   �˴���ʾ��ϸ˵��
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

