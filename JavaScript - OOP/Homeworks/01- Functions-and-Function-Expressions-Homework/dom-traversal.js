function traversal(selector) {

    var nodeList = document.querySelectorAll(selector);

    for (var i = 0, length = nodeList.length; i < length; i++) {
        recursiveTraverse(nodeList[i]);
    }

    function recursiveTraverse(node) {
        var nodeId = node.hasAttribute('id') ? 'id="' + node.id + '" ' : '';
        var nodeClass = node.hasAttribute('class') ? 'class="' + node.className + '"' : '';
        console.log(node.nodeName.toLowerCase() + ": " + nodeId + nodeClass);

        if (node.hasChildNodes()) {
            for (var j = 0, len = node.childNodes.length; j < len; j++) {
                var child = node.childNodes[j];
                if (child.nodeType === 1 && child.nodeName != 'SCRIPT') {
                    recursiveTraverse(child);
                }
            }
        }

    }
}


traversal('.birds');