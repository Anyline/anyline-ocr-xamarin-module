(window.webpackJsonp=window.webpackJsonp||[]).push([[0],{167:function(t,e,n){t.exports=n(389)},31:function(t,e,n){"use strict";function o(){return parseInt(window.innerWidth*window.devicePixelRatio,10)}function i(){return parseInt(window.innerHeight*window.devicePixelRatio,10)}n.d(e,"b",function(){return o}),n.d(e,"a",function(){return i})},383:function(t,e,n){},387:function(t,e,n){},389:function(t,e,n){"use strict";n.r(e);n(168);var o,i=n(1),r=n.n(i),a=n(62),c=n.n(a),u=n(35),s=n(12),d=n(21),l=n(49),f=n.n(l),b=n(155),h=n.n(b),p=n(6),v=n(158),m=n.n(v),g=n(50),k=n(415);var w=function(){if(o)return o;var t={},e=function(e,n){return t[e]?t[e].next(n):(console.warn("".concat(e," does not have any registered listeners. Publish cancelled.")),!1)};return o={getSinks:function(){return t},publish:e,subscribe:function(e,n){return n?(t[e]||Object.assign(t,Object(g.a)({},e,new k.a)),t[e].subscribe(n)):(console.warn("No callback provided for subscription. Subscription cancelled."),!1)}},console.log("assigning publish"),window.publish=e,o}(),O=function(t,e){return t.reduce(function(t,n){return Object(s.a)({},t,Object(g.a)({},n[e],n))},{})},C=n(154),j=n(159),E=n.n(j);var y=n(51),F=n(160),S=n.n(F);function A(t,e,n,o,i,r){o<2*r&&(r=o/2),i<2*r&&(r=i/2),t.beginPath(),t.moveTo(e+r,n),t.arcTo(e+o,n,e+o,n+i,r),t.arcTo(e+o,n+i,e,n+i,r),t.arcTo(e,n+i,e,n,r),t.arcTo(e,n,e+o,n,r),t.closePath()}var x=u.b.svg.withConfig({displayName:"SvgCutout__CutoutSVG",componentId:"fw8wq9-0"})([""]),I=u.b.path.withConfig({displayName:"SvgCutout__BackgroundCutoutStroke",componentId:"fw8wq9-1"})(["   fill:",";stroke:",";stroke-width:",";"],function(t){return t.fill||"none"},function(t){return Object(y.a)(t.strokeColor)},function(t){return t.strokeWidth}),R=Object(u.b)(I).withConfig({displayName:"SvgCutout__AnimatedCutoutStroke",componentId:"fw8wq9-2"})([""," stroke:",";"],function(t){return t.animate&&t.delay&&Object(u.a)(["animation:dash ","s linear;animation-fill-mode:forwards;@keyframes dash{to{stroke-dashoffset:0;}}"],t.delay)},function(t){return t.scanning&&!t.isAnimating?Object(y.a)(t.feedbackStrokeColor||t.strokeColor):Object(y.a)(t.strokeColor)}),W=function(t){var e=t.onAnimationStateChanged,n=void 0===e?function(){}:e,o=t.animate,a=t.rect,c=t.cornerRadius,u=t.fill,s=t.strokeWidth,l=t.inactiveStrokeColor,f=t.feedbackStrokeColor,b=t.strokeColor,h=t.scanning,p=t.delay,v=t.children,m=Object(i.useRef)(),g=Object(i.useState)(),k=Object(d.a)(g,2),w=k[0],O=k[1],C=Object(i.useState)(!!l),j=Object(d.a)(C,2),E=j[0],y=j[1];Object(i.useEffect)(function(){var t=m.current;if(t&&t.getTotalLength)return t.addEventListener("webkitAnimationEnd",o,!1),t.addEventListener("animationend",o,!1),t.addEventListener("oanimationend",o,!1),t.addEventListener("webkitAnimationStart",e,!1),t.addEventListener("animationstart",e,!1),t.addEventListener("oanimationstart",e,!1),function(){t.removeEventListener("webkitAnimationEnd",o,!1),t.removeEventListener("animationend",o,!1),t.removeEventListener("oanimationend",o,!1),t.removeEventListener("webkitAnimationStart",e,!1),t.removeEventListener("animationstart",e,!1),t.removeEventListener("oanimationstart",e,!1)};function e(){O(!0),n(!0)}function o(){O(!1),y(!1),n(!1)}},[m.current]);var F=a.right-a.left+s,W=a.bottom-a.top+s,M=function(t){var e=t.rect,n=t.width,o=t.height,i=t.cornerRadius,r=void 0===i?0:i,a=t.strokeWidth,c=void 0===a?0:a,u=new S.a(n,o);r<c&&(r=c);var s=e.top,d=e.left;return A(u,1.5*c-c,1.5*c-c,e.right-d-c+2*c,e.bottom-s-c+2*c,r),u.closePath(),u.stroke(),u.getSvg().childNodes[1].childNodes[0].getAttribute("d")}({rect:a,cornerRadius:c,strokeWidth:s,width:F+s,height:W+s});return r.a.createElement("div",{style:{position:"fixed",width:F+s,height:W+s,left:a.left-s,top:a.top-s}},r.a.createElement(x,{width:F+s,height:W+s,version:"2.0"},E&&r.a.createElement(I,{d:M,fill:u,rect:a,strokeColor:l,strokeWidth:s,cornerRadius:c}),r.a.createElement(R,{d:M,isAnimating:w,animate:o,strokeDasharray:2*F+2*W,strokeDashoffset:l?2*F+2*W:0,scanning:h,feedbackStrokeColor:f,ref:m,rect:a,strokeColor:b,strokeWidth:s,cornerRadius:c,delay:p})),v)},M=r.a.lazy(function(){return Promise.all([n.e(3),n.e(1)]).then(n.bind(null,416))}),L=function(){var t;return function(e,n){clearTimeout(t),t=setTimeout(n,e)}}(),D=function(t){var e=t.scanFeedbackConfig,n=t.inactiveStrokeColor;return Object(s.a)({},e,{strokeColor:n,fillColor:"00000000"})},T=function(t,e,n){return{width:t.right-t.left,height:t.bottom-t.top,top:-e,left:-e,borderRadius:n}},_=function(){return{fade:500,zoom:500}[(arguments.length>0&&void 0!==arguments[0]?arguments[0]:"").toLowerCase()]||0};function z(t,e){if(t){var n=t-_(e)/1e3;return n>=0?n:0}}var P,N,U,q,B,H,G=Object(p.a)(Object(p.g)("show","setShow"),Object(p.g)("scanning","setScanning"),Object(p.g)("isAnimating","setIsAnimating"),Object(p.g)("isDelayAnimating","setIsDelayAnimating"),Object(p.b)({rect:{left:0,top:0,right:100,bottom:100},strokeWidth:2,strokeColor:"FFFFFF",cornerRadius:8,onEnter:function(){},onEntered:function(){},onExit:function(){},onExited:function(){}}),Object(p.e)({handleEnter:function(t){var e=t.setIsAnimating,n=t.onEnter;return function(){e(!0),n()}},handleEntered:function(t){var e=t.setIsAnimating,n=t.onEntered;return function(){e(!1),n()}},handleExit:function(t){var e=t.setIsAnimating,n=t.onExit;return function(){e(!0),n()}},handleExited:function(t){var e=t.setIsAnimating,n=t.onExited;return function(){e(!1),n()}},resetScanTimeout:function(t){var e=t.setScanning,n=t.scanFeedback;return function(){e(!0),L(n.timeout||1e3,function(){return e(!1)})}}}),Object(p.f)(function(t){var e=t.scanFeedback,n=t.delay,o=t.classNames,i=t.rect,r=t.strokeWidth,a=t.cornerRadius,c=t.isAnimating,u=t.inactiveStrokeColor;return{enterAnimationTimeout:_(o),animateDelay:u,renderFeedback:!c&&e.elements&&!!e.elements.length,delay:z(n,o),initialRectStyle:T(i,r,a),polygonOffset:{top:i.top,left:i.left}}}),Object(p.f)(function(t){var e=t.scanFeedback,n=t.inactiveStrokeColor;return{scanFeedbackConfig:t.isDelayAnimating?D({scanFeedbackConfig:e,inactiveStrokeColor:n}):e}}),Object(p.c)({componentDidMount:function(){this.props.setShow(!0)},componentWillReceiveProps:function(t){t.scanFeedback.lastFeedbackUpdate!==this.props.scanFeedback.lastFeedbackUpdate&&this.props.resetScanTimeout()}}))(function(t){t.show;var e=t.setIsDelayAnimating,n=t.renderFeedback,o=t.scanFeedbackConfig,a=t.handleEntered,c=t.handleEnter,u=t.handleExit,s=t.handleExited,d=t.initialRectStyle,l=t.polygonOffset,f=t.animateDelay,b=t.enterAnimationTimeout,h=Object(C.a)(t,["show","setIsDelayAnimating","renderFeedback","scanFeedbackConfig","handleEntered","handleEnter","handleExit","handleExited","initialRectStyle","polygonOffset","animateDelay","enterAnimationTimeout"]);return r.a.createElement(E.a,Object.assign({timeout:b},h,{onEntered:a,onEnter:c,onExit:u,onExited:s}),r.a.createElement(W,{onAnimationStateChanged:e,animate:f,rect:h.rect,inactiveStrokeColor:h.inactiveStrokeColor,cornerRadius:h.cornerRadius,delay:h.delay,strokeWidth:h.strokeWidth,feedbackStrokeColor:h.feedbackStrokeColor,strokeColor:h.strokeColor,scanning:h.scanning},n&&r.a.createElement(i.Suspense,{fallback:r.a.createElement("span",null)},r.a.createElement(M,{initialRectStyle:d,hide:!h.scanning,cutoutId:h.id,polygonOffset:l,config:o}))))}),J=n(163),V=n(164),Y=function(){function t(){Object(J.a)(this,t)}return Object(V.a)(t,[{key:"set",value:function(t,e){this[t]=e}}]),t}(),Z=Object(p.f)({refs:new Y}),$=function(t,e){return Object.keys(e).filter(function(e){return!Object.keys(t).includes(e)})},K=u.b.canvas.withConfig({displayName:"Mask__Canvas",componentId:"sc-5i53g0-0"})(["position:absolute;width:100%;height:100%;"]),Q=function(t){return function(e){return t.set("canvas",e)}},X=Object(p.a)(Z,Object(p.b)({outerColor:"FFFFFF",outerAlpha:0,onInit:function(){}}),Object(p.e)({initializeMaskService:function(t){var e=t.outerColor,n=t.outerAlpha,o=t.refs.canvas;return function(){o.width=window.innerWidth,o.height=window.innerHeight,P=function(t){var e=t.canvasEl,n=t.outerColor,o=void 0===n?"000000":n,i=t.outerAlpha,r=void 0===i?0:i,a=t.rerenderOnAdd,c=void 0===a||a,u=t.rerenderOnRemove,s=void 0===u||u,d={},l=Object(y.b)(o,r),f=e.getContext("2d");function b(t){var e=t.rect,n=t.cornerRadius,o=void 0===n?0:n,i=t.strokeWidth,r=void 0===i?0:i;o<r&&(o=r);var a=e.top,c=e.left,u=e.right,s=e.bottom;A(f,c-r,a-r,u-c+2*r,s-a+2*r,1.5*o),f.fillStyle="black",f.fill()}function h(t){f.fillStyle=t,f.fillRect(0,0,e.width,e.height)}function p(){f.clearRect(0,0,e.width,e.height),f.globalCompositeOperation="source-over",h(l),f.globalCompositeOperation="destination-out",Object.values(d).forEach(b)}return h(l),function t(){return requestAnimationFrame(t)}(),{addCutout:function(t){d[t.id]=t,c&&p()},modifyCutout:function(t){d[t.id]=t,p()},removeCutout:function(t){delete d[t],s&&p()},render:p,setConfig:function(t,e){l=Object(y.b)(t,e),p()}}}({canvasEl:o,outerColor:e,outerAlpha:n,rerenderOnAdd:!1})}},updateCanvasDimensions:function(t){var e=t.refs.canvas;return function(){e.width=e.offsetWidth,e.height=e.offsetHeight,P&&P.render()}}}),Object(p.c)({componentDidMount:function(){this.props.initializeMaskService(),window.addEventListener("resize",this.props.updateCanvasDimensions),this.props.onInit(P)},componentWillUnmount:function(){window.removeEventListener("resize",this.props.updateCanvasDimensions)},componentWillReceiveProps:function(t){var e=this;return t.outerColor===this.props.outerColor&&t.outerAlpha===this.props.outerAlpha||P&&P.setConfig(t.outerColor,t.outerAlpha),$(this.props.cutouts,t.cutouts).length?(P||t.initializeMaskService(),void Object.values(t.cutouts).filter(function(t){return!e.props.cutouts[t.id]}).forEach(P.addCutout)):$(t.cutouts,this.props.cutouts).length?(P||t.initializeMaskService(),void Object.values(this.props.cutouts).filter(function(e){return!t.cutouts[e.id]}).map(function(t){return t.id}).forEach(P.removeCutout)):void Object.values(t.cutouts).filter(function(t){return e.props.cutouts[t.id]&&t.lastUpdate!==e.props.cutouts[t.id].lastUpdate}).forEach(P.modifyCutout)}}))(function(t){var e=t.refs;return r.a.createElement(K,{ref:Q(e)})}),tt=(n(383),5),et={cutouts:f.a.object.isRequired},nt=function(){return(arguments.length>0&&void 0!==arguments[0]?arguments[0]:[]).filter(function(t){return Object.keys(t).length})};function ot(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:[],e=arguments.length>1&&void 0!==arguments[1]?arguments[1]:[];if(!e.length||t.length>1||!t[0].points)return t;if(1===t.length&&1===e.length){var n=it(e[0].points,{left:0,top:0}),o=it(t[0].points,{left:0,top:0}),i=n.x,r=n.y,a=n.width,c=n.height,u=o.x,s=o.y,d=o.width,l=o.height;if(Math.abs(i-u)>=tt||Math.abs(r-s)>=tt||Math.abs(a-d)>=tt||Math.abs(c-l)>=tt)return t}return e}function it(t,e){if(!t)return{};var n=t.reduce(function(t,e){var n=Object(d.a)(e,2),o=n[0],i=n[1];return{x1:t.x1&&t.x1<o?t.x1:o,y1:t.y1&&t.y1<i?t.y1:i,x2:t.x2&&t.x2>o?t.x2:o,y2:t.y2&&t.y2>i?t.y2:i}},{});return{x:n.x1-e.left,y:n.y1-e.top,width:n.x2-n.x1,height:n.y2-n.y1}}var rt=function(t){return t.visible},at=function(t,e){return e.map(function(e){return Object(s.a)({},e,{svgOffset:{top:t.useSvgOffset?-t.rect.top:0,left:t.useSvgOffset?-t.rect.left:0}})})},ct=function(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:function(t){return t};return Object(p.a)(Object(p.g)("maskConfig","setMaskConfig"),Object(p.g)("cutouts","setCutouts",{}),Object(p.e)({handleAnimatonEnterStart:function(t){return t.cutouts,function(t){return function(){t.animation&&"none"!==t.animation.toLowerCase()||H.render()}}},handleAnimatonEnterEnd:function(){return function(t){return function(){H.render()}}},handleAnimatonExitEnd:function(){return function(t){return function(){}}},handleMaskInit:function(){return function(t){H=t}},setupCutouts:function(t){var e=t.setCutouts,n=t.cutouts;return function(t){var o=t.map(function(t){return Object(s.a)({},n[t.id]||{},t,{scanFeedback:Object(s.a)({},n[t.id]&&n[t.id].scanFeedback||{},t.scanFeedback||{},{elements:[]}),lastUpdate:Date.now(),visible:"undefined"!==typeof t.visible?t.visible:!!n[t.id]&&n[t.id].visible})}),i=O(o,"id");e(function(t){return Object(s.a)({},t,i)})}},updateFeedback:function(t){var e=t.setCutouts,n=t.cutouts;return function(t){var o=Object.entries(t).filter(function(t){var e=Object(d.a)(t,2),o=e[0],i=e[1];return n[o]&&i.length}).map(function(t){var e=Object(d.a)(t,2),o=e[0],i=e[1];return Object(s.a)({},n[o],{scanFeedback:Object(s.a)({},n[o].scanFeedback,{lastFeedbackUpdate:Date.now(),elements:at(n[o],ot(nt(i),nt(n[o].scanFeedback.elements)))})})}),i=O(o,"id");e(function(t){return Object(s.a)({},t,i)})}},removeCutouts:function(t){var e=t.setCutouts,n=t.cutouts;return function(t){var o=function(t,e){var n=e.map(function(t){return t.toString()});return Object.entries(t).reduce(function(t,e){var o=Object(d.a)(e,2),i=o[0],r=o[1];return n.includes(i)?t:Object(s.a)({},t,Object(g.a)({},i,r))},{})}(n,t);e(o)}}}),t,Object(p.f)(function(t){var e=t.cutouts,n=Object.values(e).filter(rt);return{cutouts:O(n,"id")}}),Object(p.c)({componentDidMount:function(){window.setMaskConfig=this.props.setMaskConfig,B=w.subscribe("setupMask",this.props.setMaskConfig),window.setupCutouts=this.props.setupCutouts,N=w.subscribe("setupCutouts",this.props.setupCutouts),window.updateFeedback=this.props.updateFeedback,q=w.subscribe("updateFeedback",h()(this.props.updateFeedback,25)),window.removeCutouts=this.props.removeCutouts,U=w.subscribe("removeCutouts",this.props.removeCutouts)},componentWillUnmount:function(){B.unsubscribe(),N.unsubscribe(),U.unsubscribe(),q.unsubscribe()}}),Object(p.d)(et))}()(function(t){var e=t.cutouts,n=t.maskConfig,o=t.handleMaskInit,a=t.handleAnimatonEnterEnd,c=t.handleAnimatonExitEnd,u=t.handleAnimatonEnterStart,s=Object(i.useContext)(ft);return r.a.createElement("div",{style:s},r.a.createElement(X,Object.assign({},n,{cutouts:e,onInit:o})),r.a.createElement(m.a,null,Object.values(e).map(function(t){return r.a.createElement(G,Object.assign({onEntered:a(t),onEnter:u(t),onExited:c(t),classNames:t.animation?t.animation.toLowerCase():"",key:"Cutout_".concat(t.id)},t))})))}),ut=n(31),st=n(165),dt=n.n(st),lt=function(){var t=Object(i.useState)(Object(ut.b)()),e=Object(d.a)(t,2),n=e[0],o=e[1],r=Object(i.useState)(Object(ut.a)()),a=Object(d.a)(r,2),c=a[0],u=a[1];return Object(i.useEffect)(function(){var t=dt()(function(){o(Object(ut.b)()),u(Object(ut.a)())},250);return window.addEventListener("resize",t),function(){window.removeEventListener("resize",t)}}),{width:n,height:c}},ft=r.a.createContext({width:Object(ut.b)(),height:Object(ut.a)()}),bt=u.b.div.withConfig({displayName:"App__Wrapper",componentId:"sc-1wz7824-0"})(["width:100%;height:100%;"]),ht=function(){var t=lt();return r.a.createElement(bt,null,r.a.createElement(ft.Provider,{value:t},r.a.createElement(ct,null)))};Boolean("localhost"===window.location.hostname||"[::1]"===window.location.hostname||window.location.hostname.match(/^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/));var pt=n(66),vt=n.n(pt),mt=n(166),gt=n(65),kt=function(t){return new Promise(function(e){return setTimeout(e,t)})};function wt(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:[],e=Object(gt.a)(t);return{getFeedbacks:function(){return e},set:function(t){return e=Object(gt.a)(t)},add:function(t){return e=[].concat(Object(gt.a)(e),[t])}}}function Ot(){return(Ot=Object(mt.a)(vt.a.mark(function t(){var e,n,o,i,r,a,c,u,d,l,f,b=arguments;return vt.a.wrap(function(t){for(;;)switch(t.prev=t.next){case 0:e=b.length>0&&void 0!==b[0]?b[0]:{},n=e.setupCutoutsConfig,o=void 0===n?{}:n,i=e.feedbackCount,r=void 0===i?8:i,window.publish("setupMask",{outerColor:"000000",outerAlpha:.3}),window.publish("setupCutouts",[Object(s.a)({scanFeedback:{animation:"RESIZE",redrawTimeout:0,fillColor:"220099FF",strokeWidth:2,strokeColor:"FF0099FF",cornerRadius:4,feedbackStyle:"contour_point",animationDuration:1e3},feedbackStrokeColor:"FF0099FF",id:"1",visible:1,animation:"none",rect:{bottom:210,top:110,left:150,right:250},strokeWidth:2,cornerRadius:20,strokeColor:"FFFFFFFF"},o)]),a=function(t,e){return Object(s.a)({},t,e)},c=function(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:0,e=arguments.length>1&&void 0!==arguments[1]?arguments[1]:100;return Math.floor(Math.random()*e)+t},u=Array.apply(void 0,Object(gt.a)(Array(r))).map(function(t,e){return{y:250,x:c(1,1200),width:14.351851267873542,height:20.833332485622833}}),d=wt(u),f=vt.a.mark(function t(){var e,n;return vt.a.wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return console.time("loop"),e=400-2*l,n=d.set(u.map(function(t){return a(t,{y:e})})),window.publish("updateFeedback",{1:n}),console.timeEnd("loop"),t.next=7,kt(30);case 7:case"end":return t.stop()}},t,this)}),l=0;case 9:if(!(l<=100)){t.next=14;break}return t.delegateYield(f(),"t0",11);case 11:l+=1,t.next=9;break;case 14:case"end":return t.stop()}},t,this)}))).apply(this,arguments)}window.runFeedbackBenchmark=function(){return Ot.apply(this,arguments)};n(387);var Ct=document.getElementById("root");document.body.style.height="".concat(Object(ut.a)(),"px"),c.a.render(r.a.createElement(ht,null),Ct),"serviceWorker"in navigator&&navigator.serviceWorker.ready.then(function(t){t.unregister()})},51:function(t,e,n){"use strict";function o(t){var e=arguments.length>1&&void 0!==arguments[1]?arguments[1]:0;t=t.replace("#","");var n=parseInt(t.slice(0,2),16),o=parseInt(t.slice(2,4),16),i=parseInt(t.slice(4,6),16);return"rgba(".concat(n,", ").concat(o,", ").concat(i,", ").concat(e,")")}function i(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"";if(t=t.replace("#",""),![6,8].includes(t.length))throw Error("invalid hey HexARGB string use length of 6 or 8");if(6===t.length){var e=parseInt(t.substring(0,2),16),n=parseInt(t.substring(2,4),16),o=parseInt(t.substring(4,6),16);return"rgb(".concat(e,", ").concat(n,", ").concat(o,")")}if(8===t.length){var i=parseInt(t.substring(0,2),16)/255,r=parseInt(t.substring(2,4),16),a=parseInt(t.substring(4,6),16),c=parseInt(t.substring(6,8),16);return"rgba(".concat(r,", ").concat(a,", ").concat(c,", ").concat(i,")")}}n.d(e,"b",function(){return o}),n.d(e,"a",function(){return i})}},[[167,4,2]]]);