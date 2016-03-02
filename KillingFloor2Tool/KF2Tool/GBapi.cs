using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KF2Tool
{
    class GBapi
    {
    }
    public class Rootobject
    {
        public string _sViewTemplate { get; set; }
        public string _sModuleId { get; set; }
        public bool _bRecordsExist { get; set; }
        public _Apagenavigation _aPageNavigation { get; set; }
        public _Acellvalues[] _aCellValues { get; set; }
    }

    public class _Apagenavigation
    {
        public _Apagenumbertextinput _aPageNumberTextInput { get; set; }
        public _Apagenumbers[] _aPageNumbers { get; set; }
        public int _nCurrentPage { get; set; }
        public int _nPagesInList { get; set; }
        public string _sPageUrlTemplate { get; set; }
    }

    public class _Apagenumbertextinput
    {
        public _Aattributes _aAttributes { get; set; }
    }

    public class _Aattributes
    {
        public int value { get; set; }
        public int maxlength { get; set; }
        public string onblur { get; set; }
    }

    public class _Apagenumbers
    {
        public string _sUrl { get; set; }
        public int _nPageNumber { get; set; }
        public int _nPreviousPageNumber { get; set; }
    }

    public class _Acellvalues
    {
        public string _sProfileUrl { get; set; }
        public _Asubmitter _aSubmitter { get; set; }
        public int _tsDateAdded { get; set; }
        public int _tsDateModified { get; set; }
        public string _sName { get; set; }
        public bool _bIsFlagged { get; set; }
        public string _sArticle { get; set; }
        public string _sFirstThumbnailImageUrl { get; set; }
        public int _tsDateUpdated { get; set; }
        public _Agame _aGame { get; set; }
        public _Acategory _aCategory { get; set; }
        public object _aSuperCategory { get; set; }
        public object _sQuickDownloadUrl { get; set; }
        public object _aStudio { get; set; }
        public int _nViewCount { get; set; }
        public object _aContest { get; set; }
        public _Askilllevel _aSkillLevel { get; set; }
        public float _fRating { get; set; }
        public int _nVoteCount { get; set; }
        public int _nPostCount { get; set; }
        public int _idItemRow { get; set; }
    }

    public class _Asubmitter
    {
        public int _nId { get; set; }
        public string _sUsername { get; set; }
        public string _sUserTitle { get; set; }
        public string _sHonoraryTitle { get; set; }
        public string _sAvatarUrl { get; set; }
        public bool _sSigUrl { get; set; }
        public string _sProfileUrl { get; set; }
        public bool _sUpicUrl { get; set; }
        public bool _bIsOnline { get; set; }
        public string _sLocation { get; set; }
        public int _nPoints { get; set; }
        public int _nPointsRank { get; set; }
        public string _sPointsUrl { get; set; }
        public string _sMedalsUrl { get; set; }
        public object[] _aLegendaryMedals { get; set; }
        public object[] _aRareMedals { get; set; }
        public string[][] _aNormalMedals { get; set; }
        public string _sClearanceLevel { get; set; }
        public int _tsJoinDate { get; set; }
        public object[] _aAffiliatedStudio { get; set; }
        public string _sSubjectShaperCssCode { get; set; }
        public string _sCooltipCssCode { get; set; }
    }

    public class _Agame
    {
        public string _sAbbreviation { get; set; }
        public string _sName { get; set; }
        public string _sProfileUrl { get; set; }
        public string _sIconUrl { get; set; }
        public bool _sBannerUrl { get; set; }
    }

    public class _Acategory
    {
        public string _sName { get; set; }
        public string _sProfileUrl { get; set; }
    }

    public class _Askilllevel
    {
        public string _sTitle { get; set; }
        public string _sGroupName { get; set; }
    }
}
