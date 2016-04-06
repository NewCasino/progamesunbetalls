;(function( window, undefined ){
/*
    json2.js
    2014-02-04

    Public Domain.

    NO WARRANTY EXPRESSED OR IMPLIED. USE AT YOUR OWN RISK.

    See http://www.JSON.org/js.html


    This code should be minified before deployment.
    See http://javascript.crockford.com/jsmin.html

    USE YOUR OWN COPY. IT IS EXTREMELY UNWISE TO LOAD CODE FROM SERVERS YOU DO
    NOT CONTROL.


    This file creates a global JSON object containing two methods: stringify
    and parse.

        JSON.stringify(value, replacer, space)
            value       any JavaScript value, usually an object or array.

            replacer    an optional parameter that determines how object
                        values are stringified for objects. It can be a
                        function or an array of strings.

            space       an optional parameter that specifies the indentation
                        of nested structures. If it is omitted, the text will
                        be packed without extra whitespace. If it is a number,
                        it will specify the number of spaces to indent at each
                        level. If it is a string (such as '\t' or '&nbsp;'),
                        it contains the characters used to indent at each level.

            This method produces a JSON text from a JavaScript value.

            When an object value is found, if the object contains a toJSON
            method, its toJSON method will be called and the result will be
            stringified. A toJSON method does not serialize: it returns the
            value represented by the name/value pair that should be serialized,
            or undefined if nothing should be serialized. The toJSON method
            will be passed the key associated with the value, and this will be
            bound to the value

            For example, this would serialize Dates as ISO strings.

                Date.prototype.toJSON = function (key) {
                    function f(n) {
                        // Format integers to have at least two digits.
                        return n < 10 ? '0' + n : n;
                    }

                    return this.getUTCFullYear()   + '-' +
                         f(this.getUTCMonth() + 1) + '-' +
                         f(this.getUTCDate())      + 'T' +
                         f(this.getUTCHours())     + ':' +
                         f(this.getUTCMinutes())   + ':' +
                         f(this.getUTCSeconds())   + 'Z';
                };

            You can provide an optional replacer method. It will be passed the
            key and value of each member, with this bound to the containing
            object. The value that is returned from your method will be
            serialized. If your method returns undefined, then the member will
            be excluded from the serialization.

            If the replacer parameter is an array of strings, then it will be
            used to select the members to be serialized. It filters the results
            such that only members with keys listed in the replacer array are
            stringified.

            Values that do not have JSON representations, such as undefined or
            functions, will not be serialized. Such values in objects will be
            dropped; in arrays they will be replaced with null. You can use
            a replacer function to replace those with JSON values.
            JSON.stringify(undefined) returns undefined.

            The optional space parameter produces a stringification of the
            value that is filled with line breaks and indentation to make it
            easier to read.

            If the space parameter is a non-empty string, then that string will
            be used for indentation. If the space parameter is a number, then
            the indentation will be that many spaces.

            Example:

            text = JSON.stringify(['e', {pluribus: 'unum'}]);
            // text is '["e",{"pluribus":"unum"}]'


            text = JSON.stringify(['e', {pluribus: 'unum'}], null, '\t');
            // text is '[\n\t"e",\n\t{\n\t\t"pluribus": "unum"\n\t}\n]'

            text = JSON.stringify([new Date()], function (key, value) {
                return this[key] instanceof Date ?
                    'Date(' + this[key] + ')' : value;
            });
            // text is '["Date(---current time---)"]'


        JSON.parse(text, reviver)
            This method parses a JSON text to produce an object or array.
            It can throw a SyntaxError exception.

            The optional reviver parameter is a function that can filter and
            transform the results. It receives each of the keys and values,
            and its return value is used instead of the original value.
            If it returns what it received, then the structure is not modified.
            If it returns undefined then the member is deleted.

            Example:

            // Parse the text. Values that look like ISO date strings will
            // be converted to Date objects.

            myData = JSON.parse(text, function (key, value) {
                var a;
                if (typeof value === 'string') {
                    a =
/^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*)?)Z$/.exec(value);
                    if (a) {
                        return new Date(Date.UTC(+a[1], +a[2] - 1, +a[3], +a[4],
                            +a[5], +a[6]));
                    }
                }
                return value;
            });

            myData = JSON.parse('["Date(09/09/2001)"]', function (key, value) {
                var d;
                if (typeof value === 'string' &&
                        value.slice(0, 5) === 'Date(' &&
                        value.slice(-1) === ')') {
                    d = new Date(value.slice(5, -1));
                    if (d) {
                        return d;
                    }
                }
                return value;
            });


    This is a reference implementation. You are free to copy, modify, or
    redistribute.
*/

/*jslint evil: true, regexp: true */

/*members "", "\b", "\t", "\n", "\f", "\r", "\"", JSON, "\\", apply,
    call, charCodeAt, getUTCDate, getUTCFullYear, getUTCHours,
    getUTCMinutes, getUTCMonth, getUTCSeconds, hasOwnProperty, join,
    lastIndex, length, parse, prototype, push, replace, slice, stringify,
    test, toJSON, toString, valueOf
*/


// Create a JSON object only if one does not already exist. We create the
// methods in a closure to avoid creating global variables.

if (typeof JSON !== 'object') {
    JSON = {};
}

(function () {
    'use strict';

    function f(n) {
        // Format integers to have at least two digits.
        return n < 10 ? '0' + n : n;
    }

    if (typeof Date.prototype.toJSON !== 'function') {

        Date.prototype.toJSON = function () {

            return isFinite(this.valueOf())
                ? this.getUTCFullYear()     + '-' +
                    f(this.getUTCMonth() + 1) + '-' +
                    f(this.getUTCDate())      + 'T' +
                    f(this.getUTCHours())     + ':' +
                    f(this.getUTCMinutes())   + ':' +
                    f(this.getUTCSeconds())   + 'Z'
                : null;
        };

        String.prototype.toJSON      =
            Number.prototype.toJSON  =
            Boolean.prototype.toJSON = function () {
                return this.valueOf();
            };
    }

    var cx,
        escapable,
        gap,
        indent,
        meta,
        rep;


    function quote(string) {

// If the string contains no control characters, no quote characters, and no
// backslash characters, then we can safely slap some quotes around it.
// Otherwise we must also replace the offending characters with safe escape
// sequences.

        escapable.lastIndex = 0;
        return escapable.test(string) ? '"' + string.replace(escapable, function (a) {
            var c = meta[a];
            return typeof c === 'string'
                ? c
                : '\\u' + ('0000' + a.charCodeAt(0).toString(16)).slice(-4);
        }) + '"' : '"' + string + '"';
    }


    function str(key, holder) {

// Produce a string from holder[key].

        var i,          // The loop counter.
            k,          // The member key.
            v,          // The member value.
            length,
            mind = gap,
            partial,
            value = holder[key];

// If the value has a toJSON method, call it to obtain a replacement value.

        if (value && typeof value === 'object' &&
                typeof value.toJSON === 'function') {
            value = value.toJSON(key);
        }

// If we were called with a replacer function, then call the replacer to
// obtain a replacement value.

        if (typeof rep === 'function') {
            value = rep.call(holder, key, value);
        }

// What happens next depends on the value's type.

        switch (typeof value) {
        case 'string':
            return quote(value);

        case 'number':

// JSON numbers must be finite. Encode non-finite numbers as null.

            return isFinite(value) ? String(value) : 'null';

        case 'boolean':
        case 'null':

// If the value is a boolean or null, convert it to a string. Note:
// typeof null does not produce 'null'. The case is included here in
// the remote chance that this gets fixed someday.

            return String(value);

// If the type is 'object', we might be dealing with an object or an array or
// null.

        case 'object':

// Due to a specification blunder in ECMAScript, typeof null is 'object',
// so watch out for that case.

            if (!value) {
                return 'null';
            }

// Make an array to hold the partial results of stringifying this object value.

            gap += indent;
            partial = [];

// Is the value an array?

            if (Object.prototype.toString.apply(value) === '[object Array]') {

// The value is an array. Stringify every element. Use null as a placeholder
// for non-JSON values.

                length = value.length;
                for (i = 0; i < length; i += 1) {
                    partial[i] = str(i, value) || 'null';
                }

// Join all of the elements together, separated with commas, and wrap them in
// brackets.

                v = partial.length === 0
                    ? '[]'
                    : gap
                    ? '[\n' + gap + partial.join(',\n' + gap) + '\n' + mind + ']'
                    : '[' + partial.join(',') + ']';
                gap = mind;
                return v;
            }

// If the replacer is an array, use it to select the members to be stringified.

            if (rep && typeof rep === 'object') {
                length = rep.length;
                for (i = 0; i < length; i += 1) {
                    if (typeof rep[i] === 'string') {
                        k = rep[i];
                        v = str(k, value);
                        if (v) {
                            partial.push(quote(k) + (gap ? ': ' : ':') + v);
                        }
                    }
                }
            } else {

// Otherwise, iterate through all of the keys in the object.

                for (k in value) {
                    if (Object.prototype.hasOwnProperty.call(value, k)) {
                        v = str(k, value);
                        if (v) {
                            partial.push(quote(k) + (gap ? ': ' : ':') + v);
                        }
                    }
                }
            }

// Join all of the member texts together, separated with commas,
// and wrap them in braces.

            v = partial.length === 0
                ? '{}'
                : gap
                ? '{\n' + gap + partial.join(',\n' + gap) + '\n' + mind + '}'
                : '{' + partial.join(',') + '}';
            gap = mind;
            return v;
        }
    }

// If the JSON object does not yet have a stringify method, give it one.

    if (typeof JSON.stringify !== 'function') {
        escapable = /[\\\"\x00-\x1f\x7f-\x9f\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g;
        meta = {    // table of character substitutions
            '\b': '\\b',
            '\t': '\\t',
            '\n': '\\n',
            '\f': '\\f',
            '\r': '\\r',
            '"' : '\\"',
            '\\': '\\\\'
        };
        JSON.stringify = function (value, replacer, space) {

// The stringify method takes a value and an optional replacer, and an optional
// space parameter, and returns a JSON text. The replacer can be a function
// that can replace values, or an array of strings that will select the keys.
// A default replacer method can be provided. Use of the space parameter can
// produce text that is more easily readable.

            var i;
            gap = '';
            indent = '';

// If the space parameter is a number, make an indent string containing that
// many spaces.

            if (typeof space === 'number') {
                for (i = 0; i < space; i += 1) {
                    indent += ' ';
                }

// If the space parameter is a string, it will be used as the indent string.

            } else if (typeof space === 'string') {
                indent = space;
            }

// If there is a replacer, it must be a function or an array.
// Otherwise, throw an error.

            rep = replacer;
            if (replacer && typeof replacer !== 'function' &&
                    (typeof replacer !== 'object' ||
                    typeof replacer.length !== 'number')) {
                throw new Error('JSON.stringify');
            }

// Make a fake root object containing our value under the key of ''.
// Return the result of stringifying the value.

            return str('', {'': value});
        };
    }


// If the JSON object does not yet have a parse method, give it one.

    if (typeof JSON.parse !== 'function') {
        cx = /[\u0000\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g;
        JSON.parse = function (text, reviver) {

// The parse method takes a text and an optional reviver function, and returns
// a JavaScript value if the text is a valid JSON text.

            var j;

            function walk(holder, key) {

// The walk method is used to recursively walk the resulting structure so
// that modifications can be made.

                var k, v, value = holder[key];
                if (value && typeof value === 'object') {
                    for (k in value) {
                        if (Object.prototype.hasOwnProperty.call(value, k)) {
                            v = walk(value, k);
                            if (v !== undefined) {
                                value[k] = v;
                            } else {
                                delete value[k];
                            }
                        }
                    }
                }
                return reviver.call(holder, key, value);
            }


// Parsing happens in four stages. In the first stage, we replace certain
// Unicode characters with escape sequences. JavaScript handles many characters
// incorrectly, either silently deleting them, or treating them as line endings.

            text = String(text);
            cx.lastIndex = 0;
            if (cx.test(text)) {
                text = text.replace(cx, function (a) {
                    return '\\u' +
                        ('0000' + a.charCodeAt(0).toString(16)).slice(-4);
                });
            }

// In the second stage, we run the text against regular expressions that look
// for non-JSON patterns. We are especially concerned with '()' and 'new'
// because they can cause invocation, and '=' because it can cause mutation.
// But just to be safe, we want to reject all unexpected forms.

// We split the second stage into 4 regexp operations in order to work around
// crippling inefficiencies in IE's and Safari's regexp engines. First we
// replace the JSON backslash pairs with '@' (a non-JSON character). Second, we
// replace all simple value tokens with ']' characters. Third, we delete all
// open brackets that follow a colon or comma or that begin the text. Finally,
// we look to see that the remaining characters are only whitespace or ']' or
// ',' or ':' or '{' or '}'. If that is so, then the text is safe for eval.

            if (/^[\],:{}\s]*$/
                    .test(text.replace(/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g, '@')
                        .replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']')
                        .replace(/(?:^|:|,)(?:\s*\[)+/g, ''))) {

// In the third stage we use the eval function to compile the text into a
// JavaScript structure. The '{' operator is subject to a syntactic ambiguity
// in JavaScript: it can begin a block or an object literal. We wrap the text
// in parens to eliminate the ambiguity.

                j = eval('(' + text + ')');

// In the optional fourth stage, we recursively walk the new structure, passing
// each name/value pair to a reviver function for possible transformation.

                return typeof reviver === 'function'
                    ? walk({'': j}, '')
                    : j;
            }

// If the text is not JSON parseable, then a SyntaxError is thrown.

            throw new SyntaxError('JSON.parse');
        };
    }
}());

var extend, fetchHash, fromQuery, getOrigin, isArray, isChildWin, isEmptyObject, isFunction, isPopWin, isString, randId, toQuery;

isFunction = function(obj) {
  return Object.prototype.toString.call(obj) === '[object Function]';
};

isArray = function(obj) {
  return Object.prototype.toString.call(obj) === '[object Array]';
};

isString = function(obj) {
  return Object.prototype.toString.call(obj) === '[object String]';
};

isEmptyObject = function(obj) {
  var k;
  for (k in obj) {
    return false;
  }
  return true;
};

isChildWin = function() {
  var err;
  try {
    return window.parent !== window;
  } catch (_error) {
    err = _error;
  }
  return !0;
};

isPopWin = function() {
  var err;
  try {
    return !!window.opener;
  } catch (_error) {
    err = _error;
  }
  return !0;
};

extend = function(dist) {
  var k, src, v, _i, _len;
  if (dist == null) {
    dist = {};
  }
  for (_i = 0, _len = arguments.length; _i < _len; _i++) {
    src = arguments[_i];
    if (src == null) {
      continue;
    }
    for (k in src) {
      v = src[k];
      if (typeof v === 'object') {
        extend(dist[k], v);
      } else {
        dist[k] = v;
      }
    }
  }
  return dist;
};

randId = function() {
  return new Date().getTime().toString() + (Math.random() * (1 << 30)).toString(36).replace('.', '');
};

fromQuery = function(queryString) {
  var m, params, regex;
  regex = /([^&=]+)=([^&]*)/g;
  params = {};
  while (m = regex.exec(queryString)) {
    params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]).replace(/\+/g, ' ');
  }
  return params;
};

toQuery = function(params) {
  var appender, k, qs, v;
  appender = '';
  qs = '';
  for (k in params) {
    v = params[k];
    qs += appender + encodeURIComponent(k) + "=" + encodeURIComponent(params[k]);
    appender = '&';
  }
  return qs;
};

fetchHash = function(hash) {
  if (hash == null) {
    hash = document.location.href;
  }
  if (hash.indexOf("#") >= 0) {
    hash = hash.split("#")[1];
  }
  if (hash.indexOf("?") >= 0) {
    hash = hash.split("?")[1];
  }
  return fromQuery(hash);
};

getOrigin = function(a) {
  var b, c, d, e;
  if (!a) {
    return '';
  }
  a = a.split("#")[0].split("?")[0];
  a = a.toLowerCase();
  if (0 === a.indexOf("//")) {
    a = window.location.protocol + a;
  }
  b = a.substring(a.indexOf("://") + 3);
  c = b.indexOf("/");
  if (-1 !== c) {
    b = b.substring(0, c);
  }
  a = a.substring(0, a.indexOf("://"));
  if ("http" !== a && "https" !== a && "chrome-extension" !== a && "file" !== a) {
    throw new Error("Invalid URI scheme in origin");
  }
  c = "";
  d = b.indexOf(":");
  if (-1 !== d) {
    e = b.substring(d + 1);
    b = b.substring(0, d);
    if ("http" === a && "80" !== e || "https" === a && "443" !== e) {
      c = ":" + e;
    }
  }
  return a + "://" + b + c;
};

// Generated by CoffeeScript 1.7.1
var Storage, deleteCookie, getCookie, setCookie;

getCookie = function(name) {
  var co, rep, res, _ref;
  name = name.replace(/([\.\[\]\$])/g, "\\$1");
  rep = new RegExp(name + "=([^;]*)?;", "i");
  co = document.cookie + ";";
  res = co.match(rep);
  if (res) {
    return (_ref = res[1]) != null ? _ref : '';
  } else {
    return '';
  }
};

deleteCookie = function(name, opts) {
  opts = opts || {};
  opts.expire = -10;
  return setCookie(name, '', opts);
};

setCookie = function(name, value, opts) {
  var cfg, d, t;
  cfg = extend({
    expire: null,
    path: "/",
    domain: null,
    secure: null
  }, opts);
  arr.push(escape(name) + "=" + escape(value));
  if (cfg.path !== null) {
    arr.push("path=" + cfg.path);
  }
  if (cfg.domain !== null && cfg.domain !== 'localhost') {
    arr.push("domain=" + cfg.domain);
  }
  if (cfg.secure !== null) {
    arr.push(cfg.secure);
  }
  if (cfg.expire !== null) {
    d = new Date();
    t = d.getTime() + cfg.expire * 3600000;
    d.setTime(t);
    arr.push("expires=" + d.toGMTString());
  }
  return document.cookie = arr.join(";");
};

Storage = (function() {
  function Storage(type, name) {
    var _ref;
    this.type = type;
    this.name = name;
    this.length = 0;
    this.name = (_ref = this.name) != null ? _ref : 'localStorage';
    this.data = this.getData();
  }

  Storage.prototype.getData = function() {
    var data, e;
    if (this.type === 'session') {
      data = window.name;
    } else {
      data = getCookie(this.name);
    }
    if (data !== null && data !== '') {
      try {
        return JSON.parse(data);
      } catch (_error) {
        e = _error;
      }
    }
    return {};
  };

  Storage.prototype.setData = function(data, opts) {
    data = JSON.stringify(data);
    if (this.type === 'session') {
      return window.name = data;
    } else {
      return setCookie(this.name, data, opts);
    }
  };

  Storage.prototype.deleteData = function() {
    if (this.type === 'session') {
      return window.name = '';
    } else {
      return deleteCookie(this.name);
    }
  };

  Storage.prototype.clear = function() {
    this.data = {};
    this.length = 0;
    return this.deleteData();
  };

  Storage.prototype.getItem = function(key) {
    return this.data[key];
  };

  Storage.prototype.key = function(idx) {
    var ctr, k;
    ctr = 0;
    for (k in this.data) {
      if (ctr === idx) {
        return k;
      }
      ctr++;
    }
    return null;
  };

  Storage.prototype.removeItem = function(key) {
    delete this.data[key];
    this.length--;
    return this.setData(this.data);
  };

  Storage.prototype.setItem = function(key, value) {
    this.data[key] = value;
    this.length++;
    return this.setData(this.data);
  };

  return Storage;

})();

if (!window.localStorage) {
  window.localStorage = new Storage('session');
}

// Generated by CoffeeScript 1.6.3
var iframeRequest;

iframeRequest = function(url, cb) {
  var iframe, iframeId;
  iframeId = '_tgp_iframe_transport_';
  iframe = document.getElementById(iframeId);
  if (iframe === null) {
    iframe = document.createElement("iframe");
    iframe.id = iframeId;
    iframe.style.display = 'none';
    document.body.appendChild(iframe);
  }
  iframe.onload = function() {
    if (isFunction(cb)) {
      cb();
    }
    return iframe.onload = null;
  };
  iframe.src = url;
  return iframe;
};

var jsonp, loadJs;

loadJs = function(opts) {
  var IE, appender, js, query, requestTimeout;
  opts = extend({
    timeout: 30 * 1000,
    data: {},
    onComplete: null,
    onTimeout: null,
    uniqueID: null
  }, opts);
  if (!opts.url) {
    throw "url is null";
  }
  js = document.createElement("script");
  js.charset = "UTF-8";
  IE = /msie/i.test(navigator.userAgent);
  if (opts.onComplete !== null) {
    if (IE) {
      js.onreadystatechange = function() {
        if (js.readyState.toLowerCase() === "complete" || js.readyState.toLowerCase() === "loaded") {
          clearTimeout(requestTimeout);
          if (opts.onComplete) {
            opts.onComplete();
          }
          return js.onreadystatechange = null;
        }
      };
    } else {
      js.onload = function() {
        clearTimeout(requestTimeout);
        if (opts.onComplete) {
          opts.onComplete();
        }
        return js.onload = null;
      };
    }
  }
  if (opts.url.indexOf("?") === -1) {
    appender = '?';
  } else {
    appender = '&';
  }
  query = toQuery(opts.data);
  if (query === '') {
    js.src = opts.url;
  } else {
    js.src = opts.url + appender + query;
  }
  document.getElementsByTagName("head")[0].appendChild(js);
  if (opts.timeout > 0 && opts.onTimeout !== null) {
    requestTimeout = setTimeout(function() {
      return opts.onTimeout();
    }, opts.timeout);
  }
  return js;
};

jsonp = function(opts) {
  var completeFunc, funcStatus, timeoutFunc, uniqueID;
  opts = extend({
    url: "",
    charset: "UTF-8",
    timeout: 30 * 1000,
    data: {},
    onComplete: null,
    onTimeout: null,
    responseName: null,
    varkey: "callback"
  }, opts);
  funcStatus = -1;
  uniqueID = opts.responseName || "__TGPJSONPCB_" + randId();
  opts.data[opts.varkey] = uniqueID;
  completeFunc = opts.onComplete;
  timeoutFunc = opts.onTimeout;
  opts.onComplete = void 0;
  delete opts.onComplete;
  opts.onTimeout = function() {
    if (funcStatus !== 1 && timeoutFunc !== null) {
      funcStatus = 2;
      return timeoutFunc();
    }
  };
  window[uniqueID] = function(oResult) {
    if (funcStatus !== 2 && completeFunc !== null) {
      funcStatus = 1;
      return completeFunc(oResult);
    }
  };
  return loadJs(opts);
};

// Generated by CoffeeScript 1.7.1
var TGP, log;

TGP = {
  debug: true,
  version: '1.0.5',
  domain: '',
  authorizeCallback: function() {}
};

log = function(message) {
  if (!TGP.debug) {
    return;
  }
  Array.prototype.unshift.call(arguments, "[TGP v(" + TGP.version + ")]");
  if (window.console && TGP.debug) {
    return console.log.apply(console, arguments);
  }
};

TGP.settings = {
  response_type: 'token',
  theme: 'sunbetmobile',
  display: 'popup'
};

TGP.endpoints = {
  authorize: '/oauth/authorize',
  verify: '/oauth/verify',
  login: '/sso/login',
  logout: '/sso/logout',
  touch: '/sso/touch'
};

TGP.errors = {
  generalError: 'GeneralError',
  unauthorized: 'Unauthorized',
  sessionExpired: 'SessionExpired',
  clientNotValid: 'ClientNotValid',
  clientNotFound: 'ClientNotFound',
  responseTypeInvalid: 'ResponseTypeInvalid',
  responseTypeNotSupported: 'ResponseTypeNotSupported'
};

TGP._storage = new Storage('session');

TGP._init = function() {
  if (!document.body) {
    setTimeout(function() {
      return TGP._init();
    }, 20);
    return;
  }
  TGP._loginState = 0;
  TGP._initClientInfo();
  TGP._initSession();
  TGP._registerXDReciever();
  return TGP._initialized = true;
};

TGP._initClientInfo = function() {
  var idx, info, js, len, scripts, url, _ref, _ref1, _ref2, _ref3, _ref4, _ref5;
  scripts = document.getElementsByTagName("script");
  idx = 0;
  len = scripts.length;
  while (idx < len) {
    js = scripts[idx++];
    if (js.src.indexOf("tgp.js") !== -1 || js.src.indexOf("tgp.min.js") !== -1) {
      url = js.src.split("?").pop();
      break;
    }
  }
  if (url === null) {
    log('could not init client info since url of js could not matched!');
    return;
  }
  info = fromQuery(url);
  TGP.debug = (_ref = info.debug) != null ? _ref : false;
  TGP.settings.client_id = (_ref1 = (_ref2 = (_ref3 = (_ref4 = info.sid) != null ? _ref4 : info.client_id) != null ? _ref3 : info.clientid) != null ? _ref2 : info.clientId) != null ? _ref1 : '';
  return TGP.settings.scp = (_ref5 = info.scp) != null ? _ref5 : '';
};

TGP._initSession = function() {
  var err, storedSession;
  TGP._session = {};
  storedSession = TGP._storage.getItem('tgpjs_oauth');
  log('--storedSession--');
  log(storedSession);
  if (storedSession != null) {
    try {
      log('try loading session from storage');
      TGP._session = JSON.parse(storedSession);
      if (TGP._session && !!TGP._session.access_token) {
        TGP._loginState = 1;
      }
    } catch (_error) {
      err = _error;
      log('error parsing stored session json');
      TGP._loginState = -1;
    }
  }
  if (location.hash.match(/access_token=(\w+)/)) {
    log('try fetching data from hash', location.hash);
    TGP._session = fetchHash(location.hash);
    TGP._storage.setItem('tgpjs_oauth', JSON.stringify(TGP._session));
    TGP._loginState = 2;
    return location.href = location.href.replace(/#.*/, '#');
  } else if (location.hash.match(/error=(\w+)/)) {
    TGP._session = {};
    TGP._storage.removeItem('tgpjs_oauth');
    TGP._loginState = -1;
    return location.href = location.href.replace(/#.*/, '#');
  }
};

TGP._registerXDReciever = function() {
  var handlePostMessage;
  handlePostMessage = function(e) {
    return TGP._handleAuthorize(e.data);
  };
  if (window.postMessage) {
    if (window.addEventListener) {
      return window.addEventListener('message', handlePostMessage, !1);
    } else {
      return window.attachEvent('onmessage', handlePostMessage);
    }
  } else {
    return log('window not supported postMessage');
  }
};

TGP._getEndpoint = function(key) {
  var endpoint;
  endpoint = TGP.endpoints[key];
  if (endpoint === null) {
    throw 'invalid endpoint of #{key}';
  }
  if (endpoint.indexOf('http') >= 0) {
    return endpoint;
  }
  if (endpoint.indexOf('/') !== 0) {
    return '/' + endpoint;
  }
  return TGP.domain + endpoint;
};

TGP.login = function(opts) {
  var params, pollOpenWinIntv, pollOpenWinResult, pollOpenWinTried, url;
  params = extend({}, TGP.settings, opts);
  params.silent = '0';
  params.state = TGP.authorizeState = randId();
  if (params.redirect_uri == null) {
    params.redirect_uri = window.location.href.replace(/#.*$/, '');
  }
  url = TGP._getEndpoint('authorize') + "?" + toQuery(params);
  TGP._loginDisplay = params.display;
  if (TGP._loginDisplay === 'redirect') {
    return window.location.href = url;
  } else if (TGP._loginDisplay === 'iframe') {
    params.url = url;
    return TGP.widgets.login.show(params);
  } else {
    TGP.oauthWin = window.open(url, "tgp_oauth_login_window", "width=500,height=440,toolbar=no,menubar=no,resizable=no,status=no,left=200,top=200");
    TGP.oauthWin.focus();
    pollOpenWinIntv = void 0;
    pollOpenWinTried = 0;
    pollOpenWinResult = function() {
      var err;
      try {
        if (TGP.oauthWin && typeof TGP.oauthWin.closed === 'undefined') {
          alert("Please enable popup of the browser");
          window.clearInterval(pollOpenWinIntv);
          return;
        }
        log("TGP.oauthWin.name " + TGP.oauthWin.name);
      } catch (_error) {
        err = _error;
        log(err);
      }
    };
    return pollOpenWinIntv = setTimeout(pollOpenWinResult, 800);
  }
};

TGP.logout = function(opts, callback) {
  if (isFunction(opts)) {
    callback = opts;
  }
  if (!isFunction(callback)) {
    callback = function() {};
  }
  TGP._session = {};
  TGP._storage.removeItem('tgpjs_oauth');
  return jsonp({
    url: TGP._getEndpoint('logout'),
    data: {
      client_id: TGP.settings.client_id
    },
    onComplete: function(result) {
      log('logout oncomplete', result);
      return callback(true);
    },
    onTimeout: function() {
      return callback(false);
    }
  });
};

TGP.authorize = function(opts, callback) {
  if (!TGP._initialized) {
    return setTimeout(function() {
      return TGP.authorize(opts, callback);
    }, 50);
  }
  if (isFunction(opts)) {
    callback = opts;
  } else {
    extend(TGP.settings, opts);
  }
  TGP.authorizeCallback = callback != null ? callback : function() {};
  log("TGP._loginState: " + TGP._loginState);
  if (TGP._loginState === 0) {
    if (TGP.settings.force === true) {
      log('force re-authorize');
      TGP.authorizeCallback(TGP.errors.unauthorized);
    } else {
      log('perform authorize');
      TGP._authorize(opts);
    }
  } else if (TGP._loginState === 1) {
    if (TGP.settings.force === true) {
      log('force re-authorize');
      TGP.authorizeCallback(TGP.errors.unauthorized);
    } else if (TGP.settings.revalidate === true) {
      log('revalidate authorize');
      TGP._verifyAuthorize(opts);
    } else {
      log('success authorize');
      TGP._loginState = 2;
      TGP.authorizeCallback(null, TGP._session);
    }
  } else if (TGP._loginState === 2) {
    log('success authorize');
    TGP.authorizeCallback(null, TGP._session);
  } else {
    TGP.authorizeCallback(TGP.errors.unauthorized);
  }
};

TGP._authorize = function(opts) {
  var params, url;
  params = extend({}, TGP.settings, opts);
  params.state = TGP.authorizeState = randId();
  url = TGP._getEndpoint('authorize') + "?" + toQuery(params);
  return iframeRequest(url);
};

TGP._verifyAuthorize = function(opts) {
  TGP.authorizeState = randId();
  opts = extend(opts, {
    client_id: TGP.settings.client_id,
    silent: '1',
    response_type: 'token',
    state: TGP.authorizeState
  });
  return jsonp({
    url: TGP._getEndpoint('verify'),
    data: opts,
    onComplete: function(result) {
      return TGP._handleAuthorize(result);
    },
    onTimeout: function() {
      return TGP.authorizeCallback(TGP.errors.unauthorized);
    }
  });
};

TGP.handleAuthorizeCallback = TGP._handleAuthorize = function(result) {
  var err;
  log('--handle authorize callback--');
  if (isString(result)) {
    try {
      result = JSON.parse(unescape(result));
    } catch (_error) {
      err = _error;
      log("authorize exception when parsing result as json", err);
      TGP.authorizeCallback(TGP.errors.unauthorized, null);
      return;
    }
  }
  if (TGP._loginDisplay === 'iframe') {
    TGP.widgets.login.close();
  }
  if (!!result.access_token) {
    TGP._loginState = 2;
    TGP._session = result;
    TGP._storage.setItem('tgpjs_oauth', JSON.stringify(TGP._session));
    return TGP.authorizeCallback(null, result);
  } else if (!!result.error_description) {
    log('got error_description', result.error_description);
    return TGP.authorizeCallback(result.error_description, result);
  } else {
    return TGP.authorizeCallback(TGP.errors.unauthorized, null);
  }
};

TGP.getStatus = function() {
  var status;
  return status = {
    loginState: TGP._loginState,
    session: TGP._session
  };
};

TGP.getAccessToken = function() {
  if (TGP._session !== null) {
    return TGP._session.access_token;
  } else {
    return void 0;
  }
};

TGP.getSessionId = function() {
  if (TGP._session !== null) {
    return TGP._session.session_id;
  } else {
    return void 0;
  }
};

TGP.touchin = function(opts, cb) {
  if (!TGP._initialized) {
    setTimeout(function() {
      return TGP.touchin(opts, cb);
    }, 50);
    return;
  }
  opts = extend(opts, {
    action: 'set',
    client_id: TGP.settings.client_id,
    scp: TGP.settings.scp
  });
  return jsonp({
    url: TGP._getEndpoint('touch'),
    data: opts,
    onComplete: function(result) {
      log('touchin complete', result);
      if (isFunction(cb)) {
        return cb(result);
      }
    },
    onTimeout: function(result) {
      log('touchin timeout', result);
      if (isFunction(cb)) {
        return cb('timeout');
      }
    }
  });
};

TGP.touchout = function(opts, cb) {
  if (!TGP._initialized) {
    setTimeout(function() {
      return TGP.touchin(opts, cb);
    }, 50);
    return;
  }
  opts = extend(opts, {
    action: 'clear',
    client_id: TGP.settings.client_id
  });
  return jsonp({
    url: TGP._getEndpoint('touch'),
    data: opts,
    onComplete: function(result) {
      log('touchout complete', result);
      if (isFunction(cb)) {
        return cb(result);
      }
    },
    onTimeout: function() {
      log('touchout timeout', result);
      if (isFunction(cb)) {
        return cb('timeout');
      }
    }
  });
};

window.TGP = TGP;

window.acssso = TGP;

TGP._init();

// Generated by CoffeeScript 1.7.1
TGP.widgets = {};

TGP.widgets.login = function(opts) {
  this.opts = extend(TGP.widgets.login.defaults, opts);
  //console.log(this.opts);
  return this.initUI();
};

TGP.widgets.login.instance = null;

TGP.widgets.login.defaults = {
  url: '',
  width: 428,
  height: 326,
  showCloseBtn: true,
  showOverlayStyle: true,
  parentId: "",
  overlayId: '_tgp_widget_overlay_',
  modalId: '_tgp_widget_overlay_modal_',
  closeBtnId: '_tgp_widget_overlay_modal_close_btn_',
  iframeId: '_tgp_widget_overlay_modal_frame_'
};

TGP.widgets.login.prototype.initUI = function() {
  var closeBtn, height, heightUnit, iframe, isHeightInPercentage, isWidthInPercentage, modal, overlay, parent, width, widthUnit;
  overlay = document.getElementById(this.opts.overlayId);
  if (overlay !== null) {
    overlay.parentNode.removeChild(overlay);
    return this.initUI();
  }
  if (overlay === null) {
    overlay = document.createElement("div");
    overlay.id = this.opts.overlayId;
    if (this.opts.showOverlayStyle) {
      overlay.style.display = 'none';
      overlay.style.visibility = 'hidden';
      overlay.style.position = 'absolute';
      overlay.style.left = '0px';
      overlay.style.top = '0px';
      overlay.style.width = '100%';
      overlay.style.height = '250%';
      overlay.style.textAlign = 'center';
      //overlay.style.backgroundColor = 'rgba(204,204,204,0.3)';
      overlay.style.zIndex = '1000';
    }
    isWidthInPercentage = this.opts.width.toString().indexOf('%') >= 0;
    isHeightInPercentage = this.opts.height.toString().indexOf('%') >= 0;
    if (isWidthInPercentage) {
      widthUnit = '%';
    } else {
      widthUnit = 'px';
    }
    if (isHeightInPercentage) {
      heightUnit = '%';
    } else {
      heightUnit = 'px';
    }
    width = parseFloat(this.opts.width);
    height = parseFloat(this.opts.height);
    modal = document.createElement('div');
    modal.id = this.opts.modalId;
    if (this.opts.parentId === "") {
      modal.style.display = 'none';
      modal.style.visibility = 'hidden';
      modal.style.position = 'fixed';
      modal.style.width = width + widthUnit;
      modal.style.height = height + heightUnit;
      if (isWidthInPercentage) {
        modal.style.left = '0';
        modal.style.marginLeft = '0';
      } else {
        modal.style.left = '50%';
        modal.style.marginLeft = (width / 2 * -1) + widthUnit;
      }
      if (isHeightInPercentage) {
        modal.style.top = '0';
        modal.style.marginTop = '0';
      } else {
        modal.style.top = '50%';
        modal.style.marginTop = (height / 2 * -1) + heightUnit;
      }
    }
    iframe = document.createElement('iframe');
    iframe.id = this.opts.iframeId;
    iframe.src = 'javascript:void(0)';
    iframe.style.margin = '0px';
    iframe.style.padding = '0px';
    iframe.style.backgroundColor = 'transparent';
    iframe.setAttribute('allowTransparency', 'true');
    iframe.setAttribute('width', width + widthUnit);
    iframe.setAttribute('height', height + heightUnit);
    iframe.setAttribute('scrolling', 'no');
    iframe.setAttribute('frameborder', '0');
    closeBtn = document.createElement('a');
    closeBtn.id = this.opts.closeBtnId;
    closeBtn.href = '#';
    closeBtn.style.textDecoration = 'none';
    closeBtn.style.visibility = 'hidden';
    closeBtn.style.lineHeight = '1';
    closeBtn.style.position = 'absolute';
    closeBtn.style.top = '0.3em';
    closeBtn.style.right = '0.6875em';
    closeBtn.style.color = '#aaa';
    closeBtn.style.fontSize = '.987em';
    closeBtn.style.fontFamily = 'arial,sans-serif';
    closeBtn.style.cursor = 'pointer';
    closeBtn.style.zIndex = '50';
    closeBtn.innerHTML = 'x';
    modal.appendChild(iframe);
    modal.appendChild(closeBtn);
    overlay.appendChild(modal);
    if (this.opts.parentId !== "") {
      parent = document.getElementById(this.opts.parentId);
      parent.appendChild(overlay);
    } else {
      document.body.appendChild(overlay);
    }
  }
  return this;
};

TGP.widgets.login.prototype.toggle = function(state) {
  var closeBtn, iframe, modal, overlay, self;
  self = this;
  overlay = document.getElementById(self.opts.overlayId);
  modal = document.getElementById(self.opts.modalId);
  closeBtn = document.getElementById(self.opts.closeBtnId);
  iframe = document.getElementById(self.opts.iframeId);
  closeBtn.style.visibility = "hidden";
  closeBtn.onclick = function(e) {
    return TGP.widgets.login.close();
  };
  iframe.onload = function(e) {
    if (self.opts.showCloseBtn) {
      closeBtn.style.visibility = 'visible';
    } else {
      closeBtn.style.visibility = 'hidden';
    }
    iframe.onload = null;
    return true;
  };
  if (state === 'show') {
    overlay.style.visibility = "visible";
    overlay.style.display = 'block';
    modal.style.visibility = "visible";
    modal.style.display = 'block';
    iframe.src = self.opts.url;
  } else {
    overlay.style.visibility = "hidden";
    overlay.style.display = 'none';
    modal.style.visibility = "hidden";
    modal.style.display = 'none';
    iframe.src = 'javascript:void(0)';
  }
  return self;
};

TGP.widgets.login.prototype.show = function() {
  return this.toggle('show');
};

TGP.widgets.login.prototype.hide = function() {
  return this.toggle('hide');
};

TGP.widgets.login.show = function(opts) {
  var loginParam, _ref, _ref1;
  opts = opts != null ? opts : {};
  if (opts.url === null) {
    loginParam = {
      client_id: (_ref = opts.client_id) != null ? _ref : TGP.settings.client_id,
      theme: (_ref1 = opts.theme) != null ? _ref1 : 'default'
    };
    opts.url = TGP._getEndpoint('login') + "?" + toQuery(loginParam);
  }
  TGP.widgets.login.instance = new TGP.widgets.login(opts);
  TGP.widgets.login.instance.show();
  return true;
};

TGP.widgets.login.close = function() {
  if (TGP.widgets.login.instance) {
    TGP.widgets.login.instance = null;
  }
  return true;
};

})(window);