function solve(arr) {
    let pattern = /^(www).([a-zA-Z0-9-]+)(.[a-zA-Z]+)+$/g;
    for(let e of arr) {
        for(let x of e.split(' ')) {
            if (x.match(pattern)) {
                console.log(x);
            }
        }
    }
}


solve(['Join WebStars now for free, at www.web-stars.com',
'You can also support our partners:',
'Internet - www.internet.com',
'WebSpiders - www.webspiders101.com',
entinel - www.sentinel.-ko ']);

solve(['Need information about cheap hotels in London?',
'You can check us at www.london-hotels.co.uk!',
'We provide the best services in London.',
'Here are some reviews in some blogs:',
'"London Hotels are awesome!" - www.indigo.bloggers.com',
'"I am very satisfied with their services" - ww.ivan.bg',
'"Best Hotel Services!" - www.rebel21.sedecrem.moc ']);